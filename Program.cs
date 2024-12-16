using System;
using System.Timers; 

public class Stopwatch
{
    
    private int timeElapsed;
    private bool isRunning;
    private System.Timers.Timer timer; 

    
    public int TimeElapsed => timeElapsed;
    public bool IsRunning => isRunning;

    
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    
    public delegate void StopwatchEventHandler(string message);

    
    public Stopwatch()
    {
        timeElapsed = 0;
        isRunning = false;

        
        timer = new System.Timers.Timer(1000); 
        timer.Elapsed += OnTimedEvent;
    }

    
    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
            timer.Start();
        }
    }

    
    public void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            timer.Stop();
            OnStopped?.Invoke("Stopwatch Stopped!");
        }
    }

    
    public void Reset()
    {
        timeElapsed = 0;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        timeElapsed++;
        Console.Clear();
        Console.WriteLine($"Time Elapsed: {timeElapsed} seconds");
    }
}