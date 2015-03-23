import java.util.*;
import java.io.*;
import java.sql.*;

public class DukBaseParserMain 
{
	static Connection m_conn;
	static String path;
	static String recipe_type;
	static Map<String, String> m_dimensions;
	public static void main(String[] args) 
	{
		try 
		{
			try {
				path = new File(".").getCanonicalPath();
				System.out.println(path);
			} catch (IOException e) {
				path="";
				e.printStackTrace();
			}
			// 1: Init connection
			InitConnection();
			// check mode
			Scanner in = null;
			if(args[0].toLowerCase().compareTo("meals") == 0)
			{
				path += "//meals.csv";
				in = new Scanner(new File(path), "UTF-8");
				Vector<Meal> res = readMeals(in);
				InsertMeals(res);
			}
			else if(args[0].toLowerCase().compareTo("recipes") == 0)
			{
				if( args.length != 2 ) return;
				path += "//recipes.csv";
				in = new Scanner(new File(path), "UTF-8");
				m_dimensions = new TreeMap<String, String>();
				recipe_type = args[1];
				Vector<Record> recs = readRecipes(in);
				SaveRecords(recs);				
			}
			if( in != null ) in.close();
			
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}
	
	private static int InitConnection()
	{
		try
		{
	      Class.forName("org.sqlite.JDBC");
	      m_conn = DriverManager.getConnection("jdbc:sqlite:DukappDB.db3");
	      m_conn.setAutoCommit(false);
	      System.out.println("Opened database successfully");
		}
	    catch ( Exception e ) 
	    {
	      System.err.println( e.getClass().getName() + ": " + e.getMessage() );
	      System.exit(0);
	    }
		return 0;
	}

	
	private static Vector<Record> readRecipes(Scanner in)
	{
	  Vector<Record> res = new Vector<Record>();
	  Vector<String> vals = new Vector<String>();
	  in.nextLine();// skip head strings(2)
	  in.nextLine();
	  boolean bAdd = false;
	  String cur_str = "";
	  while(in.hasNext())
	  {
		  String line = in.nextLine();
		  if( line.length() != 0 )
		  {
			  String[] parsed = line.split(",");
			  // collect all parsed strings
			  int start_val;
			  try
			  {
				  start_val = Integer.parseInt(parsed[0]);
			  }
			  catch(NumberFormatException e)
			  {
				  start_val = 0;
			  }
			  if( start_val != 0 )
			  {
				  // rec_prev
				  if(!vals.isEmpty())
				  {
					  Record rec = new Record();
					  rec.num = vals.get(0);
					  rec.name = vals.get(1);
					  rec.stages = vals.get(2);
					  rec.meals = new ArrayList<Meal>();
					  Meal ml = new Meal();
					  // first meal
					  ml.m_name = vals.get(3);
					  ml.m_qty = QtyIfZero(ml.m_name) == true ? "" : vals.get(4);
					  rec.meals.add(ml);
					  // recipe text
					  rec.recipe = vals.get(5);
					  // then other meals
					  for( int i = 6; i < vals.size()-1; )
					  {
						  ml = new Meal();
						  ml.m_name = vals.get(i);
						  //if quantity is empty - insert empty value
						  if(QtyIfZero(ml.m_name) == true )
						  {
							  ml.m_qty = "";
							  i += 1;
						  }
						  else
						  {
							  ml.m_qty = vals.get(i+1);
							  i += 2;
						  }
						  rec.meals.add(ml);
					  }
					  res.add(rec);
					  vals.clear();
					  bAdd = false;
				  }
			  }
			  for( int i = 0; i < parsed.length; ++i )
			  {
				  if(parsed[i].length() == 0 ) continue;
				  if( parsed[i].charAt(0) == '\"' )
					  bAdd = true;
				  if( parsed[i].charAt(parsed[i].length()-1)=='\"')
				  {
					  cur_str += parsed[i];
					  vals.add(cur_str);
					  cur_str = "";
					  bAdd = false;
				  }
				  else
				  {
					  if(bAdd)
						  cur_str += parsed[i];
					  else
						  vals.add(parsed[i]);
				  }
			  }
		  }
	  }
	  //record last
	  if(!vals.isEmpty())
	  {
		  Record rec = new Record();
		  rec.num = vals.get(0);
		  rec.name = vals.get(1);
		  rec.stages = vals.get(2);
		  rec.meals = new ArrayList<Meal>();
		  Meal ml = new Meal();
		  ml.m_name = vals.get(3);
		  ml.m_qty = QtyIfZero(ml.m_name) == true ? "" : vals.get(4);
		  rec.meals.add(ml);
		  rec.recipe = vals.get(5);
		  for( int i = 6; i < vals.size()-1; )
		  {
			  ml = new Meal();
			  ml.m_name = vals.get(i);
			  //if quantity is empty - insert empty value
			  if(QtyIfZero(ml.m_name) == true )
			  {
				  ml.m_qty = "";
				  i += 1;
			  }
			  else
			  {
				  ml.m_qty = vals.get(i+1);
				  i += 2;
			  }
			  rec.meals.add(ml);
		  }
		  res.add(rec);
		  vals.clear();
		  bAdd = false;
	  }
	  
	  return res;
	}
	private static int SaveRecords( Vector<Record> vec )
	{
	    Statement stmt = null;
	    try 
	    {
	      stmt = m_conn.createStatement();
	      for(Record rec : vec)
	      {
	    	  String recipe_type_descr;
	    	  if(recipe_type.toLowerCase().contains("firsts")) recipe_type_descr = "1";
	    	  else if(recipe_type.toLowerCase().contains("seconds")) recipe_type_descr = "2";
	    	  else if(recipe_type.toLowerCase().contains("salads")) recipe_type_descr = "3";
	    	  else if(recipe_type.toLowerCase().contains("snacks")) recipe_type_descr = "4";
	    	  else recipe_type_descr = "0";
	    	  String last_ID = "0";
		      String sql_ins = "INSERT INTO RecipeRecord (RecipeType,isFavourite,RecipeName,RecipeDesc) " +
		                   "VALUES (" + recipe_type_descr + ",0,'" + rec.name + "','" + rec.recipe + "');"; 
		      stmt.executeUpdate(sql_ins);
		      // get inserted ID
		      String sql_sel = "SELECT ID FROM RecipeRecord WHERE RecipeName='" + rec.name + "';";
		      ResultSet rs = stmt.executeQuery(sql_sel);
		      if(rs.next())
		      {
		    	  // save stages for recipe
		    	  last_ID = rs.getString("ID");
		    	  String atck="0", crse="0", cons="0", stab="0";
		    	  if( rec.stages.contains("Атака") ) atck = "1";
		    	  if( rec.stages.contains("Круиз") ) crse = "1";
		    	  if( rec.stages.contains("Консолидация") ) cons = "1";
		    	  if( rec.stages.contains("Стабилизация") ) stab = "1";
		    	  String stg_ins = "INSERT INTO RecipeType(RecipeID, Attack, Cruise, Consolidation, Stabilization) " +
		    			  			"VALUES ("+ last_ID + ", " + atck + ", " + crse + ", " + cons + ", " + stab + ");";
		    	  stmt.executeUpdate(stg_ins);
		    	  // now saving recipe meals
		    	  SaveRecipeMeals(rec.meals, last_ID);
		    	  
		      }

	      }
	      stmt.close();
	      m_conn.commit();
	    } 
	    catch ( Exception e ) 
	    {
	      System.err.println( e.getClass().getName() + ": " + e.getMessage() );
	      System.exit(-1);
	    }
	    System.out.println("Records created successfully");
		return 0;
	}
	private static int InsertMeals(Vector<Meal> meals)
	{
		try
		{
		    Statement stmt = null;
		    stmt = m_conn.createStatement();
		    // clear meal table
		    stmt.executeUpdate("DELETE FROM MealRecord;");
		    for(int i = 0; i < meals.size(); ++i)
		    {
		    	String ins = "INSERT INTO MealRecord(ID, Name, MealDesc) VALUES(" + Integer.toString(i+1)  + ",'" + meals.get(i).m_name + "','" + meals.get(i).m_desc + "');";
		    	stmt.executeUpdate(ins);
		    }
		    stmt.close();
		    m_conn.commit();
		}
	    catch ( Exception e ) 
	    {
	      System.err.println( e.getClass().getName() + ": " + e.getMessage() );
	      System.exit(0);
	    }
		return 0;
	}
	// saving Meal table 
	private static Vector<Meal> readMeals(Scanner in)
	{
		Vector<Meal> res = new Vector<Meal>();
		//in.nextLine();
		while(in.hasNext())
		{
			String line = in.nextLine();
			  if( line.length() != 0 )
			  {
				  String[] parsed = line.split(",");
				  if( parsed.length != 0 )
				  {
					  Meal ml = new Meal();
					  ml.m_name = parsed[0];
					  ml.m_desc = parsed.length == 2 ? parsed[1] : "по вкусу";
					  ml.m_qty = "";
					  res.add(ml);
				  }
			  }
		}
		return res;
	}
	
	private static int SaveRecipeMeals( List<Meal> meals, String recipeID )
	{
		Statement stmt = null;
		try
		{
			stmt = m_conn.createStatement();
			for( Meal ml : meals )
			{
				// first: check if current meal exists
				String sql_sel = "SELECT ID FROM MealRecord WHERE Name='" + ml.m_name + "';";
				ResultSet rs = stmt.executeQuery(sql_sel);
				// if meal presented
				if( rs.next() )
				{
					// insert into RecipeMeals
					  String rm_ins = "INSERT INTO RecipeMealsRecord(Qty,RecipeID, MealID) " +
	    			  			"VALUES ('"+ ml.m_qty + "', " + recipeID + ", " + rs.getString("ID") + ");";
					  stmt.executeUpdate(rm_ins);
				}
				else
				{
					// if meal not presented - return error
					  System.err.println("meal "+ ml.m_name + " not presented in database");
				      stmt.close();
				      m_conn.commit();
				      return -1;
				}
				
			}
		    stmt.close();
		    m_conn.commit();
		}
		catch ( Exception e ) 
	    {
	      System.err.println( e.getClass().getName() + ": " + e.getMessage() );
	      System.exit(-1);
	    }
		
		return 0;
	}
	
	public static boolean QtyIfZero( String mealName)
	{
		// fill dim map
		 if(m_dimensions.isEmpty())
		 {
				Statement stmt = null;
				try
				{
					stmt = m_conn.createStatement();
					String sql_sel = "SELECT * FROM MealRecord;";
					ResultSet rs = stmt.executeQuery(sql_sel);
					while( rs.next() )
					{
						m_dimensions.put(rs.getString("Name"), rs.getString("MealDesc"));
					}
				    stmt.close();
				    m_conn.commit();
				}
				catch ( Exception e ) 
			    {
			      System.err.println( e.getClass().getName() + ": " + e.getMessage() );
			      System.exit(-1);
			    }
		 } 
		 String dim = m_dimensions.get(mealName);
		 if( dim != null )
			 return dim.matches("по вкусу");
		 else
			 System.err.println("meal "+ mealName + " not presented in database");
		 return false;
			 
	}
}

class Meal
{
	public Meal()
	{
		m_name = "";
		m_desc = "";
		m_qty = "";
	}
	public String m_name;
	public String m_qty;
	public String m_desc;
}

class Record
{
	public Record()
	{	
	}
	public String num;
	public String name;
	public String stages;
	public List<Meal> meals;
	public String recipe;
}