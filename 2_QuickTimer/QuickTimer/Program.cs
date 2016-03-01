using System;
using System.Diagnostics;
using System.Threading;
//:1 -- using Static classes
using static System.Console;

namespace QuickTimer
{
    class Program
    {
        static readonly string AppName = "QuickTimer 1.0";
        static readonly char ResetChar = 'r';
        static readonly char QuitChar = 'q';
        static readonly string NewLine = Environment.NewLine;


        static void Main(string[] args)
        {
            var timer = new QuickTimer();
            timer.QuitEvent +=  (o, e) => Clear();
            timer.ResetEvent += (o, e) => Clear();
            timer.TickEvent += (o, e) => Write($"\r{timer.ElapsedMilliseconds.ToSeconds()}");
           
            Console.WriteLine("Welcome to {0}. {3}Instructions: {3}Press any key to begin or pause. {3}Press '{1}' to reset. {3}Press '{2}' to quit."
                , ResetChar, QuitChar, NewLine);

            var name = "Dan";
            var localStr = "Hi {0}";
            var s = string.Format(localStr, name);
            FormattableString formattedString = $"Hi {name}";
            
            //IFormattable
            #region C#6 String Interpolation
            //2: Example of new string interpolation. Insert the values where they're suppsoed to go in the string literal
            Console.WriteLine($@"Welcome to {Localize(AppName)}. {NewLine}
                    Instructions: {NewLine}
                    Press any key to begin or pause. {NewLine}
                    Press '{ResetChar}' to reset. {Environment.NewLine}
                    Press '{QuitChar} to quit.");
            #endregion

            Console.ReadKey();
            Console.Clear();
            timer.Start();
        }

        public static string Localize(string s)
        {
            return string.Empty;
        }
   
    }
}
