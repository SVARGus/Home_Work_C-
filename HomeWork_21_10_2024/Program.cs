/*
ДЗ List

1) Дан List строк. Можете инициализировать его сразу в коде, не вводя из консоли.
Так же дана строка.
Сформировать три новых List.
В одном должны быть элементы, которые содержат указанную строку один раз.
Во втором должны быть элементы, которые содержат указанную строку 2 и более раз.
В третьем — элементы, которые указанную строку не содержат.
Вывести все 4 List, предварительно сформировав из них строку.

2) Дан массив чисел. Вывести на экран две суммы:
всех положительных
всех отрицательных чисел.

3) Дан List чисел. Некоторые числа в нем повторяются.
Сформируйте новый List, который будет содержать по одному разу все повторяющиеся числа из первого.
*/
/*
ДЗ Строки

1) С помощью интерполяции вывести два сообщения: о сегодняшней дате и о текущем времени.
Получить дату можно с помощью DateTime.Now.ToShortDateString().
Получить время можно с помощью DateTime.Now.TimeOfDay.

2) Дана строка. Посчитайте количество слов в строке и выведите их каждое с новой строки. Словом может быть любая последовательность символов, кроме пробела.

3) Создать Enum Number с элементами Zero, One, Two, ..., Nine.
Создать строку из букв и цифр.
Сформировать новую строку, в которой каждая цифра заменена соответствующим словом.
Switch case не использовать.
Рекомендуется делать формирование новой строки с использованием StringBuilder.

Подсказки:

Вы можете использовать статический метод char.IsDigit(‘i’), который определяет, является ли символ числом.
Вы можете привести Enum к int. Пример: int numberOne = (int)Number.One.
*/
/*
ДЗ Словари (опционально)

Создайте Dictionary, который будет хранить информацию о пользователе: логин, почту, пароль, номер телефона, 
время последнего захода в сеть. Все значения храните в текстовом формате.

Разработайте следующие методы:

1) Аутентификация. Принимает две строки: логин и пароль. Возвращает true, если логин и пароль совпадают, и false в ином случае.
В случае успеха время последнего захода в сеть обновляется (DateTime.Now.ToString()).

2) Смена пароля. Принимает две строки: номер телефона и новый пароль. 
Если указанный номер телефона совпадает с тем, что указан в словаре, 
пароль в словаре меняется, и метод возвращает true.
Иначе метод возвращает false.

3) Добавление даты рождения. Принимает одну строку: дату рождения. 
Если в словаре нет даты рождения, она добавляется. Если дата рождения есть, 
выводится сообщение о том, что дата уже добавлена, а сама дата не обновляется.
*/

using System;
using System.Text;

public class Program
{
    public enum Number { Zero = 0, One, Two, Three, Four, Five, Six, Seven, Eight, Nine };
    public static void Main()
    {
        // Задание по List
        Console.Title = "Задание по List";
        //1
        Console.WriteLine("Задание #1");
        List<string> strings = new List<string> { "zero", "one", "two", "three" };

        //2
        Console.WriteLine("Задание #2");
        List<int> ints = new List<int> { 1, -5, 6, 7, -3, -7, 0, 99 };
        int sumplus = 0;
        int summinus = 0;
        sumplus = ints.FindAll(n => n > 0).Sum();
        summinus = ints.FindAll(n => n < 0).Sum();
        Console.WriteLine("Сумма положительных " + sumplus);
        Console.WriteLine("Сумма отрицательных " + summinus);
        //3
        Console.WriteLine("Задание #3");
        List<int> ints1 = new List<int> { 1, 1, 2, 9, 12, 3, 2, 4, 5, 6, 5, 5 };
        foreach(int i in ints1)
        {
            Console.Write(i);
        }
        Console.WriteLine();
        List<int> subList = new List<int>();
        foreach (int i in ints1)
        {
            if (ints1.FindAll(x => x == i).Count() > 1 && !subList.Contains(i)) 
            {
                subList.Add(i);
            }
        }
        foreach (int i in subList)
        {
            Console.Write(i);
        }
        Console.WriteLine();

        // Задание по Строкам
        Console.Title = "Задание по Строкам";
        //1
        Console.WriteLine("Задание #1");
        Console.WriteLine($"Текущая дата: {DateTime.Now.ToShortDateString()} время: {DateTime.Now.TimeOfDay}");
        //2
        Console.WriteLine("Задание #2");
        string str = "Hello   world const price car 5";
        Console.WriteLine(str);
        while (str.IndexOf("  ") >= 0)
        {
            str = str.Replace("  ", " ");
        }
        string[] str2 = str.Split(" ");
        Console.WriteLine(str2.Length);
        //3
        Console.WriteLine("Задание #3");
        StringBuilder strBild = new StringBuilder("Привет начнем с 1, остановимся на 5, а закончим на 8. И как вам это из 9");
        Console.WriteLine(strBild);
        foreach (Number num in Enum.GetValues(typeof(Number)))
        {
            string numberNume = num.ToString();
            int numberValue = (int)num;
            strBild.Replace(numberValue.ToString(), numberNume);
        }
        Console.WriteLine(strBild);
        //Console.WriteLine(strBild.ToString());
    }
}