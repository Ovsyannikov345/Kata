#pragma warning disable S3903 // Types should be defined in named namespaces
public interface IFuelTank
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }

    void Consume(double liters);

    void Refuel(double liters);
}