#pragma warning disable S3903 // Types should be defined in named namespaces
public interface IDrivingProcessor
{
    double ActualConsumption { get; }

    int ActualSpeed { get; }

    void EngineStart();

    void EngineStop();

    void IncreaseSpeedTo(int speed);

    void ReduceSpeed(int speed);
}