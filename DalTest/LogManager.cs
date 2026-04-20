using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalTest
{
    public static class LogManager
    {
        static int day = DateTime.Now.Day;
        static int month = DateTime.Now.Month;
        private static void CreateLogFile()
        {
            DirectoryInfo logDir = Directory.CreateDirectory(path);


            //בדיקה האם קיימת תיקיה לשנה הנוכחית
            if (!Directory.Exists($@"{logDir.FullName}\{month}"))
            {
                //יוצרים תת תיקיה עבור השנה
                logDir.CreateSubdirectory(month.ToString());
            }
            //בדיקה האם קיימת תיקיה לחודש הנוכחי
            if (!Directory.Exists($@"{logDir.FullName}\\{month}"))
            {
                //יוצרים תת תיקיה עבור השנה
                logDir.CreateSubdirectory($@"\{month}");
            }

            if (!File.Exists($@"{logDir.FullName}\\{month}\{day}.txt"))
            {
                File.Create($@"{logDir.FullName}\\{month}\{day}.txt").Close();
            }
        }

        private static string path = "Log";


        //קבלת ניתוב התיקיה
        private static string GetFolderPath()
        {
            return $@"{path}\{month}";
        }
        //קבלת ניתוב הקובץ הנוכחי
        private static string GetFilePath()
        {
            return $@"{GetFolderPath()}\{day}.txt";
        }
        //כתיבה ללוג
        public static void WriteToLog(string projectname, string funcname, string message)
        {
            CreateLogFile();
            string mesToWhrite = $"{DateTime.Now}\t{projectname}.{funcname}:\t{message}";
            using (StreamWriter writer = new StreamWriter(GetFilePath(), true))
            {
                writer.WriteLine(mesToWhrite);
            }
        }
        //מוחק את התיקיה חוץ מהחודשיים האחרונים
        public static void CleanLog()
        {
            //אם התיקיה לא קיימת
            if (!Directory.Exists(GetFolderPath())) return;
            //אם יש תיקיה ניצור מערך של כל הקבצים בתיקיה
            string[] files = Directory.GetFiles(GetFolderPath());

            DateTime endDate = DateTime.Now.AddMonths(-2);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                //אם זמן ההווצרות שלו קטן מהתאריך היעד
                if (fileInfo.CreationTime < endDate)
                {
                    //נמחק אותו
                    try
                    {
                        fileInfo.Delete();
                    }
                    catch
                    {
                        // אם הקובץ פתוח כרגע בתוכנית אחרת, נתעלם מהשגיאה ונמשיך}
                    }
                }

            }
        }
    }
}
