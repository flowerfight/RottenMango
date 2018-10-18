using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {

            String a = "안녕?";

            Sum();

            Person p = new Person();
            p.Age();


        }

        public static int Sum()
        {
            int a = 1;
            int b = 2;

            int sum = a + b;

            return sum;
        }

    }

    public class Person
    {
        public void Age()
        {

        }
    }

    class Car
    {
        public static void age()
        {

        }
    }
}
