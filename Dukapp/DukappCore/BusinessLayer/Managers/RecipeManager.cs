using System;
using System.Collections.Generic;
using DukappCore.BL.Records;
using DukappCore.BL.Objects;

namespace DukappCore.BL.Managers
{
    public static class RecipeManager
    {
		public static List<RecipeRecord>GetRecipesForPhase( DietPhase phase )
		{
			return (List<RecipeRecord>)DukappCore.DAL.DukappRepository.GetRecipesForPhase(phase);
		}
		public static List<DietPhase>GetPhaseForRecipe( int recipeID )
		{
			return (List<DietPhase>)DukappCore.DAL.DukappRepository.GetPhaseForRecipe(recipeID);
		}
		public static RecipeMealsRecord GetRecipeMealRecord( int recmealID )
		{
			return DukappCore.DAL.DukappRepository.GetRecipeMealRecord(recmealID);
		}
        public static RecipeRecord GetRecipeRecord( int id )
        {
            return DukappCore.DAL.DukappRepository.GetRecipeRecord(id);
        }
        public static List<RecipeRecord> GetRecipeRecords ( RecipeSrcType type )
        {
            return new List<RecipeRecord>(DukappCore.DAL.DukappRepository.GetRecipeRecords(type));
        }
        public static int SaveRecipeRecord (RecipeRecord item)
        {
            return DukappCore.DAL.DukappRepository.SaveRecipeRecord(item);
        }
        public static int DeleteRecipeRecord(int id)
        {
            return DukappCore.DAL.DukappRepository.DeleteRecipeRecord(id);
        }
        public static List<RecipeRecord> GetRecipesForMeal( MealRecord meal )
        {
            return (List<RecipeRecord>)DukappCore.DAL.DukappRepository.GetRecipesForMeal(meal);
        }
        public static List<RecipeMealsRecord> GetMealsForRecipe( int recipeID )
        {
            return (List<RecipeMealsRecord>)DukappCore.DAL.DukappRepository.GetMealsForRecipe(recipeID);
        }

    }
}

