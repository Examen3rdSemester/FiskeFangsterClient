using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FiskeFangsterClient.Model;
using Newtonsoft.Json;

namespace FiskeFangsterClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Start start = new Start();
            start.Menu();

            Console.ReadKey();
        }


    }
}
