// See https://aka.ms/new-console-template for more information


Store store = new Store();
store.AddProduct(new Product("1","Apple", 1.99m), 100);
store.AddProduct(new Product("2","Banana", 2.99m), 100);
store.AddProduct(new Product("3", "Orange", 3.99m), 100);
store.AddProduct(new Product("4", "Pineapple", 4.99m), 100);

List<Customer> customers = new List<Customer>();
customers.Add(new Customer("J","John", 100m));
customers.Add(new Customer("M", "Mary", 200m));
customers.Add(new Customer("P","Peter", 300m));


Console.WriteLine("Welcome to Xia Store!");
Console.WriteLine("please input your customer id");
string customerId = Console.ReadLine();
var customer =  customers.FirstOrDefault(c => c.Id == customerId);

Console.WriteLine("Here are the products we have:");
Console.WriteLine("================================");
store.ShowProducts();
Console.WriteLine("================================");


var shoppingDone = false;
Decimal totoalPrice = 0m;
List<ProductStorage> cart = new List<ProductStorage>();
while (!shoppingDone)
{
    Console.WriteLine("Please enter the product code you want to buy:");
    string productCode = Console.ReadLine();
    var product = store.Storage.FirstOrDefault(p => p.Product.Code == productCode);
    
    Console.WriteLine("Please enter the product quantity you want to buy:");
    int quantity = int.Parse(Console.ReadLine());

    totoalPrice += product.Product.Price * quantity;

    if (customer.Credit < totoalPrice) 
    {
        Console.WriteLine("Sorry, you don't have enough credit to buy this product.");
        Console.WriteLine("You can buy less or choose another product.");
        totoalPrice -= product.Product.Price * quantity;
        continue;
    }

    if (product.Count < quantity) 
    {
        Console.WriteLine("Sorry, we don't have enough product for you.");
        Console.WriteLine("You can buy less or choose another product.");
        totoalPrice -= product.Product.Price * quantity;
        continue;
    }

    cart.Add(new ProductStorage() 
    {
        Product = product.Product,
        Count = quantity
    });


    

    Console.WriteLine("Do you want to buy more? (Y/N)");
    var answer = Console.ReadLine();
    if (answer == "N")
    {
        shoppingDone = true;
    }

}
Console.WriteLine("Here is your shopping cart:");
cart.ForEach(c => 
{
   Console.WriteLine($"Product: {c.Product.Name} - Price: {c.Product.Price} - Quantity: {c.Count} -Itemprice:{c.Product.Price * c.Count}");
});

Console.WriteLine("Do you want to checkout? (Y/N)");
var checkoutAnswer = Console.ReadLine();
if (checkoutAnswer == "Y")
{
    Console.WriteLine("Here is your receipt:");
    cart.ForEach(c => 
    {
        Console.WriteLine($"{c.Product.Name}   {c.Product.Id}  {c.Product.Price}/kr   {c.Count}  {c.Product.Price * c.Count}");
    });
    Console.WriteLine("================================");
    Console.WriteLine("Total price: " + totoalPrice);
    customer.Credit -= totoalPrice;
    Console.WriteLine($"Your credit is {customer.Credit}");
    Console.WriteLine("================================");
    Console.WriteLine("Thank you for shopping with us!");
}
else
{
    Console.WriteLine("Thank you for shopping with us!");
}


cart.ForEach(c => 
{
    var product = store.Storage.FirstOrDefault(p => p.Product.Code == c.Product.Code);
    product.Count -= c.Count;
});

Console.WriteLine("Here is the updated product list:");
Console.WriteLine("================================");
store.ShowProducts();
Console.WriteLine("================================");

