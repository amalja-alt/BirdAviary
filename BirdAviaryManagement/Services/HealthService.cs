namespace BirdAviaryManagement.Services;

public class HealthService :
    IHealthService
{
    private Random random =
        new Random();

    public bool IsBirdHealthy(
        string ringId
    )
    {
        return random.Next(0, 2)
            == 1;
    }
}