using System;
using System.Collections.Generic;
using DukappCore.BL.Records;

namespace DukappCore.DAL
{
    public partial class DukappRepository
    {
        public static BasketMealsRecord GetBasketRecipeMeals( int recipeID, int mealID )
        {
            // get all meals for recipe
            List<RecipeMealsRecord> rmr = 
                instance.db.GetItemsWParam<RecipeMealsRecord>("RecipeMealsRecord", "RecipeID", recipeID.ToString());
            List<BasketMealsRecord> bmr = null;
            foreach (RecipeMealsRecord r in rmr)
            {
                if (r.MealID == mealID)
                {
                    bmr = instance.db.GetItemsWParam<BasketMealsRecord>("BasketMealsRecord", "RecipeMealsID", r.ID.ToString());
                    if( bmr.Count != 0)
                        return bmr[0];
                }
            }  
            return null;
        }

        public static BasketMealsRecord GetBasketRecipeRecord( int recipeMealsID )
        {
			BasketMealsRecord bmr = instance.db.GetItemWParam<BasketMealsRecord>("BasketMealsRecord", "RecipeMealsID", recipeMealsID.ToString());
			return bmr;
        }

        public static void SaveBasketMealsRecord( BasketMealsRecord item )
        {
            instance.db.SaveItem<BasketMealsRecord>(item);
        }

        public static void DeleteBasketMealsRecord( int ID )
        {
            instance.db.DeleteItem<BasketMealsRecord>( ID );
        }

		public static IEnumerable<BasketMealsRecord> GetBasketRecords()
        {
			return instance.db.GetItems<BasketMealsRecord>();
        }
    }
}

