namespace Logopeda.ORM
{
    using Entities;
    using Helpers;
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DBRepository
    {
        private SQLiteConnection dbConnection;
        private string dbPath;

        public DBRepository()
        {
            dbPath = Path.Combine(FileAccessHelper.DB_PATH, FileAccessHelper.DB_FILE);
            dbConnection = new SQLiteConnection(dbPath);
        }

        public IEnumerable<string> GetAllWords()
        {
            var result = dbConnection.Table<Words>().ToList();

            return result.Select(w => w.Word).OrderBy(o => Guid.NewGuid()).Take(150);
        }

        public IEnumerable<string> GetGroup(string groupName)
        {
            var result = from w in dbConnection.Table<Words>()
                         from g in dbConnection.Table<Groups>()
                         .Where(g => g.Id == w.GroupId && g.Description == groupName)
                         select w.Word;

            return result;
        }

        public IEnumerable<Poems> GetPoems()
        {
            var result = dbConnection.Table<Poems>().ToList();

            return result;
        }

        public IEnumerable<string> GetAllSentences()
        {
            var result = dbConnection.Table<Sentences>().ToList().OrderBy(o => Guid.NewGuid()).Take(10);

            return result.Select(s => s.Sentence);
        }

        public List<string> GetGroupNames()
        {
            var result = dbConnection.Table<Groups>().ToList().OrderBy(x => x.Id);

            return result.Select(x => x.Description).ToList();
        }

        public List<string> GetSubgroupNames()
        {
            var result = dbConnection.Table<Subgroups>().ToList().OrderBy(x => x.Id);

            return result.Select(x => x.Description).ToList();
        }

        public int Save<T>(T item)
        {
            try
            {
                int result = dbConnection.Insert(item);

                return result;
            }
            catch (SQLiteException ex)
            {
                return ex.HResult;
            }
        }
    }
}