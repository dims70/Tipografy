using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TestConsole
{
    class Program
    {   //Консоль для отправки запросов
        static void Main(string[] args)
        {
            var i = 1;
            while(i==1)
            {
             Console.WriteLine("Введите число(id) эскиза");
             var id = Console.ReadLine();
                if (id == "ex")
                {
                    Environment.Exit(1);
                }
                else
                {
                    var request = WebRequest.Create("http://localhost:13451/Content/getSketch" + "?id="+id);
                    var responce = request.GetResponse();
                    using (StreamReader stream = new StreamReader(responce.GetResponseStream()))
                    {   
                        string line = stream.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
