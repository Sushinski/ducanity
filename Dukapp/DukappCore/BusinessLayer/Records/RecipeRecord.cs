using System;
using DukappCore.SQLite;
using DukappCore.BL.Contracts;

namespace DukappCore.BL.Records
{
    public enum RecipeSrcType
    {
        All = 0,
        Favourites=1,
        Snacks=2,
        Salads=3,
        FirstCourses=4,
        SecondCourses=5,
        Drinks = 6,
        Sauces = 7, 
        Bakery = 8
    }
	public class RecipeRecord : IRecord
	{
		public RecipeRecord () 
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string RecipeName { get; set; }
		public string RecipeDesc { get; set; }
		public int RecipeType { get; set; }
        public int isFavourite { get; set; }
	}
}

