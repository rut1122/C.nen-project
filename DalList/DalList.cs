using DalApi;

namespace Dal
{
    internal sealed class DalList : IDal
    {
        private DalList() { }
        private readonly DalList instanse = new DalList();
        public static readonly DalList Instans
        {
            get { return this.instanse; }
        }

        // פה אנחנו אומרים: מי שמבקש את 'Product', תן לו את המימוש שכתבנו
        public IProduct Product => new ProductImplementation();

        // מי שמבקש את 'Sale', תן לו את המימוש של המכירות
        public ISale Sale => new SaleImplementation();

        // מי שמבקש את 'Customer', תן לו את המימוש של הלקוחות
        public ICustomer Customer => new CustomerImplementation();
    }
}

