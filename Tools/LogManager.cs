using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LogManager
    {
        private static string path = "Log";
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
            if (!Directory.Exists($@"{logDir.FullName}\{month}"))
            {
                //יוצרים תת תיקיה עבור יום
                logDir.CreateSubdirectory($@"{day}");
            }

            if (!File.Exists($@"{logDir.FullName}\{month}\{day}.txt"))
            {
                File.Create($@"{logDir.FullName}\{day}\{month}.txt").Close();
            }
        }
        //קבלת ניתוב תיקייה

        private static string GetFolderPath()
        {
           
            return $@"{path}\{month}";
        }
        //קבלת ניתוב קובץ
        private static string GetFilePath()
        {
            return $@"{GetFolderPath()}\{day}.txt";

        }
        //כתיבה ללוג
        public static void WriteToLog(string projectName, string funcName, string message)
        {
            CreateLogFile();
            string mesToWrite = $"{DateTime.Now}\t{projectName}.{funcName}:\t{message}";
            using (StreamWriter writer = new StreamWriter(GetFilePath(), true))
            {
                writer.WriteLine(mesToWrite);
            }
        }
        //מוחק את כל קבצי הלוג חוץ מהחודשיים האחרונים
        public static void ClearLog()
        {
            //אם התיקייה לא קיימת בכלל
            if (!Directory.Exists(GetFolderPath())) return;
            //אם יש תיקיה ניצור מערך של כל הקבצים בתיקייה
            string[] files= Directory.GetFiles(GetFolderPath());

            DateTime endDate = DateTime.Now.AddMonths(-2);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                //אם תאריך היווצרות הקובץ קטן מתאריך היעד
                if(fileInfo.CreationTime<endDate)
                {
                    //נמחק אותו
                    try
                    {
                        fileInfo.Delete();
                    }
                    catch
                    {
                        // אם הקובץ פתוח כרגע בתוכנית אחרת, נתעלם מהשגיאה ונמשיך
                        Console.WriteLine("deleted dont success:(");
                    }
                }

            }
        }

    }
}