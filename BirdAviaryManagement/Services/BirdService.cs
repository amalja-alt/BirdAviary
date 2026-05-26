using BirdAviaryManagement.Models;

namespace BirdAviaryManagement.Services;

public class BirdService
{
    private List<Bird> birds =
        new List<Bird>();

    private IHealthService
        healthService;

    public BirdService
    (
        IHealthService healthService
    )
    {
        this.healthService =
            healthService;
    }

    public void AddBird(
        Bird bird
    )
    {
        if (
            string.IsNullOrWhiteSpace(
                bird.Name
            )
        )
        {
            throw new ArgumentException(
                "Bird name cannot be empty!"
            );
        }

        bool isHealthy =
            healthService
            .IsBirdHealthy(
                bird.RingId
            );

        bird.IsForSale =
            isHealthy;

        birds.Add(bird);
    }

    public void RemoveBird(
        string ringId
    )
    {
        Bird? birdToRemove =
            birds.FirstOrDefault
            (
                b => b.RingId
                == ringId
            );

        if (birdToRemove != null)
        {
            birds.Remove(
                birdToRemove
            );
        }
    }

    public List<Bird>
        GetAllBirds()
    {
        return birds;
    }

    public int GetBirdCount()
    {
        return birds.Count;
    }
}