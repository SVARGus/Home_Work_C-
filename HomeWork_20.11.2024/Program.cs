using System;
/*
Задание 1
Реализуйте класс Список оценок (Marks).
Класс должен содержать словарь, где ключом будет предмет (Enum), а значением — список оценок по этому предмету.
(по аналогии с заданием из 3 модуля по ООП)
Создайте коллекцию Marks.
Напишите два LINQ выражения:
Одно получает среднее значение всех оценок в коллекции.
Второе — среднее значение оценки для конкретного предмета.

Задание 2
Создайте класс Товар (Product) с полями: Id, amount, price.
Создайте класс Локализация (ProductLocalization) с полями: ProductId, RuName, EngName.
Напишите следующие методы:
a) Вывод цен и наименований товаров, которые стоят больше 50$. Метод должен принимать вариант локали (русский или английский) и выводить наименование в соответствии с этой локалью.
b) Метод, принимающий строку и локаль, выводящий наименования и цены всех товаров, в названии которых содержится эта строка в заданной локали.
*/

public class Program
{
    enum Disciplines { History, Mathematics, Physics, Chemistry }
    public static void Main()
    {
        // Задание 1
        // Создание тестового объекта класса и проверка корректности
        Marks students1 = new Marks();
        students1.keyValuePairs.Add(Disciplines.History, new List<int> { 5, 4, 5 });
        students1.keyValuePairs.Add(Disciplines.Mathematics, new List<int> { 3, 4, 4 });
        students1.keyValuePairs.Add(Disciplines.Physics, new List<int> { 4, 4, 4, 5, 3 });
        students1.GraidAdd(Disciplines.Chemistry, 5);
        students1.GraidAdd(Disciplines.Mathematics, 3);
        students1.Display();
        // Написание LINQ выражений
        // среднее значение всех оценок в коллекции.
        var gradeAll = students1.keyValuePairs.SelectMany(u => u.Value).ToList(); // Ready
        foreach (var grade in gradeAll)
        {
            Console.Write(grade.ToString() + " ");
        }
        Console.WriteLine();
        // среднее значение оценки для конкретного предмета.
        var averageGradeDisciplines = students1.keyValuePairs.Select(u => (Subject: u.Key, Average: u.Value.Average())).ToList();
        Console.WriteLine("Средние оценки по предметам: ");
        foreach(var averageGrade in averageGradeDisciplines)
        {
            Console.WriteLine($"{averageGrade.Subject}: {averageGrade.Average}");
        }
        Console.WriteLine();
        Console.WriteLine();
        // Задание 2
        var products = new List<Product>
        {
            new Product (1, 5, 10.6),
            new Product (2, 3, 36.6),
            new Product (3, 12, 51.5), 
            new Product (4, 2, 40.3),
            new Product (5, 7, 78.9)
        };
        var productLocalizations = new List<ProductLocalization>
        {
            new ProductLocalization(1, "Яблоко", "Apple"),
            new ProductLocalization(2, "Апельсин", "Orange"),
            new ProductLocalization(3, "Банан", "Banana"),
            new ProductLocalization(4, "Груша", "Pear"),
            new ProductLocalization(5, "Тыква", "Pumpkin")
        };
        GetProductsAbovePriceByLocale(products, productLocalizations, 50, "eng");
        Console.WriteLine();
        SearchProductsByNameAndLocale(products, productLocalizations, "p", "eng");
    }
    public static void GetProductsAbovePriceByLocale(List<Product> products, List<ProductLocalization> productLocalizations, double price, string locale)
    {
        var filteredProducts = products
            .Where(p => p.Price > price)
            .Select(p =>
            {
                var localization = productLocalizations.FirstOrDefault(p1 => p1.ProductId == p.Id);
                string name = locale.ToLower() == "ru" ? (localization?.RuName ?? "Нет Имени") : (localization?.EngName ?? "Not Name");
                return new {Name = name, Price = p.Price};
            });
        foreach (var product in filteredProducts)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }
    }
    public static void SearchProductsByNameAndLocale(List<Product> products, List<ProductLocalization> productLocalizations, string searchString, string locale)
    {
        var filteredProducts = products
            .Select(p =>
            {
                var localization = productLocalizations.FirstOrDefault(p1 => p1.ProductId == p.Id);
                string name = locale.ToLower() == "ru" ? (localization?.RuName ?? "Нет Имени") : (localization?.EngName ?? "Not Name");
                return new { Name = name, Price = p.Price };
            })
            .Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        foreach (var product in filteredProducts)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }
    }
}
public class Marks
{
    public Dictionary<Enum, List<int>> keyValuePairs = new Dictionary<Enum, List<int>>();
    public void Display()
    {
        foreach(var pair in keyValuePairs)
        {
            Console.WriteLine($"Предмет: {pair.Key}.");
            Console.Write("Оценки: ");
            foreach(var item in pair.Value)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
    public void GraidAdd(Enum disciplines, int grade)
    {
        if(keyValuePairs.ContainsKey(disciplines))
        {
            keyValuePairs[disciplines].Add(grade);
        }
        else
        {
            keyValuePairs.Add(disciplines,new List<int> { grade });
        }
    }
}
public class Product
{
    public int Id { get; set; } // айди
    public int Amount { get; set; } // количество 
    public double Price { get; set; } // цена
    public Product(int id, int amount, double price)
    {
       Id = id;
       Amount = amount;
       Price = price;
    }
}
public class ProductLocalization
{
    public int ProductId { get; set; }
    public string RuName { get; set; }
    public string EngName { get; set; }
    public ProductLocalization(int productId, string ruName, string engName)
    {
        ProductId = productId;
        RuName = ruName;
        EngName = engName;
    }
}