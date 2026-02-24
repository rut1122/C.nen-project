using DO;
using DalApi;
namespace DalTest;

public class Initialization
{
    private static IDal s_dal;
    private static List<int> ProductsCodes = new List<int>();
    //יצירת רשימת מוצרים

    public static void CreateProduct()
    {

        ProductsCodes.Add(s_dal.Product.Create(new Product(0, "agdgd", Category.EveningDresses, 40.1, 300)));
        ProductsCodes.Add(s_dal.Product.Create(new Product(1, "bbbbb", Category.Accessories, 50.1, 400)));
        ProductsCodes.Add(s_dal.Product.Create(new Product(2, "ccccc", Category.WeddingDresses, 90.1, 500)));
        ProductsCodes.Add(s_dal.Product.Create(new Product(3, "ddddd", Category.FlowerGirlDresses, 80.1, 600)));
        ProductsCodes.Add(s_dal.Product.Create(new Product(4, "eeeee", Category.GirlsDresses, 77.1, 700)));

    }
    public static void CreateCustomer()
    {
        s_dal.Customer.Create(new Customer(101, "Alice Johnson", "alice@example.com", 0501234567));
        s_dal.Customer.Create(new Customer(102, "Bob Smith", "bob.s@workmail.com", 0529876543));
        s_dal.Customer.Create(new Customer(103, "Charlie Brown", "charlie@gmail.com", 0541112223));
        s_dal.Customer.Create(new Customer(104, "Diana Prince", "diana@themyscira.com", 0534445556));
        s_dal.Customer.Create(new Customer(105, "Edward Norton", "edward@cinema.com", 0587778889));
    }

    public static void CreateSale()
    {
        s_dal.Sale.Create(new Sale(10, 101, 5, 150.5, true, DateTime.Now.AddDays(14), DateTime.Now.AddDays(-1)));
        s_dal.Sale.Create(new Sale(11, 102, 2, 89.9, false, DateTime.Now.AddDays(7), DateTime.Now.AddHours(-5)));
        s_dal.Sale.Create(new Sale(12, 103, 10, 550.0, true, DateTime.Now.AddMonths(1), DateTime.Now.AddDays(-3)));
        s_dal.Sale.Create(new Sale(13, 104, 1, 45.0, true, DateTime.Now.AddDays(3), DateTime.Now));
        s_dal.Sale.Create(new Sale(14, 105, 3, 299.99, false, DateTime.Now.AddDays(21), DateTime.Now.AddDays(-10)));
    }
    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;
        CreateCustomer();
        CreateSale();
        CreateProduct();


    }
}






