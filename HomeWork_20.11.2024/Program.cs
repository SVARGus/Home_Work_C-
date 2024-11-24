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

        // Задание 2

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