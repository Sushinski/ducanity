using System;
using System.Collections.Generic;
using System.IO;
using DukappCore.BL;

namespace DukappCore.DAL {
	/// <summary>
	/// The repository is responsible for providing an abstraction to actual data storage mechanism
	/// whether it be SQLite, XML or some other method
	/// </summary>
	public partial class DukappRepository 
	{
		DukappCore.DL.DukappDatabase db = null;
		protected static string dbLocation;		
        protected static DukappRepository instance;
		protected static string sqliteFilename;

		static DukappRepository ()
		{
			instance = new DukappRepository();
		}

		protected DukappRepository()
		{
			sqliteFilename = "DukappDB.db3";
			// set the db location
			dbLocation = DatabaseFilePath;
		}

        public static void Open()
        {
            // instantiate the database
            instance.db = new DukappCore.DL.DukappDatabase(dbLocation); 

        }

		public static string DatabaseFilePath 
		{
			get 
			{ 

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
#else
#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
#endif		
				return path;	
			}
		}
	}
}
