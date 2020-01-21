using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace SentinelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //只需要在这里提供所有Redis实例的连接串即可, 哨兵实例可忽略
            var connection = ConnectionMultiplexer.Connect("127.0.0.1:6380,127.0.0.1:6381,127.0.0.1:6382");
            var db = connection.GetDatabase();

            Console.WriteLine("---------------------------Redis Sentinel Test---------------------------");
            Console.WriteLine(connection.GetStatus());
            Console.WriteLine("---------------------------------------------------------------------------");

            db.StringSet("sentiel", 1);

            while (true)
            {
                var x = Console.ReadLine();
                db.StringSet("sentiel", x);
            }
        }
    }
}
