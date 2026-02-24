namespace DO;

public record Customer(int id, string name, string? adress, int phone)
{
    public Customer() : this(2, "tamar", "gefen", 053416989) { }
}

