using System;
using DukappCore.SQLite;
using DukappCore.BL.Contracts;

namespace DukappCore.BL.Records
{
	public class RecipeType:IRecord 
    {
		public RecipeType()
        {
        }
		[PrimaryKey, AutoIncrement]
		public int ID{ get; set; }
		public int RecipeID{ get; set; }
		public int Attack{ get; set; }
		public int Cruise{ get; set; }
		public int Consolidation{ get; set;}
		public int Stabilization{ get; set; }
    }
}

