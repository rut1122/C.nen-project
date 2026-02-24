using Dal;
using DalApi;
using DO;
using System.Diagnostics;
using System.Reflection;
using Tools;

namespace DalTest
{
    internal class Program
    {
        private static IDal s_dal = DalApi.Factory.Get;


        //תפריט ראשי
        public static int PrintMainmenu()
        {

            Console.WriteLine("for products press 1");
            Console.WriteLine("for customers press 2");
            Console.WriteLine("for sales press 3");
            Console.WriteLine("for exit press 0");

            int choice1 = int.Parse(Console.ReadLine());
            switch (choice1)
            {
                case 1:
                    ProductMenu();
                    break;
                case 2:
                    CustomerMenu();
                    break;
                case 3:
                    SaleMenu();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("select another ");
                    break;
            }
            return choice1;
        }
        //תפריט מוצר אחרי הקשה על 1 בתפריט ראשי
        private static void ProductMenu()
        {
            Console.WriteLine($"if you want to create press 1");
            Console.WriteLine($"if you want to read press 2");
            Console.WriteLine($"if you want to read all press 3");
            Console.WriteLine($"if you want to update press 4");
            Console.WriteLine($"if you want to delete press 5");
            Console.WriteLine($"if you want to go back press 0");
            int choice2 = int.Parse(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    Read(s_dal.Product);
                    break;
                case 3:
                    ReadAll(s_dal.Product);
                    break;
                case 4:
                    UpdateProduct();
                    break;
                case 5:
                    Delete(s_dal.Product);
                    break;
                case 0:
                    PrintMainmenu();
                    break;
                default:
                    Console.WriteLine("please try again");
                    break;
            }
        }

        //תפריט לקוח אחרי הקשה על 2 בתפריט ראשי

        private static void CustomerMenu()
        {
            Console.WriteLine($"if you want to create press 1");
            Console.WriteLine($"if you want to read press 2");
            Console.WriteLine($"if you want to read all press 3");
            Console.WriteLine($"if you want to update press 4");
            Console.WriteLine($"if you want to delete press 5");
            Console.WriteLine($"if you want to go back press 0");
            int choice2 = int.Parse(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    AddCustomer();
                    break;
                case 2:
                    Read(s_dal.Customer);
                    break;
                case 3:
                    ReadAll(s_dal.Customer);
                    break;
                case 4:
                    UpdateCustomer();
                    break;
                case 5:
                    Delete(s_dal.Customer);
                    break;
                case 0:
                    PrintMainmenu();
                    break;

                default:
                    Console.WriteLine("please try again");
                    break;
            }
        }
        //תפריט מוצר אחרי הקשה על 3 בתפריט ראשי

        private static void SaleMenu()
        {
            Console.WriteLine($"if you want to create press 1");
            Console.WriteLine($"if you want to read press 2");
            Console.WriteLine($"if you want to read all press 3");
            Console.WriteLine($"if you want to update press 4");
            Console.WriteLine($"if you want to delete press 5");
            Console.WriteLine($"if you want to go back press 0");
            int choice2 = int.Parse(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    AddSale();
                    break;
                case 2:
                    Read(s_dal.Sale);
                    break;
                case 3:
                    ReadAll(s_dal.Sale);
                    break;
                case 4:
                    UpdateSale();
                    break;
                case 5:
                    Delete(s_dal.Sale);
                    break;
                case 0:
                    PrintMainmenu();
                    break;

                default:
                    Console.WriteLine("please try again");
                    break;
            }
        }
        //קליטת פרטי מוצר
        private static Product AskProduct(int code = 0)
        {
            string name;
            Category category;
            double price;
            int count;
            Console.WriteLine("enter the name of the product");
            name = Console.ReadLine();
            Console.WriteLine("enter the category: between 0 to 3");
            int cat;
            if (!int.TryParse(Console.ReadLine(), out cat)) category = 0;
            else
                category = (Category)cat;
            Console.WriteLine("enter price");
            if (!double.TryParse(Console.ReadLine(), out price)) price = 10;
            Console.WriteLine("enter count in stock");
            if (!int.TryParse(Console.ReadLine(), out count)) count = 0;
            return new Product(code, name, category, price, count);

        }
        //קליטת פרטי לקוח
        //שיניתי כדי שאם הלקוח יכניס לי משהו שגוי אז שהמערכת לא תקרוס

        private static Customer AskCustomer(int code = 0)
        {
            Console.WriteLine("enter customer id:");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id)) id = code;

            Console.WriteLine("enter name:");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("enter address:");
            string? address = Console.ReadLine();

            Console.WriteLine("enter phone:");
            int phone;
            if (!int.TryParse(Console.ReadLine(), out phone)) phone = 0;

            return new Customer(id, name, address, phone);
        }

        //private static Customer AskCustomer(int code = 0)
        //{
        //    Console.WriteLine("enter customer");
        //    int id = int.Parse(Console.ReadLine());
        //    string name = Console.ReadLine();
        //    string? adress = Console.ReadLine();
        //    int phone = int.Parse(Console.ReadLine());
        //    return new Customer(id, name, adress, phone);


        //}
        //קליטת פרטי מבצע
        //כנ"ל
        private static Sale AskSale(int code = 0)
        {

            int id = code;
            if (code == 0)
            {
                Console.WriteLine("enter sale id:");
                int.TryParse(Console.ReadLine(), out id);
            }

            Console.WriteLine("enter product id for sale:");
            int productId;
            if (!int.TryParse(Console.ReadLine(), out productId)) productId = 0;

            Console.WriteLine("enter requier amount:");
            int requiredAmount;
            if (!int.TryParse(Console.ReadLine(), out requiredAmount)) requiredAmount = 1;

            Console.WriteLine("enter sale price:");
            double salePrice;
            if (!double.TryParse(Console.ReadLine(), out salePrice)) salePrice = 0;

            Console.WriteLine("only for club? (true/false):");
            bool onlyClub;
            if (!bool.TryParse(Console.ReadLine(), out onlyClub)) onlyClub = false;

            Console.WriteLine("enter begining date");
            DateTime beginSale;
            if (!DateTime.TryParse(Console.ReadLine(), out beginSale)) beginSale = DateTime.Now;

            Console.WriteLine("enter end date(optional)");
            string endInput = Console.ReadLine() ?? "";
            DateTime? endSale = null;
            DateTime tempEndDate;
            if (DateTime.TryParse(endInput, out tempEndDate))
            {
                endSale = tempEndDate;
            }

            // החזרת האובייקט החדש
            return new Sale(id, productId, requiredAmount, salePrice, onlyClub, beginSale, endSale);
        }





        //    int id = int.Parse(Console.ReadLine());
        //    int productId = int.Parse(Console.ReadLine());
        //    int RequiredAmount = int.Parse(Console.ReadLine());
        //    double salePrice = double.Parse(Console.ReadLine());
        //    bool onlyClub = bool.Parse(Console.ReadLine());
        //    DateTime beginSale = DateTime.Parse(Console.ReadLine());
        //    DateTime? endSale = DateTime.Parse(Console.ReadLine());
        //    return new Sale(id, productId, RequiredAmount, salePrice, onlyClub, beginSale, endSale);
        //}

        private static void AddProduct(int code = 0)
        {

            try
            {
                Console.WriteLine("add new product");
                // שליחת הקוד לפונקציית הקליטה
                Product newProduct = AskProduct(code);

                // יצירת המוצר
                int generatedId = s_dal.Product.Create(newProduct);

                Console.WriteLine($"adding product success, product id: {generatedId}");
            }
            catch (Exception ex)
            {
                // למשל אם המזהה כבר קיים
                LogManager.WriteToLog("DalTest", "AddProduct", ex.Message);
                throw new Exceptions.DalIDExists("");
            }
        }
        private static void AddCustomer(int code = 0)
        {
            try
            {
                Console.WriteLine(" add new customer ");
                Customer newCustomer = AskCustomer(code);
                s_dal.Customer.Create(newCustomer);
                Console.WriteLine("adding customer success.");
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog("DalTest", "AddCustomer", ex.Message);
                Console.WriteLine($"error: {ex.Message}");
            }
        }
        private static void AddSale(int code = 0)
        {
            try
            {
                Console.WriteLine("add new sale");
                Sale newSale = AskSale(code);
                s_dal.Sale.Create(newSale);
                Console.WriteLine("adding sale success.");
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog("DalTest", "AddSale", ex.Message);
                Console.WriteLine($"error: {ex.Message}");

            }
        }
        private static void UpdateProduct(int code = 0)
        {
            try
            {
                Console.Write("enter product id to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id)) return;

                // וידוא שהמוצר אכן קיים לפני שנבקש פרטים חדשים
                var existing = s_dal.Product.Read(id);
                if (existing == null)
                    throw new Exception($"product  {id} doesnt exists.");

                Console.WriteLine($"product datails : {existing}");

                // קריאה ל-AskProduct עם ה-ID הקיים כדי לשמור עליו בעדכון
                Product updatedProduct = AskProduct(id);
                s_dal.Product.Update(updatedProduct);

                Console.WriteLine("product update success.");
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog("DalTest", "UpdateProduct", ex.Message);
                Console.WriteLine($"error {ex.Message}");

            }

        }
        private static void UpdateCustomer(int code = 0)
        {
            int id = -1; // הגדרת המשתנה מחוץ ל-try כדי שיהיה נגיש ב-catch
            try
            {
                Console.Write("Enter Customer ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out id)) return;

                Customer? existing = s_dal.Customer.Read(id);
                if (existing == null)
                    throw new Exception($"Customer with ID {id} was not found.");

                Customer updatedCustomer = AskCustomer(id);
                s_dal.Customer.Update(updatedCustomer);
                Console.WriteLine("Customer updated successfully.");
            }
            catch (Exception ex)
            {
                // חשוב: הלוג לפני ה-throw!
                LogManager.WriteToLog("DalTest", "UpdateCustomer", ex.Message);
                throw new Exceptions.DalIDNotExists($"id: {id} not exists");
            }
        }

        private static void Read<T>(ICrud<T> icrud)
        {
            int id = -1;
            try
            {
                Console.WriteLine("enter id to read");
                id = int.Parse(Console.ReadLine());
                var item = icrud.Read(id);
                if (item != null)
                    Console.WriteLine(item);
                else
                    Console.WriteLine("id not found");
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog("DalTest", "Read", ex.Message);
                throw new Exceptions.DalIDNotExists($"id: {id} not exists");
            }
        }
        private static void UpdateSale(int code = 0)
        {
            int id = 0;
            try
            {
                Console.Write("Enter Sale ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }

                Sale? existing = s_dal.Sale.Read(id);

                if (existing == null)
                {
                    throw new Exception($"Sale with ID {id} was not found.");
                }

                Console.WriteLine($"Sale details found: {existing}");

                Sale updatedSale = AskSale(id);
                s_dal.Sale.Update(updatedSale);

                Console.WriteLine("Sale data updated successfully.");
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog("DalTest", "UpdateSale", ex.Message);
                throw new Exceptions.DalIDNotExists($"id: {id} not exists");

            }
        }

        private static void ReadAll<T>(ICrud<T> icrud)
        {
            var list = icrud.ReadAll();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        
        private static void Delete<T>(ICrud<T> icrud)
        {
            int id = -1;
            try
            {
                Console.WriteLine("enter id to delete");
                id = int.Parse(Console.ReadLine());
                icrud.Delete(id);

                Console.WriteLine("deleted successfully");
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog("DalTest", "Delete", ex.Message);
                throw new Exceptions.DalIDNotExists($"id: {id} not exists");
            }
        }
        private static void PrintSubMenue()
        {

        }
        static void Main(string[] args)
        {
            Initialization.Initialize();
            PrintMainmenu();

        }
    }
}



