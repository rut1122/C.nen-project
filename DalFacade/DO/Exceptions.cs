namespace DO;

public class Exceptions
{
    [Serializable]
    // ID כבר קיים
    public class DalIDExists:Exception
    {
        public DalIDExists(string message) : base(message) { }
    }

    [Serializable]
    //ID לא קיים
    public class DalIDNotExists:Exception
    {
        public DalIDNotExists(string message) : base(message) { }

    }
}
