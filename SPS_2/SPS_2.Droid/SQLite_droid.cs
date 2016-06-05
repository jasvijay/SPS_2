using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using SPS_2.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_droid))]
// ...
namespace SPS_2.Droid
{
   
public class SQLite_droid : ISQLite
    {
            public SQLite_droid() { }
            public SQLite.SQLiteConnection GetConnection()
            {
                var sqliteFilename = "jobSQLite.db3";

                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                var s = Forms.Context.Resources.OpenRawResource(Resource.Raw.jobSQLite);  // RESOURCE NAME ###

                // create a write stream
                FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                // write to the stream
                ReadWriteStream(s, writeStream);
            }
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
            }
        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }

    }
    }