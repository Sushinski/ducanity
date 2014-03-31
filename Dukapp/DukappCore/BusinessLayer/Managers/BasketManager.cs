using System;
using System.Collections.Generic;
using DukappCore.BL.Records;

namespace DukappCore.BL.Managers
{
    public static class BasketManager
    {
        public static List<BasketMealsRecord> GetBasketRecords()
        {
			return (List<BasketMealsRecord>)DAL.DukappRepository.GetBasketRecords();
        }

        public static BasketMealsRecord GetBasketRecipeRecord( int recipeMealsID )
        {
            return DAL.DukappRepository.GetBasketRecipeRecord(recipeMealsID);
        }

        public static BasketMealsRecord GetBasketRecipeMeal( int recipeID, int mealID )
        {
            return DAL.DukappRepository.GetBasketRecipeMeals(recipeID, mealID);
        }

        public static void SaveBasketRecord( BasketMealsRecord item )
        {
            DAL.DukappRepository.SaveBasketMealsRecord(item);
        }

        public static void DeleteBasketRecord( int ID )
        {
            DAL.DukappRepository.DeleteBasketMealsRecord( ID );
        }
    }
}

