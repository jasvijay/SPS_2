using Xamarin.Forms;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace SPS_2
{
    public class JobDatabase
    {
        static object locker=new object();
        SQLiteConnection database;
        public JobDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Jobcell>();
            Jobcell job = new Jobcell();
            job.zone = "1";
            job.Name = "name1";
            job.Jobs = "job1";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "1";
            job.Name = "name2";
            job.Jobs = "job2";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "1";
            job.Name = "name3";
            job.Jobs = "job3";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "1";
            job.Name = "name4";
            job.Jobs = "job4";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "2";
            job.Name = "name1";
            job.Jobs = "job1";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "2";
            job.Name = "name2";
            job.Jobs = "job2";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "2";
            job.Name = "name3";
            job.Jobs = "job3";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "2";
            job.Name = "name4";
            job.Jobs = "job4";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "3";
            job.Name = "name1";
            job.Jobs = "job1";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "3";
            job.Name = "name2";
            job.Jobs = "job2";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "3";
            job.Name = "name3";
            job.Jobs = "job3";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "3";
            job.Name = "name4";
            job.Jobs = "job4";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "4";
            job.Name = "name1";
            job.Jobs = "job1";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "4";
            job.Name = "name2";
            job.Jobs = "job2";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "4";
            job.Name = "name3";
            job.Jobs = "job3";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "4";
            job.Name = "name4";
            job.Jobs = "job4";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "5";
            job.Name = "name1";
            job.Jobs = "job1";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "5";
            job.Name = "name2";
            job.Jobs = "job2";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "5";
            job.Name = "name3";
            job.Jobs = "job3";
            App.Database.SaveItem(job);
            job = new Jobcell();
            job.zone = "5";
            job.Name = "name4";
            job.Jobs = "job4";
            App.Database.SaveItem(job);
        }
        public IEnumerable<Jobcell>GetItems(string zone)
        {
            lock (locker) { return (from i in database.Table<Jobcell>() select i).ToList(); }
        }
        public int SaveItem(Jobcell item)
        {
            lock (locker)
            {
                if(item.ID!=0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }
        public IEnumerable<Jobcell> GetItemsNotDone()
        {
            return database.Query<Jobcell>("SELECT * FROM [Jobcell] WHERE [Done] = 0");
        }
        public Jobcell GetItem(string zone)
        {
            return database.Table<Jobcell>().FirstOrDefault(x => x.zone == zone);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<JobItem>(id);
        }

    }
}