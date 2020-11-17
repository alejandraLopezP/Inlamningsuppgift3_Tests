using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CStackClass;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            CStack cs;
            cs = new CStack();
            bool stop = false;
            Console.WriteLine("welcome to calc");
            string input;
            string[] commands;
            do
            {
                Console.Write("> ");
                input = Console.ReadLine();
                commands = input.Split(' ');

                if ( commands[0] == "quit")
                {//
                    Console.WriteLine("hej då");
                    stop = true;
                }
                else if ( commands[0] == "enter" )
                {

                }
                else if (commands[0] == "+")
                {

                }
                else if (commands[0] == "*")
                {

                }
                else if (commands[0] == "-")
                {

                }
                else if (commands[0] == "/")
                {

                }
                else if (commands[0] == "show")
                {

                }
                else
                {
                    Console.WriteLine("wrong input, try again");
                }

            } while (!stop);


            Console.ReadKey();

        }
    }
}
