using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_bars1
{
    public class Test
    {
        public event EventHandler<char> OnKeyPressed;

        public void Run()
        {
            var el = Console.ReadKey();
            while (true)
            {
                if (el.Key ==ConsoleKey.C)
                {
                    break;
                }
                else
                {
                    OnKeyPressed?.Invoke(this, el.KeyChar);
                }

            }
           
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var sub = new Program();
            sub.Method();
        }


        public void Method()
        {
            var el = new Test();

            el.OnKeyPressed += InputChar;

            el.Run();
        }
         
        public void InputChar(object sender, char letter)
        {
            Console.WriteLine(letter);
        }
       






    }
}
