namespace DO;
public record Sale(int id,int productId,int RequiredAmount,double salePrice,bool onlyClub,DateTime beginSale,DateTime? endSale)
{
    public Sale() : this(0,5,8,8,true,DateTime.MinValue,DateTime.MinValue) { }
}
