using System;

public class Program
{
    public static void Main()
    {

    }
}
public abstract class Product
{
    private int _id {  get; set; } // Айди товара (уникальное, можно использовать как ключ)
    public int Id { get { return _id; } set { _id = value; } }
    private string _name { get; set; } // Название продукта
    public string Name { get { return _name; } set { _name = value; } }
    //private string _description { get; set; }
    //public string Description { get { return _description; } set { _description = value; } }
    private double _price { get; set; } // Цена продукта
    public double Price { get { return _price; } set { _price = value; } }
    private int _quantity { get; set; } // Количество товара (например на складе или в партии поставки)
    public int Quantity { get { return _quantity; } set {_quantity = value; } }
    // Методы
    public void UpdateQuantity (int quantity) {  _quantity += quantity; } // увеличение или уменьшение количества
    public abstract void GetInfo(); // Абстрактный метод для отображения информации о продукте
}
public class DomesticChemical : Product
{
    private DateTime _expirationDate { get; set; } // Срок годности товара
    public DateTime ExpirationDate { get { return _expirationDate; } set { _expirationDate = value; } } // Обычно срок годности не меняется у товара, поэтому лучше без set
    private string _chemicalComposition { get; set; } // Химический состав товара
    public string ChemicalComposition { get { return _chemicalComposition; } set { _chemicalComposition = value; } }

    public override void GetInfo()
    {
        throw new NotImplementedException(); // описание товара
    }
}
public class FoodProducts : Product
{
    private DateTime _expirationDate { get; set; } // Срок годности товара
    public DateTime ExpirationDate { get { return _expirationDate; } set { _expirationDate = value; } } // Обычно срок годности не меняется у товара, поэтому лучше без set
    private string _nutritionalValue { get; set; } // Пищевая ценность
    public string NutritionalValue { get { return _nutritionalValue; } set { _nutritionalValue = value; } }
    public override void GetInfo()
    {
        throw new NotImplementedException(); // описание товара
    }
}

// КЛАССЫ для управления потоков, реализуется на основе паттерна Strategy
public abstract class ProductFlow
{
    public Product product { get; set; } // Ссылка на продукт для возможности изменения
    public int quantity { get; set; } // количество товаров участвующих в операции
    public abstract void ProcessFlow(Product product, int quantity); // Реализация стратегии
}
public class ArrivalFlow : ProductFlow // Приход товара
{

}
public class SaleFlow : ProductFlow // Реализация товара
{

}
public class WriteOffFlow : ProductFlow // Списание товара
{

}
public class TransferFlow : ProductFlow // Передача товара (например на другой склад)
{

}
