using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
/*
Задание Делегаты
a. Создайте делегат Calculate, принимающий два числа и 
возвращающий результат операции с ними.
b. Создайте класс Calculator с полем типа Calculate и 
методом DoCalculate (выполняющим математическую операцию).
c. Создайте три объекта класса Calculator. Одному в поле 
Calculate присвойте операцию сложения, второму умножения, третьему - вычитание.
d. Для каждого объекта выполните DoCalculate.

Задание События
1) Создайте класс Button с событием OnButtonPressed и методом Click.
2) В методе Click должно вызываться событие OnButtonPressed.
3) Создайте несколько кнопок (сохранить, отправить, прочитать и т.д.).
4) Событию OnButtonPressed для каждой кнопки присвойте свой делегат и вызовите Click.

Задание Расширения
1) Для List<Button> напишите расширение, которое нажимает все кнопки в этом списке.
2) Для List<string> напишите расширение, которое возвращает все первые буквы в этом списке.
*/


public class Program
{
    public static void Main()
    {
        // задание Делегаты
        var example = new Calculater();
        Calculate Sum = example.DoCalculateSum;
        var sum = Sum.Invoke(5, 6);
        Console.WriteLine(sum);
        Sum = example.DoCalculateMinus;
        var min = Sum.Invoke(5, 6);
        Console.WriteLine(min);
        Sum = example.DoCalculateMulti;
        var mul = Sum.Invoke(5, 6);
        Console.WriteLine(mul);
        Sum = example.DoCalculateDivision;
        var div = Sum.Invoke(5, 6);
        Console.WriteLine(div);
        // Задание Событие
        Button saveButton = new Button("Сохранить");
        Button sendButton = new Button("Отправить");
        Button readButton = new Button("Прочитать");
        saveButton.OnButtonPressed += () => Console.WriteLine("Документ сохранен");
        sendButton.OnButtonPressed += () => Console.WriteLine("Документ отправелн");
        readButton.OnButtonPressed += () => Console.WriteLine("Документ прочитан");
        saveButton.Click();
        sendButton.Click();
        readButton.Click();
        // Расширения
        List<Button> buttons = new List<Button>();
        buttons.Add(saveButton);
        buttons.Add(sendButton);
        buttons.Add(readButton);
        Console.WriteLine("Click all buttons");
        buttons.ClickAll();
        var buttinStrings = new List<string> { "Сохранить", "Отправить", "Прочитать" };
        Console.WriteLine("выведем все первые буквы");
        Console.WriteLine(buttinStrings.GetFirstLetters());


    }
}

public delegate int Calculate(int x1, int x2); // выполнен на уроке
public class Calculater
{
    public Calculate var { get; set; }
    public int DoCalculateSum(int x1, int x2)
    {
        return x1 + x2;
    }
    public int DoCalculateMulti(int x1, int x2)
    {
        return x1 * x2;
    }
    public int DoCalculateMinus(int x1, int x2)
    {
        return x1 - x2;
    }
    public int DoCalculateDivision(int x1, int x2)
    {
        return x1 / x2;
    }
}
public class Button
{
    public event Action OnButtonPressed;
    public string Name { get; }
    public Button(string name)
    {
        Name = name;
    }
    public void Click()
    {
        Console.WriteLine($"Кнопка {Name} нажата");
        OnButtonPressed?.Invoke();
    }
}
public static class Extensions
{
    public static void ClickAll(this List<Button> buttons)
    {
        foreach(var button in buttons)
        {
            button.Click();
        }
    }
    public static string GetFirstLetters(this List<string> list)
    {
        List<char> result = new List<char>();
        foreach(var strings in list)
        {
            result.Add(strings[0]);
        }
        return string.Concat(result.ToArray());
    }
}