using System;
using DukappCore.SQLite;
using DukappCore.BL.Contracts;


namespace DukappCore.BL.Records
{
	public class RecipeMealsRecord : IRecord
	{
        public RecipeMealsRecord()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
		public int RecipeID{ get; set; }
		public int MealID{ get; set; }
        public int Qty{ get; set; }
	}
}

