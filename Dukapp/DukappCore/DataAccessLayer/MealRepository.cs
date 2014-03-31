using System;
using System.Collections.Generic;
using DukappCore.BL.Records;

namespace DukappCore.DAL
{
	public partial class DukappRepository 
	{
		public static MealRecord GetMeal(int id)
		{
			return instance.db.GetItem<MealRecord>(id);
		}

		public static IEnumerable<MealRecord> GetMealRecords ()
		{
			return instance.db.GetItems<MealRecord>();
		}

		public static int SaveMealRecord (MealRecord item)
		{
			return instance.db.SaveItem<MealRecord>(item);
		}

		public static int DeleteMealRecord(int id)
		{
			return instance.db.DeleteItem<MealRecord>(id);
		}
	}
}
