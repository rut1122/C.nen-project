namespace Dal;
using DO;
using DalApi;
using System.Reflection;
using Tools;

public class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;

        LogManager.WriteToLog(project, funcName, $"Start creating new product");

        if (DataSource.Products.Any(p => p != null && p.id == item.id))
        {
            LogManager.WriteToLog(project, funcName, $"Error: product with id: {item.id} already exists");
            throw new Exception($"product with id: {item.id} already exists");
        }

        int newId = DataSource.Config.ProductCode;
        // שימוש ב-nproduct כפי שביקשת
        Product nproduct = item with { id = newId };
        DataSource.Products.Add(nproduct);

        LogManager.WriteToLog(project, funcName, $"Finished successfully: Product {newId} created");
        return newId;
    }

    public Product? Read(Func<Product, bool> filter)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, "Start reading product by filter");

        var result = DataSource.Products.FirstOrDefault(p => p != null && filter(p));

        LogManager.WriteToLog(project, funcName, result != null ? "Finished: Product found" : "Finished: Product not found");
        return result;
    }

    public Product? Read(int id)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, $"Start reading product with id: {id}");

        var result = DataSource.Products.FirstOrDefault(p => p != null && p.id == id);

        LogManager.WriteToLog(project, funcName, result != null ? $"Finished: Product {id} found" : $"Finished: Product {id} not found");
        return result;
    }

    public IEnumerable<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, "Start reading all products");

        IEnumerable<Product?> result;
        if (filter == null)
            result = DataSource.Products.Select(p => p);
        else
            result = DataSource.Products.Where(p => p != null && filter(p));

        LogManager.WriteToLog(project, funcName, $"Finished: {result.Count()} products retrieved");
        return result;
    }

    public void Update(Product item)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, $"Start updating product with id: {item.id}");

        int index = DataSource.Products.FindIndex(p => p != null && p.id == item.id);

        if (index == -1)
        {
            LogManager.WriteToLog(project, funcName, $"Error: id: {item.id} not exists");
            throw new Exception($"id: {item.id} not exists");
        }

        DataSource.Products[index] = item;
        LogManager.WriteToLog(project, funcName, $"Finished successfully: Product {item.id} updated");
    }

    public void Delete(int id)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, $"Start deleting product with id: {id}");

        var item = DataSource.Products.FirstOrDefault(p => p != null && p.id == id);

        if (item == null)
        {
            LogManager.WriteToLog(project, funcName, $"Error: id: {id} not exists");
            throw new Exception($"id: {id} not exists");
        }

        DataSource.Products.Remove(item);
        LogManager.WriteToLog(project, funcName, $"Finished successfully: Product {id} deleted");
    }
}