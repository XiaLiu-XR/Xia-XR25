public class Product
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
   

    
    
    public Product(string code,string name, decimal price) 
   
    {
        Code = code;
        Id = Guid.NewGuid().ToString();
        Name = name;
        Price = price;
       
    }


}


