using System;
using System.Collections.Generic;
using System.Linq;

//public static class Program
//{
//    static void Main()
//    {
//        Car car = new Car(20, 10);

//        car.EngineStart();
//        car.Accelerate(10);
//        car.Accelerate(10);
//        car.Accelerate(10);
//        car.Accelerate(10);
//        Console.WriteLine(car.drivingInformationDisplay.ActualSpeed);
//    }
//}

public class Car : ICar
{
    public readonly IFuelTankDisplay fuelTankDisplay;

    public readonly IDrivingInformationDisplay drivingInformationDisplay;

    public  readonly IOnBoardComputerDisplay onBoardComputerDisplay;

    private readonly IEngine engine;

    private readonly IFuelTank fuelTank;

    private readonly IDrivingProcessor drivingProcessor;

    private readonly IOnBoardComputer onBoardComputer;

    private const double defaultFuelLevel = 20.0;

    private const int defaultAcceleration = 10;

    public Car() : this(defaultFuelLevel)
    {

    }

    public Car(double fuelLevel) : this(fuelLevel, defaultAcceleration)
    {
        
    }

    public Car(double fuelLevel, int maxAcceleration)
    {
        fuelTank = new FuelTank(fuelLevel);
        engine = new Engine(fuelTank);
        fuelTankDisplay = new FuelTankDisplay(fuelTank);
        drivingProcessor = new DrivingProcessor(maxAcceleration);
        drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        onBoardComputer = new OnBoardComputer();
        onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
    }

    public bool EngineIsRunning => engine.IsRunning;

    public void EngineStart()
    {
        engine.Start();
    }

    public void EngineStop()
    {
        engine.Stop();
    }

    public void Refuel(double liters)
    {
        if (liters <= 0)
        {
            return;
        }

        fuelTank.Refuel(liters);
    }

    public void RunningIdle()
    {
        if (EngineIsRunning)
        {
            engine.Consume(drivingProcessor.ActualConsumption);
        }
    }

    public void BrakeBy(int speed)
    {
        drivingProcessor.ReduceSpeed(speed);
    }

    public void Accelerate(int speed)
    {
        if (EngineIsRunning)
        {
            drivingProcessor.IncreaseSpeedTo(speed);

            engine.Consume(CalculateConsumption(drivingProcessor.ActualSpeed));
        }
    }

    public void FreeWheel()
    {
        if (EngineIsRunning && drivingProcessor.ActualSpeed == 0)
        {
            engine.Consume(drivingProcessor.ActualConsumption);
        }

        drivingProcessor.ReduceSpeed(1);
    }
}

public class Engine : IEngine
{
    private readonly IFuelTank fuelTank;

    public bool IsRunning { get; private set; }

    public Engine(IFuelTank fuelTank)
    {
        IsRunning = false;
        this.fuelTank = fuelTank;
    }

    public void Consume(double liters)
    {
        if (liters <= 0)
        {
            return;
        }

        fuelTank.Consume(liters);

        if (fuelTank.FillLevel == 0)
        {
            Stop();
        }
    }

    public void Start()
    {
        if (fuelTank.FillLevel != 0)
        {
            IsRunning = true;
        }
    }

    public void Stop() => IsRunning = false;
}

public class DrivingProcessor : IDrivingProcessor
{
    private const int maxSpeed = 250;

    private const int minSpeed = 0;

    private readonly int maxAcceleration;

    private const int maxBreaking = 10;

    private readonly Dictionary<int, double> consumptions = new Dictionary<int, double>()
    {
        {0, 0.0003 },
        { 60, 0.0020 },
        { 100, 0.0014 },
        { 140, 0.0020 },
        { 200, 0.0025 },
        { 250, 0.0030 },
    };

    public int ActualSpeed { get; private set; }

    public double ActualConsumption => CalculateConsumption(ActualSpeed);

    public DrivingProcessor(int maxAcceleration)
    {
        ActualSpeed = minSpeed;

        if (maxAcceleration > 20)
        {
            this.maxAcceleration = 20;
        }
        else if (maxAcceleration < 5)
        {
            this.maxAcceleration = 5;
        }
        else
        {
            this.maxAcceleration = maxAcceleration;
        }
    }

    public void IncreaseSpeedTo(int speed)
    {
        if (speed <= ActualSpeed)
        {
            ActualSpeed--;

            return;
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        if (speed - ActualSpeed > maxAcceleration)
        {
            ActualSpeed += maxAcceleration;
        }
        else
        {
            ActualSpeed = speed;
        }
    }

    public void ReduceSpeed(int speed)
    {
        if (speed <= 0)
        {
            return;
        }

        if (speed > maxBreaking)
        {
            speed = maxBreaking;
        }

        if (speed > ActualSpeed)
        {
            ActualSpeed = 0;
        }
        else
        {
            ActualSpeed -= speed;
        }
    }

    public double CalculateConsumption(int speed)
    {
        return consumptions.First(x => x.Key >= speed).Value;
    }

    public void EngineStart()
    {
        throw new NotImplementedException();
    }

    public void EngineStop()
    {
        throw new NotImplementedException();
    }
}

public class FuelTank : IFuelTank
{
    private const double maxFuelLevel = 60.0;

    private const double minFuelLevel = 0.0;

    private const double reserveFuelLevel = 5.0;

    public double FillLevel { get; private set; }

    public bool IsOnReserve => FillLevel < reserveFuelLevel;

    public bool IsComplete => FillLevel == maxFuelLevel;

    public FuelTank(double fuelLevel)
    {
        if (fuelLevel < minFuelLevel)
        {
            FillLevel = minFuelLevel;
        }
        else if (fuelLevel <= maxFuelLevel)
        {
            FillLevel = fuelLevel;
        }
        else
        {
            FillLevel = maxFuelLevel;
        }
    }

    public void Consume(double liters)
    {
        if (liters <= 0.0)
        {
            return;
        }

        FillLevel -= liters;
        Math.Round(FillLevel, 10);

        if (FillLevel < minFuelLevel)
        {
            FillLevel = minFuelLevel;
        }
    }

    public void Refuel(double liters)
    {
        if (liters <= 0.0)
        {
            return;
        }

        FillLevel += liters;
        Math.Round(FillLevel, 10);

        if (FillLevel > maxFuelLevel)
        {
            FillLevel = maxFuelLevel;
        }
    }
}

public class OnBoardComputer : IOnBoardComputer
{
    private IDrivingProcessor drivingProcessor;

    public int TripRealTime { get; private set; } = 0;

    public int TripDrivingTime { get; private set; } = 0;

    public int TripDrivenDistance { get; private set; } = 0;

    public int TotalRealTime { get; private set; } = 0;

    public int TotalDrivingTime { get; private set; } = 0;

    public int TotalDrivenDistance { get; private set; } = 0;

    public double TripAverageSpeed => TripDrivenDistance / TripDrivingTime;

    public double TotalAverageSpeed => TotalDrivenDistance / TotalDrivingTime;

    public int ActualSpeed => drivingProcessor.ActualSpeed;

    public double ActualConsumptionByTime { get; private set; }

    public double ActualConsumptionByDistance { get; private set; }

    public double TripAverageConsumptionByTime { get; private set; }

    public double TotalAverageConsumptionByTime { get; private set; }

    public double TripAverageConsumptionByDistance { get; private set; }

    public double TotalAverageConsumptionByDistance { get; private set; }

    public int EstimatedRange { get; private set; }

    public OnBoardComputer(IDrivingProcessor drivingProcessor)
    {
        this.drivingProcessor = drivingProcessor;
    }

    public void ElapseSecond()
    {
        TripRealTime++;
        TotalRealTime++;

        if (drivingProcessor.ActualSpeed > 0)
        {
            TripDrivingTime++;
            TotalDrivingTime++;
        }

        TripDrivenDistance += (int)(drivingProcessor.ActualSpeed / 3.6);
        TotalDrivenDistance += (int)(drivingProcessor.ActualSpeed / 3.6);

        
    }

    public void TotalReset()
    {
        throw new NotImplementedException();
    }

    public void TripReset()
    {
        throw new NotImplementedException();
    }
}

public class FuelTankDisplay : IFuelTankDisplay
{
    private readonly IFuelTank fuelTank;

    public double FillLevel => Math.Round(fuelTank.FillLevel, 2);

    public bool IsOnReserve => fuelTank.IsOnReserve;

    public bool IsComplete => fuelTank.IsComplete;

    public FuelTankDisplay(IFuelTank fuelTank)
    {
        this.fuelTank = fuelTank;
    }
}

public class DrivingInformationDisplay : IDrivingInformationDisplay
{
    private readonly IDrivingProcessor drivingProcessor;
    public int ActualSpeed => drivingProcessor.ActualSpeed;

    public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
    {
        this.drivingProcessor = drivingProcessor;
    }
}

public class OnBoardComputerDisplay : IOnBoardComputerDisplay
{
    private readonly IOnBoardComputer onBoardComputer;

    public int TripRealTime => onBoardComputer.TripRealTime;

    public int TripDrivingTime => onBoardComputer.TripDrivingTime;

    public double TripDrivenDistance => onBoardComputer.TripDrivenDistance;

    public int TotalRealTime => onBoardComputer.TotalRealTime;

    public int TotalDrivingTime => onBoardComputer.TotalDrivingTime;

    public double TotalDrivenDistance => 

    public int ActualSpeed => onBoardComputer.ActualSpeed;

    public double TripAverageSpeed => onBoardComputer.TripAverageSpeed;

    public double TotalAverageSpeed => onBoardComputer.TotalAverageSpeed;

    public double ActualConsumptionByTime => onBoardComputer.ActualConsumptionByTime;

    public double ActualConsumptionByDistance => onBoardComputer.ActualConsumptionByDistance;

    public double TripAverageConsumptionByTime => onBoardComputer.TripAverageConsumptionByTime;

    public double TotalAverageConsumptionByTime => onBoardComputer.TotalAverageConsumptionByTime;

    public double TripAverageConsumptionByDistance => onBoardComputer.TripAverageConsumptionByDistance;

    public double TotalAverageConsumptionByDistance => onBoardComputer.TotalAverageConsumptionByDistance;

    public int EstimatedRange => onBoardComputer.EstimatedRange;

    public OnBoardComputerDisplay(IOnBoardComputer onBoardComputer)
    {
        this.onBoardComputer = onBoardComputer;
    }

    public void TotalReset() => onBoardComputer.TotalReset();

    public void TripReset() => onBoardComputer.TripReset();
}