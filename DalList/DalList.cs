using DalApi;

namespace Dal
{
    internal sealed class DalList : IDal
    {

        private static readonly DalList instance = new DalList();

        private DalList() { }

        public static IDal Instance
        {
            get { return instance; }
        }

        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();
        public ICustomer Customer => new CustomerImplementation();
    }
}