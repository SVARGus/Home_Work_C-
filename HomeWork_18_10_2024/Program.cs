//Console.WriteLine("Hello, World!");
using System;

/*
Задание №1
Даны целые положительные числа A, B, C. Значение этих чисел программа должна запрашивать у пользователя. 
На прямоугольнике размера A * B размещено максимально возможное количество квадратов со стороной C. 
Квадраты не накладываются друг на друга. Найти количество квадратов, размещённых на прямоугольнике, 
а также площадь незанятой части прямоугольника. Необходимо предусмотреть служебные сообщения в случае, 
если в прямоугольнике нельзя разместить ни одного квадрата со стороной C (например, если значение C превышает размер сторон прямоугольника).

Задание №2
Дано целое число N большее 0, найти число, полученное при прочтении числа N справа налево. 
Например, если было введено число 345, то программа должна вывести число 543.

Задание №3
Даны целые положительные числа A и B (A < B). 
Вывести все целые числа от A до B включительно; 
каждое число должно выводиться на новой строке; 
при этом каждое число должно выводиться количество раз, 
равное его значению (например, число 3 выводится 3 раза). 
Например: если А = 3, а В = 7, то программа должна сформировать в консоле следующий вывод:
3 3 3
4 4 4 4
5 5 5 5 5
6 6 6 6 6 6
7 7 7 7 7 7 7 
 */
public class Programm
{
    public static void Main()
    {
        Console.Title = "Задание #1";
        Console.WriteLine("Выполняем задание №1");
        int A = 0;
        int B = 0;
        int C = 0;
        A = int.Parse(Console.ReadLine());
        B = int.Parse(Console.ReadLine());
        C = int.Parse(Console.ReadLine());
        int count=0;
        for (int i = C; i <= A; i += C)
        {
            for (int j = C; j <= B; j += C)
            {
                ++count;
            }
        }
        int square = 0;
        square = (A * B) - (C * C * count);
        Console.WriteLine("Количество квадратов = " + count + ". Незаполненная площадь составляет = " + square);
        Console.Title = "Задание #2";
        Console.WriteLine("Выполняем задание №2");
        int num = 0;
        string arr = Console.ReadLine();
        char[] array = arr.ToCharArray();
        Array.Reverse(array);
        arr = new string(array);
        num = int.Parse(arr);
        Console.WriteLine("Число после реверса = " + num);
        Console.Title = "Задание #3";
        Console.WriteLine("Выполняем задание №3");
        Console.WriteLine("Введите число A и В, при этом А должно быть меньше В");
        A = int.Parse(Console.ReadLine());
        B = int.Parse(Console.ReadLine());
        if(A == B)
        {
            Console.WriteLine("А и В равны.");
        }
        else if(A > B)
        {
            Console.WriteLine("А больше В, сделаем перестановку");
            (A, B) = (B, A);
        }
        for (int i = A; i <= B; i++)
        {
            for(int j = 0; j < i; ++j)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}