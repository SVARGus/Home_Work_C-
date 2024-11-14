using System;
using System.Text.Json;
using System.Text.Json.Serialization;
/*
Домашнее задание по теме сериализация
содержимое json.txt
{
  "menu": {
    "id": "file",
    "value": "File",
    "popup": {
      "menuitem": [
        {
          "value": "New",
          "onclick": "CreateNewDoc()"
        },
        {
          "value": "Open",
          "onclick": "OpenDoc()"
        },
        {
          "value": "Close",
          "onclick": "CloseDoc()"
        }
      ]
    }
  }
}
*/
public class Program
{
    public static void Main()
    {
        string filePath = "json.txt";
        string jsonString = File.ReadAllText(filePath);
        Console.WriteLine(jsonString);
        Root root = JsonSerializer.Deserialize<Root>(jsonString);
        // реализовать отдельный вывод объекта для проверки корректности
    }
}


 public class MainMenu
{
    [JsonPropertyName ("id")]
    public string Id { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
    [JsonPropertyName("popup")]
    public Popup Popup { get; set; }
}
public class Popup
{
    [JsonPropertyName("menuitem")]
    public List<MenuItem> Menuitem { get; set; }
}
public class MenuItem
{
    [JsonPropertyName("value")]
    public string Value {  set; get; }
    [JsonPropertyName("onclick")]
    public string Onclick { get; set; }
}
public class Root
{
    [JsonPropertyName("menu")]
    public MainMenu Menu { get; set; }
}