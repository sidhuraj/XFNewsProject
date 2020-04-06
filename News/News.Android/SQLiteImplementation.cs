using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using News.Droid;
using News.SQLite;
using SQLite;
using Xamarin.Forms;


[assembly:Dependency(typeof(SQLiteImplementation))]
namespace News.Droid
{
    public class SQLiteImplementation : SQLiteConn
    {
        public SQLiteConnection GetConnection()
        {
            var Filename = "Bookmark.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, Filename);
            var sqlitConnection = new SQLiteConnection(path);
            return sqlitConnection;

        }
    }
}