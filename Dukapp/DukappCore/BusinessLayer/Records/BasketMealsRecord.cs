using System;
using DukappCore.SQLite;
using DukappCore.BL.Contracts;

namespace DukappCore.BL.Records
{
    public class BasketMealsRecord : IRecord
    {
        public BasketMealsRecord()
        {
        }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int RecipeMealsID{ get; set; }
    }
}

