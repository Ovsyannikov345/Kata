using Interfaces;
using System;

public class Car : ICar
{
    private static readonly double defaultFuelLevel = 20;

    private static readonly double fuelPerSecond = 0.0003;

    public IFuelTankDisplay fuelTankDisplay { get; }

    private IEngine engine { get; }

    private IFuelTank fuelTank { get; }

    public bool EngineIsRunning { get; private set; }

    public Car() : this(defaultFuelLevel)
    {

    }

    public Car(double fuelLevel)
    {
        fuelTank = new FuelTank(fuelLevel);
        fuelTankDisplay = new FuelTankDisplay(fuelTank);
        engine = new Engine(fuelTank);
        EngineIsRunning = false;
    }

    public void EngineStart()
    {
        if (!EngineIsRunning)
        {
            EngineIsRunning = true;
            engine.Start();
        }
    }

    public void EngineStop()
    {
        if (EngineIsRunning)
        {
            EngineIsRunning = false;
            engine.Stop();
        }
    }

    public void Refuel(double liters)
    {
        if (liters > 0)
        {
            fuelTank.Refuel(liters);
        }
    }

    public void RunningIdle()
    {
        engine.Consume(fuelPerSecond);
    }
}

public class Engine : IEngine
{
    private readonly IFuelTank fuelTank;

    public bool IsRunning { get; private set; }

    public Engine(IFuelTank fuelTank)
    {
        this.fuelTank = fuelTank;
        IsRunning = false;
    }

    public void Consume(double liters)
    {
        fuelTank.Consume(liters);

        if (fuelTank.FillLevel == 0)
        {
            Stop();
        }
    }

    public void Start()
    {
        IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
    }
}

public class FuelTank : IFuelTank
{
    private readonly double maxFillLevel = 60;

    private readonly double fillLevelPrecision = 10;

    public double FillLevel { get; private set; }

    public bool IsOnReserve { get; private set; }

    public bool IsComplete { get; private set; }

    public FuelTank(double fillLevel)
    {
        if (fillLevel < 0)
        {
            FillLevel = 0;
        }
        else if (fillLevel > maxFillLevel)
        {
            FillLevel = maxFillLevel;
        }
        else
        {
            FillLevel = fillLevel;
        }

        UpdateFlags();
    }

    public void Consume(double liters)
    {
        FillLevel -= liters;

        if (FillLevel < 0)
        {
            FillLevel = 0;
        }
        else
        {
            FillLevel = (int)(FillLevel * Math.Pow(10, fillLevelPrecision)) / Math.Pow(10, fillLevelPrecision);
        }

        UpdateFlags();
    }

    public void Refuel(double liters)
    {
        FillLevel += liters;

        if (FillLevel > maxFillLevel)
        {
            FillLevel = maxFillLevel;
        }

        UpdateFlags();
    }

    private void UpdateFlags()
    {
        IsComplete = FillLevel == 60;
        IsOnReserve = FillLevel < 5;
    }
}

public class FuelTankDisplay : IFuelTankDisplay
{
    private readonly double displayPrecision = 2;

    private readonly IFuelTank fuelTank;

    public double FillLevel 
    { 
        get
        {
            return (int)(fuelTank.FillLevel * Math.Pow(10, displayPrecision)) / Math.Pow(10, displayPrecision);
        } 
    }

    public bool IsOnReserve
    {
        get
        {
            return fuelTank.IsOnReserve;
        }
    }

    public bool IsComplete
    {
        get
        {
            return fuelTank.IsComplete;
        }
    }

    public FuelTankDisplay(IFuelTank fuelTank)
    {
        this.fuelTank = fuelTank;
    }
}