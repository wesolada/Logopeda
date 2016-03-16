namespace Logopeda.Helpers
{
    using Android.App;
    using System;
    using System.IO;

    public class FileAccessHelper
    {
        public static readonly string DB_FILE = "MyDataBase.db";
        public static readonly string DB_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        private static string dbLocalPath;

        public static void InitLocalDB()
        {
            dbLocalPath = Path.Combine(DB_PATH, DB_FILE);

            if (!File.Exists(dbLocalPath))
            {
                CopyMainDB();
            }
        }

        private static void CopyMainDB()
        {
            using (var br = new BinaryReader(Application.Context.Assets.Open(DB_FILE)))
            {
                using (var bw = new BinaryWriter(new FileStream(dbLocalPath, FileMode.Create)))
                {
                    byte[] buffer = new byte[2048];
                    int length = 0;
                    while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, length);
                    }
                }
            }
        }
    }
}