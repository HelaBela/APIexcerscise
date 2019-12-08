using System;
using System.Linq;
using System.Net;



namespace APIwithoutMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpListener();
            server.Prefixes.Add($"http://localhost:8080/");
            server.Start();
            
            
            
            while (true)
            {
                
                //after second requests it stops here , becasue it is synch
                var context = server.GetContext(); //  HttpListenerContext object - allows to access request and response. Provides access to the request and response objects
                
                var httpListenerRequest = context.Request;//HttpListenerRequest object - accesses the incoming requests and respons
                Console.WriteLine($"{httpListenerRequest.HttpMethod} {httpListenerRequest.Url}");
                var person = new Person().GetPersonDetails();
               
                //here I am constructing the response
                var buffer = System.Text.Encoding.UTF8.GetBytes($"Hello - {person.ConvertToString()}");

                Console.WriteLine($"{httpListenerRequest.Url.Segments[0]}");
                Console.WriteLine($"{httpListenerRequest.Url.Segments[1]}");
                Console.WriteLine($"{httpListenerRequest.Url.AbsolutePath}");
                if (httpListenerRequest.Url.AbsolutePath == "/date")
                {
                    Console.WriteLine($"i am here through /date");
                    buffer = System.Text.Encoding.UTF8.GetBytes($"{person.Today.Date}");
                }
                
                if (httpListenerRequest.Url.Segments[1] == "joke")
                {
                    Console.WriteLine($"i am here through joke");
                    buffer = System.Text.Encoding.UTF8.GetBytes($"Have you heard about the zoo with only one dog?");
                    
                }
                
                // if I wanted to achieve the below with Segments[3]or[2]? 
                
                if (httpListenerRequest.Url.AbsolutePath == "/joke/answer" )
                {
                    buffer = System.Text.Encoding.UTF8.GetBytes("It’s a shitzu");
                    
                }
                
                //obtaining the response
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length); // forces send of response
                
               

            }
        }
    }
}