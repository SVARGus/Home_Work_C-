using System;
using System.Collections.Generic;

/*
Задание №1
Разработать архитектуру классов иерархии товаров при разработке системы управления потоками товаров для дистрибьюторской компании. 
Прописать члены классов.
Должны быть предусмотрены разные типы товаров, в том числе:
бытовая химия;
продукты питания.
Предусмотреть классы управления потоком товаров (пришло, реализовано, списано, передано).
 */

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
    // Добавить конструктор без указания количества
    public override void GetInfo()
    {
        Console.WriteLine($"Товар: {Name}, ID: {Id}, Цена: {Price}, Количество: {Quantity}, Срок годности: {ExpirationDate.ToShortDateString()}, Состав: {ChemicalComposition}"); // описание товара
    }
}
public class FoodProducts : Product
{
    private DateTime _expirationDate { get; set; } // Срок годности товара
    public DateTime ExpirationDate { get { return _expirationDate; } set { _expirationDate = value; } } // Обычно срок годности не меняется у товара, поэтому лучше без set
    private string _nutritionalValue { get; set; } // Пищевая ценность
    public string NutritionalValue { get { return _nutritionalValue; } set { _nutritionalValue = value; } }
    // Добавить конструктор без указания количества
    public override void GetInfo()
    {
        Console.WriteLine($"Товар: {Name}, ID: {Id}, Цена: {Price}, Количество: {Quantity}, Срок годности: {ExpirationDate.ToShortDateString()}, Пищевая ценность: {NutritionalValue}"); // описание товара
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
    public override void ProcessFlow(Product product, int quantity)
    {
        product.UpdateQuantity(quantity);
        Console.WriteLine($"Приход: добавлено {quantity} едениц товара {product.Name}. Текущее количество {product.Quantity}.");
    }
}
public class SaleFlow : ProductFlow // Реализация товара
{
    public override void ProcessFlow(Product product, int quantity)
    {
        if (product.Quantity >= quantity)
        {
            product.UpdateQuantity(-quantity);
            Console.WriteLine($"Реализация: продано {quantity} едениц товара {product.Name}. Текущее количество {product.Quantity}.");
        }
        else { Console.WriteLine($"Реализация {quantity} едениц товара {product.Name} невозможна, остаток на складе магазина {product.Quantity}."); }
    }
}
public class WriteOffFlow : ProductFlow // Списание товара
{
    public override void ProcessFlow(Product product, int quantity)
    {
        if (product.Quantity >= quantity)
        {
            product.UpdateQuantity(-quantity);
            Console.WriteLine($"Списание: списано {quantity} едениц товара {product.Name}. Текущее количество {product.Quantity}.");
        }
        else { Console.WriteLine($"Списание {quantity} едениц товара {product.Name} невозможно, остаток на складе магазина {product.Quantity}."); }
    }
}
public class TransferFlow : ProductFlow // Передача товара (например на другой склад)
{
    public override void ProcessFlow(Product product, int quantity)
    {
        if (product.Quantity >= quantity)
        {
            product.UpdateQuantity(-quantity);
            Console.WriteLine($"Передача: передано {quantity} едениц товара {product.Name}. Текущее количество {product.Quantity}.");
        }
        else { Console.WriteLine($"Передача {quantity} едениц товара {product.Name} невозможна, остаток на складе магазина {product.Quantity}."); }
    }
}
// Класс управления товарами и потоками
public class InventoryManager
{
    public Dictionary<int, Product> products = new Dictionary<int, Product>();
    public Dictionary<string, ProductFlow> productFlows = new Dictionary<string, ProductFlow>();
    // реализовать конструктор с инициализацией доступных стратегий
    public void AddProduct(Product product)  // добавление товара в базу
    {
        if (!products.ContainsKey(product.Id)) 
        {
            products.Add(product.Id, product);
        }
        else
        {
            Console.WriteLine($"Добавляемый {product.Name} уже имеется в базе данных!");
        }
    }
    public void ProcessFlow(string flowType, Product product, int quantity) // выбор стратегии
    {
        if (!products.ContainsKey(product.Id))
        {
            products.Add(product.Id, product);
        }
        if (productFlows.ContainsKey(flowType))
        {
            productFlows[flowType].ProcessFlow(product, quantity);
        }
        else
        {
            Console.WriteLine("Несуществующий тип операции");
        }
    } 
}
