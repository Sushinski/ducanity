using System;
using System.Collections.Generic;
using DukappCore.BL.Records;
using DukappCore.BL.Objects;

namespace DukappCore.DAL
{
	public partial class DukappRepository 
	{
    
       /* public static int SaveRecipeMeals( RecipeRecord r, List<MealRecord> recipe_meals )
        {
            foreach (MealRecord m in recipe_meals)
            {
                RecipeMealsRecord rm_r;
                rm_r.MealID = m.ID;
                rm_r.RecipeID = r.ID;
                return instance.db.SaveItem<RecipeMealsRecord>(rm_r);
            }
        }*/

        public static IEnumerable<RecipeRecord> GetRecipeRecords ( RecipeSrcType type )
		{
            string param_name = "";
            string param_value = "";
			if (type != RecipeSrcType.Favourites)
				param_name = "RecipeType";
			else
				param_name="isFavourite";
			param_value = ((int)type).ToString();		
			return instance.db.GetItemsWParam<RecipeRecord>("RecipeRecord", param_name, param_value );

		}

		public static RecipeMealsRecord GetRecipeMealRecord( int recmealID )
		{
			return instance.db.GetItem<RecipeMealsRecord>(recmealID);
		}

        public static RecipeRecord GetRecipeRecord( int id )
        {
            return instance.db.GetItem<RecipeRecord>(id);
        }

		public static int SaveRecipeRecord (RecipeRecord item)
		{
			return instance.db.SaveItem<RecipeRecord>(item);
		}

		public static int DeleteRecipeRecord(int id)
		{
			return instance.db.DeleteItem<RecipeRecord>(id);
		}

        public static IEnumerable<RecipeRecord> GetRecipesForMeal(MealRecord meal)
        {
            List<RecipeMealsRecord> r_m = (List<RecipeMealsRecord>)(instance.db.GetItemsWParam<RecipeMealsRecord>("RecipeMealsRecord", "MealID", meal.ID.ToString() ));
            List<RecipeRecord> res = new List<RecipeRecord>();
            foreach (RecipeMealsRecord rm in r_m)
            {
                res.Add(instance.db.GetItem<RecipeRecord>(rm.RecipeID));
            }
            return res;
        }

        public static IEnumerable<RecipeMealsRecord> GetMealsForRecipe( int recipeID )
        {
            return instance.db.GetItemsWParam<RecipeMealsRecord>("RecipeMealsRecord", "RecipeID", recipeID.ToString());
        } 

		public static IEnumerable<RecipeRecord> GetRecipesForPhase( DietPhase phase )
		{
			List<RecipeType> r_t = (List<RecipeType>)instance.db.GetItemsWParam<RecipeType>("RecipeType", phase.ToString(), "1");
			List<RecipeRecord> res = new List<RecipeRecord>();
			foreach (RecipeType rt in r_t)
			{
				res.Add(instance.db.GetItem<RecipeRecord>(rt.RecipeID));
			}
			return res;
		}

		public static IEnumerable<DietPhase>GetPhaseForRecipe(int recipeID )
		{
			List<DietPhase> res = new List<DietPhase>();
			List<RecipeType> r_t_l = instance.db.GetItemsWParam<RecipeType>("RecipeType", "RecipeID", recipeID.ToString());
			if (r_t_l.Count != 0)
			{
				RecipeType r_t = r_t_l[0];
				if (r_t.Attack != 0)
					res.Add(new DietPhase(DietPhaseId.DP_Attack));
				if (r_t.Cruise != 0)
					res.Add(new DietPhase(DietPhaseId.DP_Cruise));
				if (r_t.Consolidation != 0)
					res.Add(new DietPhase(DietPhaseId.DP_Consolidation));
				if (r_t.Stabilization != 0)
					res.Add(new DietPhase(DietPhaseId.DP_Stabilization));
			}
			else
				res.Add(new DietPhase(DietPhaseId.DP_Default));
			return res;
		}
	}
}

