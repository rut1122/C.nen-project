using System;
using System.IO;

namespace DalTest
{
    public static class LogManager
    {
        private static string path = "Log";

        // שימי לב: השתמשתי במאפיינים (Properties) כדי שהתאריך תמיד יהיה מעודכן לרגע הכתיבה
        static int day => DateTime.Now.Day;
        static int month => DateTime.Now.Month;

        private static void CreateLogFile()
        {
            // 1. בונים את הנתיב המלא לתיקייה שצריכה להכיל את הקובץ
            string folderPath = GetFolderPath();

            // 2. הפקודה הזו יוצרת את כל עץ התיקיות (גם Log וגם את תיקיית החודש) במכה אחת בבטחה
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // 3. יצירת הקובץ אם הוא לא קיים
            string filePath = GetFilePath();
            if (!File.Exists(filePath))
            {
                // שימוש ב-using כאן מבטיח שהקובץ נסגר מיד ולא נשאר "תפוס" בזיכרון
                using (File.Create(filePath)) { }
            }
        }

        // שימוש ב-Path.Combine הוא חובה כדי למנוע טעויות של סלאשים (/)
        private static string GetFolderPath() =>
            Path.Combine(AppContext.BaseDirectory, path, month.ToString());

        private static string GetFilePath() =>
            Path.Combine(GetFolderPath(), $"{day}.txt");

        public static void WriteToLog(string projectname, string funcname, string message)
        {
            // אנחנו עוטפים הכל ב-Try Catch כדי שהלוג בחיים לא יפיל את התוכנית הראשית
            try
            {
                CreateLogFile();

                string filePath = GetFilePath();
                string mesToWrite = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}\t{projectname}.{funcname}:\t{message}";

                // StreamWriter עם true אומר לו להוסיף לסוף הקובץ (Append) ולא למחוק מה שהיה
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(mesToWrite);
                }
            }
            catch (Exception ex)
            {
                // במקרה של תקלה בלוג, מדפיסים למסך כדי שתדעי, אבל לא קורסים
                Console.WriteLine($"[Internal Log Error]: {ex.Message}");
            }
        }
    }
}