public class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<ProductStorage> Cart { get; set; }
    public Decimal Credit { get; set; }
    
    public Customer(string id, string name, Decimal credit)
    {
        Id = id;
        Name = name;
        Credit = credit;
    }


    

}