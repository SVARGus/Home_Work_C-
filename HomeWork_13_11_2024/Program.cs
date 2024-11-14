using System;
/*
Задание от 13.11.2024

1) Напишите абстрактный класс, отправляющий запросы и возвращающий 
ответы RequestHandler<TRequest, TResponse>

2) У него должен быть метод HandleRequest. Возвращаемый тип TResponse, 
принимаемый параметр типа TRequest

3) Создайте два наследника TimeRequestHandler и StringConcatRequestHandler

4) Метод HandleRequest в TimeRequestHandler должен считать, 
сколько дней прошло между двумя датами Для этого в TimeRequest должны быть две даты,
а в TimeResponse — количество дней

5) Метод HandleRequest в StringConcatRequestHandler 
должен принимать коллекцию строк и возвращать их конкатенацию
Для этого StringConcatRequest должен содержать коллекцию строк, 
а StringConcatResponse — строку, результат конкатенации
*/
public class Program
{
    public static void Main()
    {
        Tuple<DateTime, DateTime> tuple = Tuple.Create(
            new DateTime(2024, 5, 15),
            new DateTime(2024, 11, 14)
            );
        TimeRequestHandler timeRequestHandler = new TimeRequestHandler();
        Console.WriteLine("Количество дней = " + timeRequestHandler.HandleRequest(tuple));
        List<string> args = new List<string> {
            "Hello",
            "world",
            "from",
            "C++",
            "and",
            "C#"
            };
        StringConcatRequestHandler stringConcatRequestHandler = new StringConcatRequestHandler();
        Console.WriteLine(stringConcatRequestHandler.HandleRequest(args));
    }
}
public abstract class RequestHandler<TRequest, TResponse>
{
    public abstract TResponse HandleRequest(TRequest obj);
}
public class TimeRequestHandler : RequestHandler<Tuple<DateTime, DateTime>, int>
{
    public override int HandleRequest(Tuple<DateTime, DateTime> obj)
    {
        if (obj.Item1 < obj.Item2)
        {
            return (obj.Item2 - obj.Item1).Days;
        }
        return (obj.Item1 - obj.Item2).Days;
    }
}
public class StringConcatRequestHandler : RequestHandler<List<string>, string>
{
    public override string HandleRequest(List<string> obj)
    {
        return string.Join(" ", obj);
    }
}