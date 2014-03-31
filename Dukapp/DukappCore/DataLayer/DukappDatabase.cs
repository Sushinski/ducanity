using System;
using System.Linq;
using System.Collections.Generic;
using DukappCore.SQLite;
using DukappCore.BL.Records;
using DukappCore.BL.Attributes;

namespace DukappCore.DL {

	public class DukappDatabase : SQLiteConnection {
		static object locker = new object ();

		public DukappDatabase (string path) : base (path)
		{
		}

		public IEnumerable<T> GetItems<T> () where T : BL.Contracts.IRecord, new ()
		{
			lock (locker) 
			{
				return (from i in Table<T> () select i).ToList();
			}
		}

        public List<T> GetItemsWParam<T> ( string table_name, string field_name, string param ) where T : BL.Contracts.IRecord, new ()
        {
            string qry = "select * from " + table_name;
            if (field_name != "" && param != "")
                qry += " where " + field_name + " = " + param;
            qry += ";";
            lock (locker)
            {
				return Query<T>(qry).ToList();
            }
        }

		public T GetItemWParam<T>( string table_name, string field_name, string param ) where T : BL.Contracts.IRecord, new ()
		{
			string qry = "select * from " + table_name;
			if (field_name != "" && param != "")
				qry += " where " + field_name + " = " + param;
			qry += ";";
			lock (locker)
			{
				return Query<T>(qry).FirstOrDefault();
			}
		}

		public T GetItem<T> (int id) where T : BL.Contracts.IRecord, new ()
		{
			lock (locker) 
			{
				return (from i in Table<T> ()
				        where i.ID == id
				        select i).FirstOrDefault ();
			}
		}

		public int SaveItem<T> (T item) where T : BL.Contracts.IRecord
		{
			lock (locker) 
			{
				if (item.ID != 0) 
				{
					Update (item);
					return item.ID;
				} 
				else 
				{
					return Insert (item);
				}
			}
		}

		public int DeleteItem<T>(int id) where T : BL.Contracts.IRecord, new ()
		{
			lock (locker) 
			{
				return Delete<T> (id);
			}
		}

        public int DeleteAllRecords<T>()
        {
            lock (locker)
            {
                return DeleteAll<T>();
            }
        }

        public List<T> GetForeignItems<T> (string key_name, string rel_table_name, string rel_field_name, Object value) where T : BL.Contracts.IRecord, new ()
        {
            List<int> keys;
            List<T> result = new List<T>();
            lock (locker)
            {
                //TODO сделать через рефлексию
                keys = Query<int>("select ? from ? where ? = ?", new object[] { key_name, rel_table_name, rel_field_name, value });
                if (keys.Count() != 0)
                {
                    foreach (int key in keys)
                    {
                        result.Add(GetItem<T>(key));
                    }
                }
                return result;
            }
        }

	}
}
