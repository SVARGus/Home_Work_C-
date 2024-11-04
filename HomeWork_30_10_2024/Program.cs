using System;
/*
Задание от 30.10.2024
1) Определить интерфейс Printable, содержащий метод void print().
2) Определить класс Book, реализующий интерфейс Printable.
Определить класс Magazine, реализующий интерфейс Printable.
3) Создать массив типа Printable, который будет содержать книги и журналы.
В цикле пройти по массиву и вызвать метод print() для каждого объекта.
4) Создать статический метод printMagazines(Printable[] printable) в классе Magazine, который выводит на консоль названия только журналов. (используя ключевое слово is)
Создать статический метод printBooks(Printable[] printable) в классе Book, который выводит на консоль названия только книг. (используя ключевое слово is) 
*/
public class Program
{
    public static void Main()
    {
        List<Printable> printables = new List<Printable>
        {
            new Book("Евгений Онегин", 58967, 2),
            new Magazine("Конструируем сами", 6894, 3),
            new Book("Мастер и маргарита", 58967, 2),
            new Magazine("Кулинария", 58793, 9),
            new Book("Гарри Поттер", 236971, 12),
            new Magazine("Космос", 11111, 0),
            new Book("Srtar Wars", 65656, 3),
            new Magazine("Программа передач на неделю", 88888, 8),
            new Book("Советская нициклопедия. Т.1", 45444, 4)
        };
        foreach (Printable printable in printables)
        {
            printable.Print();
            Console.WriteLine("-------------------------");
        }
        Console.WriteLine("========================");
        Console.WriteLine("Только журналы:");
        Magazine.printMagazine(printables);
        Console.WriteLine("========================");
        Console.WriteLine("Только Книги:");
        Book.printBooks(printables);
    }
}

public interface Printable
{
    void Print();
}
public class Book : Printable
{
    private string _name {  get; set; } // Название книги (журнала)
    public string Name { get { return _name; } }
    private int _id { get; set; } // Айди книги (журнала)
    public int Id { get { return _id; } }
    private int _volume { get; set; } // Количество книг (журналов)
    public int Volume { get { return _volume; } set { _volume = value; } }
    public Book(string name, int id, int volume) {  _name = name; _id = id; _volume = volume; }
    public void Print()
    {
        Console.WriteLine($"Название книги: \"{_name}\"; ID: {_id}; Количество книг: {_volume}.");
    }
    public static void printBooks(List<Printable> printables)
    {
        foreach (Printable printable in printables)
        {
            if (printable is Book)
            {
                printable.Print();
            }
        }
    }
}
public class Magazine : Printable
{
    private string _name { get; set; } // Название книги (журнала)
    public string Name { get { return _name; } }
    private int _id { get; set; } // Айди книги (журнала)
    public int Id { get { return _id; } }
    private int _volume { get; set; } // Количество книг (журналов)
    public int Volume { get { return _volume; } set { _volume = value; } }
    public Magazine(string name, int id, int volume) { _name = name; _id = id; _volume = volume; }
    public void Print()
    {
        Console.WriteLine($"Название журнала: \"{_name}\"; ID: {_id}; Количество журналов: {_volume}.");
    }
    public static void printMagazine(List<Printable> printables)
    {
        foreach(Printable printable in printables)
        {
            if (printable is Magazine)
            {
                printable.Print();
            }
        }
    }
}