using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable S3903 // Types should be defined in named namespaces

public static class Program
{
    static void Main()
    {
        var car = new Car();

        car.EngineStart();

        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);

        double a = double.NaN;

        a = 0;
        a += 4;

        Console.WriteLine(a);
    }
}

public class Car : ICar
{
    public readonly IFuelTankDisplay fuelTankDisplay;

    public readonly IDrivingInformationDisplay drivingInformationDisplay;

    public readonly IOnBoardComputerDisplay onBoardComputerDisplay;

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
        onBoardComputer = new OnBoardComputer(drivingProcessor);
        onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
    }

    public bool EngineIsRunning => engine.IsRunning;

    public void EngineStart()
    {
        engine.Start();
        onBoardComputer.TripReset();
        onBoardComputer.ElapseSecond();
    }

    public void EngineStop()
    {
        engine.Stop();
        onBoardComputer.ElapseSecond();
        drivingProcessor.EngineStop();
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

        drivingProcessor.EngineStart();

        onBoardComputer.ElapseSecond();
    }

    public void BrakeBy(int speed)
    {
        drivingProcessor.ReduceSpeed(speed);
        onBoardComputer.ElapseSecond();
    }

    public void Accelerate(int speed)
    {
        if (EngineIsRunning)
        {
            drivingProcessor.IncreaseSpeedTo(speed);

            engine.Consume(DrivingProcessor.CalculateConsumption(drivingProcessor.ActualSpeed));
        }

        onBoardComputer.ElapseSecond();
    }

    public void FreeWheel()
    {
        if (EngineIsRunning && drivingProcessor.ActualSpeed == 0)
        {
            engine.Consume(drivingProcessor.ActualConsumption);
        }

        drivingProcessor.ReduceSpeed(1);
        drivingProcessor.EngineStop();

        onBoardComputer.ElapseSecond();
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

    private static readonly Dictionary<int, double> consumptions = new Dictionary<int, double>()
    {
        {0, 0.0003 },
        { 60, 0.0020 },
        { 100, 0.0014 },
        { 140, 0.0020 },
        { 200, 0.0025 },
        { 250, 0.0030 },
    };

    public int ActualSpeed { get; private set; }

    public double ActualConsumption { get; private set; }

    public DrivingProcessor(int maxAcceleration)
    {
        ActualSpeed = minSpeed;
        ActualConsumption = 0.0;

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

        ActualConsumption = CalculateConsumption(ActualSpeed);
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

        ActualConsumption = CalculateConsumption(ActualSpeed);
    }

    public static double CalculateConsumption(int speed)
    {
        return consumptions.First(x => x.Key >= speed).Value;
    }

    public void EngineStart()
    {
        ActualConsumption = CalculateConsumption(ActualSpeed);
    }

    public void EngineStop()
    {
        ActualConsumption = 0.0;
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
    private readonly IDrivingProcessor drivingProcessor;

    private double TripConsumptionByTimeSum = 0.0;

    private double TotalConsumptionByTimeSum = 0.0;

    private double TripConsumptionByDistanceSum = 0.0;

    private double TotalConsumptionByDistanceSum = 0.0;

    public int TripRealTime { get; private set; } = 0;

    public int TotalRealTime { get; private set; } = 0;

    public int TripDrivingTime { get; private set; } = 0;

    public int TotalDrivingTime { get; private set; } = 0;

    public double TripDistanceInMeters { get; private set; } = 0.0;

    public double TotalDistanceInMeters { get; private set; } = 0.0;

    public int TripDrivenDistance => (int)(TripDistanceInMeters / 1000);

    public int TotalDrivenDistance => (int)(TotalDistanceInMeters / 1000);

    public double TripAverageSpeed => Math.Round((double)TripDrivenDistance / TripDrivingTime, 1);

    public double TotalAverageSpeed => Math.Round((double)TotalDrivenDistance / TotalDrivingTime, 1);

    public int ActualSpeed => drivingProcessor.ActualSpeed;

    public double ActualConsumptionByTime => drivingProcessor.ActualConsumption;

    public double ActualConsumptionByDistance
    {
        get
        {
            if (ActualSpeed > 0)
            {
                return Math.Round(drivingProcessor.ActualConsumption * 360000 / ActualSpeed, 1);
            }
            else
            {
                return double.NaN;
            }
        }
    }

    public double TripAverageConsumptionByTime => Math.Round(TripConsumptionByTimeSum / TripRealTime, 5);

    public double TotalAverageConsumptionByTime => Math.Round(TotalConsumptionByTimeSum / TotalRealTime, 5);

    public double TripAverageConsumptionByDistance => Math.Round(TripConsumptionByDistanceSum / TripDrivingTime, 1);

    public double TotalAverageConsumptionByDistance => Math.Round(TotalConsumptionByDistanceSum / TotalDrivingTime, 1);

    public int EstimatedRange => 0;

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

        TripDistanceInMeters += drivingProcessor.ActualSpeed / 3.6;
        TotalDistanceInMeters += drivingProcessor.ActualSpeed / 3.6;

        TripConsumptionByTimeSum += ActualConsumptionByTime;
        TotalConsumptionByTimeSum += ActualConsumptionByTime;

        TripConsumptionByDistanceSum += ActualConsumptionByDistance;
        TotalConsumptionByDistanceSum += ActualConsumptionByDistance;
    }

    public void TotalReset()
    {
        TripReset();
        TotalConsumptionByTimeSum = 0.0;
        TotalConsumptionByDistanceSum = 0.0;
        TotalRealTime = 0;
        TotalDrivingTime = 0;
        TotalDistanceInMeters = 0.0;
    }

    public void TripReset()
    {
        TripConsumptionByTimeSum = 0.0;
        TripConsumptionByDistanceSum = 0.0;
        TripRealTime = 0;
        TripDrivingTime = 0;
        TripDistanceInMeters = 0.0;
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

    public int TotalRealTime => onBoardComputer.TotalRealTime;

    public int TripDrivingTime => onBoardComputer.TripDrivingTime;

    public int TotalDrivingTime => onBoardComputer.TotalDrivingTime;

    public double TripDrivenDistance => Math.Round(onBoardComputer.TripDrivenDistance / 1000.0, 2);

    public double TotalDrivenDistance => Math.Round(onBoardComputer.TotalDrivenDistance / 1000.0, 2);

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