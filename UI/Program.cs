//namespace UI
//{
//    internal static class Program
//    {
//        /// <summary>
//        ///  The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            // To customize application configuration such as set high DPI settings or default font,
//            // see https://aka.ms/applicationconfiguration.

//            ApplicationConfiguration.Initialize();
//            Application.Run(new Form1());


//        }
//    }
//}
namespace UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // כאן הקסם קורה: הקריאה הזו מפעילה את הקוד ששלחת קודם
            // וממלאת את קבצי ה-XML בכל המוצרים (שמלות כלה, ערב וכו')
            DalTest.Initialization.Initialize();

            Application.Run(new Form1());
        }
    }
}