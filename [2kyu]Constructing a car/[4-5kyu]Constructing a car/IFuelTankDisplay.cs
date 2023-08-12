#pragma warning disable S3903 // Types should be defined in named namespaces
public interface IFuelTankDisplay
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }
}