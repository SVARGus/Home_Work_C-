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
/*
Задание №2
Создайте класс Passport (паспорт), который будет содержать паспортную информацию о гражданине заданной страны.
С помощью механизма наследования, реализуйте класс ForeignPassport (загранпаспорт) производный от Passport.
Напомним, что заграничный паспорт содержит помимо паспортных данных, также данные о визах, номер заграничного паспорта.
*/

public class Program
{
    public static void Main()
    {
        // Задание #1
        // Примеры продуктов для заведения в базу
        Product product1 = new DomesticChemical(3561, "Порошок стиральный Dosy", 56.5, DateTime.Now.AddYears(2), "какойто химический состав");
        Product product2 = new DomesticChemical(3689, "Мыло жидкое", 15, DateTime.Now.AddYears(3), "какойто химический состав - 2");
        Product product3 = new DomesticChemical(0125, "Освежитель Domestes", 30, DateTime.Now.AddYears(2), "какойто химический состав - 3");
        Product product4 = new FoodProducts(4125, "Капуста квашенная", 5.3, DateTime.Now.AddYears(1), "Калорийность какая-та");
        Product product5 = new FoodProducts(0125, "Сметана", 3, DateTime.Now.AddYears(1), "Калорийность какая-та - 2");
        Product product6 = new FoodProducts(4002, "Консерва - сайра", 14.8, DateTime.Now.AddYears(3), "Калорийность какая-та - 3");
        // Потоки товара
        string Arrival = "Arrival";
        string Sale = "Sale";
        string WriteOff = "WriteOff";
        string Transfer = "Transfer";
        var manager = new InventoryManager();
        manager.AddProduct(product1);
        manager.ProcessFlow(Arrival, product5, 100);
        manager.ProcessFlow(Sale, product1, 100);
        manager.ProcessFlow(Sale, product5, 10);
        manager.ProcessFlow(WriteOff, product3, 10);
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
    public DomesticChemical(int id, string name, double price, DateTime expiretionDate, string chemicalComposition)
    {
        Id = id; Name = name; Price = price; ExpirationDate = expiretionDate; ChemicalComposition = chemicalComposition; Quantity = 0;
    }
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
    public FoodProducts(int id, string name, double price, DateTime expiretionDate, string nutritionalValue)
    {
        Id = id; Name = name; Price = price; ExpirationDate = expiretionDate; NutritionalValue = nutritionalValue; Quantity = 0;
    }
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
        Console.WriteLine("Тестовый вывод о товаре после операции");
        product.GetInfo();
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
        Console.WriteLine("Тестовый вывод о товаре после операции");
        product.GetInfo();
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
        Console.WriteLine("Тестовый вывод о товаре после операции");
        product.GetInfo();
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

        Console.WriteLine("Тестовый вывод о товаре после операции");
        product.GetInfo();
    }
}
// Класс управления товарами и потоками
public class InventoryManager
{
    public Dictionary<int, Product> products = new Dictionary<int, Product>();
    public Dictionary<string, ProductFlow> productFlows;
    // реализовать конструктор с инициализацией доступных стратегий
    public InventoryManager()
    {
        // Инициализация доступных стратегий
        productFlows = new Dictionary<string, ProductFlow>
        {
            { "Arrival", new ArrivalFlow() },
            { "Sale", new SaleFlow() },
            { "WriteOff", new WriteOffFlow() },
            { "Transfer", new TransferFlow() }
        };
    }
    public void AddProduct(Product product)  // добавление товара в базу
    {
        if (!products.ContainsKey(product.Id)) 
        {
            products.Add(product.Id, product);
            Console.WriteLine($"В базу добавлен новый продукт{product.Name}");
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

/*
Задание №2
Создайте класс Passport (паспорт), который будет содержать паспортную информацию о гражданине заданной страны.
С помощью механизма наследования, реализуйте класс ForeignPassport (загранпаспорт) производный от Passport.
Напомним, что заграничный паспорт содержит помимо паспортных данных, также данные о визах, номер заграничного паспорта.
*/
// КЛАССЫ ДЛЯ ВЫПОЛНЕНИЯ ВТОРОГО ЗАДАНИЯ ПРО ПАСПОРТ И ЗАГРАН-ПАСПОРТ
public class Passport
{
    // Все переменные сделаю открытыми в целях выполнения задания по наследованию классов
    public string NumberPassport {  get; set; } // Номер паспорта
    public DateTime DateOfIssue { get; set; } // дата выдачи паспорта
    public DateTime EndDate { get; set; } // дата окончания действия паспорта
    public string LastName {  get; set; } // Фамилия
    public string FirstName { get; set; } // Имя
    public string MiddleName { get; set; } // Отчество
    public string Fio => $"{LastName} {FirstName} {MiddleName}"; //ФИО
    public DateTime DateOfBirth { get; set; } // дата рождения
    public string PlaceOfBirth { get; set; } // место рождения
    public string Gender { get; set; } // пол
    public string Nationaly { get; set; } // национальность
    // конструктор
    public Passport(string number, DateTime dateOfIssue, DateTime endDate, string lastName, string firstname,
                   string middleName, DateTime dateOfBirth, string plaseOfBirth, string gender, string national)
    {
        NumberPassport = number; 
        DateOfIssue = dateOfIssue; 
        EndDate = endDate; 
        LastName = lastName; 
        FirstName = firstname; 
        MiddleName = middleName; 
        DateOfBirth = dateOfBirth; 
        PlaceOfBirth = plaseOfBirth; 
        Gender = gender; 
        Nationaly = national;
    }
    // методы
    public virtual void GetInfoPassport()
    {
        Console.WriteLine($"Номер паспорта: {NumberPassport}; Дата выдачи: {DateOfIssue}; Дата действия до {EndDate}; ");// дописать метод вывода
        GetInfoPerson();
    }
    public void GetInfoPerson()
    {
        Console.WriteLine($"Фамилия: {LastName} Имя: {FirstName} Отчество: {MiddleName}");
        Console.WriteLine($"Пол: {Gender} Национальность: {Nationaly}");
        Console.WriteLine($"Дата рождения: {DateOfBirth} Место рождения {PlaceOfBirth}");
    }
}
// отдельный класс для виз
public class Visa
{
    public string NumeCountry { get; set; } // Страна которая выдала визу
    public string NumberVisa { get; set; } // номер визы
    public DateTime OpenDate { get; set; } // дата начала действия визы
    public DateTime EndDate { get; set; } // дата окончания визы

    public Visa(string numeCountri, string numberVisa, DateTime openDate, int year) // по умолчанию все изы эквиваленты году, но можно добавить возможность выдачи на определенное количество месяцев или дней
    {
        this.NumeCountry = numeCountri;
        this.NumberVisa = numberVisa;
        this.OpenDate = openDate;
        if (year <= 0)
        {
            Console.WriteLine("Не верный срок действия визы");
            this.EndDate = openDate;
        }
        else
            this.EndDate = openDate.AddYears(year);
    }
    public void GetInfoVisa()
    {
        Console.WriteLine($"Страна выдавшая визу: {NumeCountry}, Номер визы: {NumberVisa}, Дата выдачи визы: {OpenDate}, Дата окончания визы {EndDate}.");
    }
}
// класс загран паспорта
public sealed class ForeignPassport : Passport
{
    // дополнительные переменные
    public string NumberInternalPassport { get; set; } // номер заграничного паспорта
    private List<Visa> _visas { get; set; }
    public List<Visa> Visas { get => _visas; set => _visas = value; }
    //  конструктор
    public ForeignPassport(string numberInternalPassport, string number, DateTime dateOfIssue, DateTime endDate, 
        string lastName, string firstname, string middleName, DateTime dateOfBirth, string plaseOfBirth, string gender, string national) 
        :base(number, dateOfIssue, endDate, lastName, firstname,middleName, dateOfBirth, plaseOfBirth, gender, national)
    {
        NumberInternalPassport = numberInternalPassport;
        Visas = new List<Visa>();
    }
    public override sealed void GetInfoPassport()
    {
        Console.WriteLine($"Номер загран паспорта: {NumberInternalPassport}");
        Console.WriteLine($"Номер паспорта: {NumberPassport}; Дата выдачи: {DateOfIssue}; Дата действия до {EndDate}; ");// дописать метод вывода
        GetInfoPerson();
        Console.WriteLine("Список выданных виз: ");
        foreach (var item in Visas)
        {
            item.GetInfoVisa();
            Console.WriteLine("------------------------------------");
        }
    }
}
