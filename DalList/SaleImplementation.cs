namespace Dal;
using DO;
using DalApi;
using System.Reflection;
using Tools;

public class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        // 1. הגדרת משתני Reflection
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;

        // 2. לוג התחלה
        LogManager.WriteToLog(project, funcName, "Start creating new sale");

        if (DataSource.Sales.Any(s => s != null && s.id == item.id))
        {
            LogManager.WriteToLog(project, funcName, $"Error: sale with id: {item.id} already exists");
            throw new Exceptions.DalIDExists($"sale with id: {item.id} already exists");
        }

        int newId = DataSource.Config.SaleCode;

        // שימוש ב-nsale במקום newItem כפי שביקשת
        Sale nsale = item with { id = newId };

        DataSource.Sales.Add(nsale);

        // 3. לוג סיום מוצלח
        LogManager.WriteToLog(project, funcName, $"Finished successfully: Sale {newId} created");
        return newId;
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, "Start reading sale by filter");

        var result = DataSource.Sales.FirstOrDefault(s => s != null && filter(s));

        LogManager.WriteToLog(project, funcName, result != null ? "Finished: Sale found" : "Finished: Sale not found");
        return result;
    }

    public Sale? Read(int id)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, $"Start reading sale with id: {id}");

        var result = DataSource.Sales.FirstOrDefault(p => p != null && p.id == id);

        LogManager.WriteToLog(project, funcName, result != null ? $"Finished: Sale {id} found" : $"Finished: Sale {id} not found");
        return result;
    }

    public IEnumerable<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, "Start reading all sales");

        IEnumerable<Sale?> result;
        if (filter == null)
            result = DataSource.Sales.Select(s => s);
        else
            result = DataSource.Sales.Where(s => s != null && filter(s));

        LogManager.WriteToLog(project, funcName, $"Finished: {result.Count()} sales retrieved");
        return result;
    }

    public void Update(Sale item)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, $"Start updating sale with id: {item.id}");

        int index = DataSource.Sales.FindIndex(s => s != null && s.id == item.id);

        if (index == -1)
        {
            LogManager.WriteToLog(project, funcName, $"Error: sale id: {item.id} not exists");
            throw new Exceptions.DalIDNotExists($"id: {item.id} not exists");
        }

        DataSource.Sales[index] = item;
        LogManager.WriteToLog(project, funcName, $"Finished successfully: Sale {item.id} updated");
    }

    public void Delete(int id)
    {
        string project = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        string funcName = MethodBase.GetCurrentMethod().Name;
        LogManager.WriteToLog(project, funcName, $"Start deleting sale with id: {id}");

        var saleToDelete = DataSource.Sales.FirstOrDefault(s => s != null && s.id == id);

        if (saleToDelete == null)
        {
            LogManager.WriteToLog(project, funcName, $"Error: sale id: {id} not exists");
            throw new Exceptions.DalIDNotExists($"id: {id} not exists");
        }

        DataSource.Sales.Remove(saleToDelete);
        LogManager.WriteToLog(project, funcName, $"Finished successfully: Sale {id} deleted");
    }
}