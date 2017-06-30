using SamenSterkOffline.Models;
using SamenSterkOffline.Views;
using SQLite;
using System;
using System.IO;
using System.Windows.Forms;


namespace SamenSterkOffline
{
	internal static class Program
	{
		public const string DB_FULLNAME = "TaskDatabase.sqlite";
		public static string STARTUP_PATH = Path.Combine(Application.StartupPath, DB_FULLNAME);
		public static string DB_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Samen Sterk", "OfflineWeekplanner");
        public static string DB_FULLPATH = Path.Combine(DB_PATH, DB_FULLNAME);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(STARTUP_PATH) == false)
			{
				using (SQLiteConnection db = new SQLiteConnection(STARTUP_PATH))
				{
					db.CreateTable<Task>();
					db.CreateTable<RepeatingTask>();
					db.CreateTable<Subject>();
					db.CreateTable<Grade>();
					db.CreateTable<Appointment>();
				}
			}

			Application.Run(new Shedule());
		}
	}
}