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
        public const string DB_NAME = "TaskDatabase";
        public const string DB_FULLNAME = "TaskDatabase.sqlite";
        public static string DB_PATH = Application.StartupPath + DB_FULLNAME;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(DB_PATH) == false)
            {
                using (SQLiteConnection db = new SQLiteConnection(DB_PATH))
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