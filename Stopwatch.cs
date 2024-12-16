using System;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        
        stopwatch.OnStarted += DisplayMessage;
        stopwatch.OnStopped += DisplayMessage;
        stopwatch.OnReset += DisplayMessage;

        
        while (true)
        {
            Console.WriteLine("Press S to Start, T to Stop, R to Reset, Q to Quit");
            var input = Console.ReadKey(true).Key;

            if (input == ConsoleKey.S)
            {
                stopwatch.Start();
            }
            else if (input == ConsoleKey.T) 
            {
                stopwatch.Stop();
            }
            else if (input == ConsoleKey.R) 
            {
                stopwatch.Reset();
            }
            else if (input == ConsoleKey.Q) 
            {
                break;
            }
        }
    }

    
static void DisplayMessage(string message)
{
    Console.Clear();
    Console.WriteLine(message);
    

    Thread.Sleep(1000); 
}
}
