namespace BirdAviaryManagement.Services;

public interface IHealthService
{
    bool IsBirdHealthy(
        string ringId
    );
}