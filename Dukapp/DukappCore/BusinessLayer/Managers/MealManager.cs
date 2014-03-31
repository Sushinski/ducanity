using System;
using DukappCore.BL.Records;
using DukappCore.DAL;

namespace DukappCore.BL.Managers
{
    public static class MealManager
    {
        public static MealRecord GetMeal( int mealID )
        {
            return  DukappRepository.GetMeal(mealID);
        }
    }
}