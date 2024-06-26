﻿#pragma warning disable S3903 // Types should be defined in named namespaces
public interface ICar
{
    bool EngineIsRunning { get; }

    void BrakeBy(int speed); // car #2

    void Accelerate(int speed); // car #2

    void EngineStart();

    void EngineStop();

    void FreeWheel(); // car #2

    void Refuel(double liters);

    void RunningIdle();
}