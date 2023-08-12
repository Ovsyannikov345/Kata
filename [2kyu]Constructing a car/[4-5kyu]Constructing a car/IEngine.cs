#pragma warning disable S3903 // Types should be defined in named namespaces
public interface IEngine
{
    bool IsRunning { get; }

    void Consume(double liters);

    void Start();

    void Stop();
}