public class ProductStorage 
{
    public required Product Product { get; set; }
    public int Count { get; set; }
}

public class Store {
    public List<ProductStorage> Storage { get; set; }
    

    public Store() 
    {
        Storage = new List<ProductStorage>();

    }

    public void AddProduct(Product product, int count)
     {
        Storage.Add(new ProductStorage() 
        {
            Product = product,
            Count = count
        });
    }
    public void ShowProducts() 
    {
        foreach (var product in Storage)
         {
            Console.WriteLine($"{product.Product.Code} - Product: {product.Product.Name} - Price: {product.Product.Price} - count: {product.Count}");
        }
    }
}