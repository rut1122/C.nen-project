namespace Dal;
using DO;
using DalApi;
using System.Reflection;
using Tools;
public class CustomerImplementation :ICustomer
{
    // 1. Create - הוספת לקוח חדש

    public int Create(Customer item)
    {
        // 1. הגדרת משתנים אוטומטיים לשם הפרויקט והפונקציה
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;

        // 2. רישום לוג בתחילת הפונקציה
        LogManager.WriteToLog(project, funcName, $"Start creating new customer with ID: {item.id}");

        //     בדיקה אם כבר קיים לקוח עם אותו מזהה
        if (DataSource.Customers.Any(c => c != null && c.id == item.id))
        {
            // 3. רישום לוג במקרה של שגיאה (מקום משמעותי)
            LogManager.WriteToLog(project, funcName, $"Error: Customer with ID {item.id} already exists");
            throw new Exceptions.DalIDExists($"customer with id: {item.id} already exists");
        }

        //    // הוספת הלקוח כמו שהוא (כי ה-ID מגיע מהמשתמש)
        DataSource.Customers.Add(item);

        // 4. רישום לוג לפני ה-return (סיום הפונקציה)
        LogManager.WriteToLog(project, funcName, $"Finished successfully: Customer {item.id} added");
        return item.id;
    }



    // 2. Read - שליפת לקוח בודד
    // 2. Read - שליפת לקוח בודד לפי תנאי
    public Customer? Read(Func<Customer, bool> filter)
    {
        // הוסיפי את זה גם כאן:
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;

        LogManager.WriteToLog(project, funcName, "Start reading customer by filter");

        var result = DataSource.Customers.FirstOrDefault(c => c != null && filter(c));

        if (result != null)
            LogManager.WriteToLog(project, funcName, $"Finished successfully: Customer found by filter");
        else
            LogManager.WriteToLog(project, funcName, "Finished: No customer matched the filter");

        return result;
    }
    public Customer? Read(int id)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;

        LogManager.WriteToLog(project, funcName, $"Start reading customer with ID: {id}");

        var customer = DataSource.Customers.FirstOrDefault(c => c != null && c.id == id);

        if (customer == null)
        {
            LogManager.WriteToLog(project, funcName, $"Error: Customer with ID {id} does not exist");
            throw new Exceptions.DalIDNotExists($"id:{id} not exists");
        }

        LogManager.WriteToLog(project, funcName, $"Finished successfully: Customer {id} retrieved");
        return customer;
    }
    // 3. ReadAll - שליפת כל הלקוחות
    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;

        LogManager.WriteToLog(project, funcName, "Start reading all customers" + (filter != null ? " with filter" : ""));

        List<Customer?> result;
        if (filter == null)
            result = DataSource.Customers.ToList();
        else
            result = DataSource.Customers.Where(item => item != null && filter(item)).ToList();

        LogManager.WriteToLog(project, funcName, $"Finished successfully: {result.Count} customers retrieved");
        return result;
    }

    // 4. Update - עדכון פרטי לקוח
    public void Update(Customer item)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;

        LogManager.WriteToLog(project, funcName, $"Start updating customer with ID: {item.id}");
        int foundI = DataSource.Customers.FindIndex(c => c != null && c.id == item.id); ;

        if (foundI == -1)
        {
            LogManager.WriteToLog(project, funcName, $"Error: Customer with ID {item.id} not found for update");
            throw new Exceptions.DalIDNotExists($"id:{item.id} not exists");
        }

        DataSource.Customers[foundI] = item;
        LogManager.WriteToLog(project, funcName, $"Finished successfully: Customer {item.id} updated");
    }

    // 5. Delete - מחיקת לקוח
    public void Delete(int id)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, $"Start deleting customer with ID: {id}");
        var customerToDelete = DataSource.Customers.FirstOrDefault(c => c != null && c.id == id);
        //Customer? customerToDelete = Read(id);

        if (customerToDelete == null)
        {
            LogManager.WriteToLog(project, funcName, $"Error: Customer with ID {id} not found");
            throw new Exceptions.DalIDNotExists($"id:{id} not exists");
        }

        DataSource.Customers.Remove(customerToDelete);
        LogManager.WriteToLog(project, funcName, $"Finished successfully: Customer {id} deleted");
    }

    //IEnumerable<Customer> ICrud<Customer>.ReadAll(Func<Customer, bool>? filter = null)
    //{
    //    throw new NotImplementedException();
    //}
}
