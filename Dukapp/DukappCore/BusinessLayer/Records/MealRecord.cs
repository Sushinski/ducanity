using System;
using System.Collections.Generic;
using DukappCore.SQLite;
using DukappCore.BL.Contracts;

namespace DukappCore.BL.Records
{
	public class MealRecord : IRecord
	{
		public MealRecord ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string MealDesc { get; set; }
		//public List<RecipeRecord> MealRecipes{ get; set; }
		
	}
}

