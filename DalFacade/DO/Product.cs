namespace DO;

public record Product(int id, string productName, Category ?productCategory , double price, int amount)
{
   
    public Product() : this(4,"dress",Category.WeddingDresses,1200,15) { }
}

