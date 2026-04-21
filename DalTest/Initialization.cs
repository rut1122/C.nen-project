using DO;
using DalApi;
namespace DalTest;

public class Initialization
{
    private static IDal s_dal;
    private static List<int> ProductsCodes = new List<int>();

    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;

        // סדר קריטי: קודם מוצרים כדי שיהיו IDs ברשימה, אז לקוחות ומבצעים
        CreateProduct();
        CreateCustomer();
        CreateSale();
    }

    public static void CreateProduct()
    {
        int id;

        // --- שמלות כלה (WeddingDresses) ---
        id = s_dal.Product.Create(new Product(0, "שמלת כלה תחרה ופנינים ", Category.WeddingDresses, 3500.0, 5));
        Console.WriteLine($"ID: {id} | מוצר: שמלת כלה תחרה");
        ProductsCodes.Add(id);

        id = s_dal.Product.Create(new Product(0, "שמלת כלה מלכותית שובל ארוך", Category.WeddingDresses, 4200.0, 3));
        Console.WriteLine($"ID: {id} | מוצר: שמלת כלה מלכותית");
        ProductsCodes.Add(id);

        // --- שמלות ערב (EveningDresses) ---
        id = s_dal.Product.Create(new Product(0, "שמלת ערב קטיפה כחול לילה", Category.EveningDresses, 950.0, 4));
        Console.WriteLine($"ID: {id} | מוצר: שמלת ערב קטיפה");
        ProductsCodes.Add(id);

        id = s_dal.Product.Create(new Product(0, "שמלת ערב שיפון ורוד עתיק", Category.EveningDresses, 850.0, 6));
        Console.WriteLine($"ID: {id} | מוצר: שמלת ערב שיפון");
        ProductsCodes.Add(id);

        id = s_dal.Product.Create(new Product(0, "שמלת אם הכלה סאטן מוזהב", Category.EveningDresses, 1200.0, 2));
        Console.WriteLine($"ID: {id} | מוצר: שמלת אם הכלה");
        ProductsCodes.Add(id);

        // --- שמלות שושבינות (FlowerGirlDresses) ---
        id = s_dal.Product.Create(new Product(0, "שמלת שושבינה טול נפוחה שמנת", Category.FlowerGirlDresses, 450.0, 10));
        Console.WriteLine($"ID: {id} | מוצר: שמלת שושבינה טול");
        ProductsCodes.Add(id);

        id = s_dal.Product.Create(new Product(0, "שמלת ילדות תחרה וסרט", Category.FlowerGirlDresses, 400.0, 8));
        Console.WriteLine($"ID: {id} | מוצר: שמלת ילדות תחרה");
        ProductsCodes.Add(id);

        // --- שמלות נערות (GirlsDresses) ---
        id = s_dal.Product.Create(new Product(0, "שמלת בת מצווה לבנה", Category.GirlsDresses, 600.0, 5));
        Console.WriteLine($"ID: {id} | מוצר: שמלת בת מצווה");
        ProductsCodes.Add(id);

        id = s_dal.Product.Create(new Product(0, "שמלת אירוע נערות שכבות משי", Category.GirlsDresses, 700.0, 4));
        Console.WriteLine($"ID: {id} | מוצר: שמלת נערות משי");
        ProductsCodes.Add(id);

        // --- אביזרים (Accessories) ---
        id = s_dal.Product.Create(new Product(0, "הינומת כלה תחרה עבודת יד", Category.Accessories, 300.0, 15));
        Console.WriteLine($"ID: {id} | מוצר: הינומת כלה");
        ProductsCodes.Add(id);

        id = s_dal.Product.Create(new Product(0, "שכמייה פרווה חורפית", Category.Accessories, 250.0, 10));
        Console.WriteLine($"ID: {id} | מוצר: שכמייה פרווה");
        ProductsCodes.Add(id);

        id = s_dal.Product.Create(new Product(0, "קשת פנינים יוקרתית לשיער", Category.Accessories, 120.0, 20));
        Console.WriteLine($"ID: {id} | מוצר: קשת פנינים");
        ProductsCodes.Add(id);

        Console.WriteLine("--- Initialization Finished Successfully ---");
    }

    public static void CreateCustomer()
    {
        s_dal.Customer.Create(new Customer(101, "Alice Johnson", "alice@example.com", 0501234567)); // מועדון
        s_dal.Customer.Create(new Customer(102, "Bob Smith", "bob.s@workmail.com", 0529876543));
        s_dal.Customer.Create(new Customer(103, "Charlie Brown", "charlie@gmail.com", 0541112223));
    }

    public static void CreateSale()
    {
        DateTime start = DateTime.Now.AddDays(-1);
        DateTime end = DateTime.Now.AddYears(1);

        // 1. שמלת כלה תחרה: מועדון
        s_dal.Sale.Create(new Sale(0, ProductsCodes[0], 1, 2900.0, true, start, end));

        // 2. שמלת ערב קטיפה: 2 ב-800 כל אחת
        s_dal.Sale.Create(new Sale(0, ProductsCodes[2], 2, 800.0, false, start, end));

        // 3. שמלת שושבינה טול: 3 ב-350 כל אחת
        s_dal.Sale.Create(new Sale(0, ProductsCodes[5], 3, 350.0, false, start, end));

        // 4. קשת פנינים: 2 ב-90 כל אחת
        s_dal.Sale.Create(new Sale(0, ProductsCodes[11], 2, 90.0, false, start, end));

        Console.WriteLine("--- Sales Initialized with safe dates ---");
    }
}