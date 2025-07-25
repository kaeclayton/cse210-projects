public class Product
{
    private string _name;
    private int _productID;
    private double _price;
    private int _quantity;

    public Product(string name, int productID, double price, int quantity)
    {
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }
    public double CalculateTotal()
    {
        return _quantity * _price;
    }

    public string Name => _name;
    public int ProductID => _productID;
    public double Price => _price;
    public int Quantity => _quantity;
}