namespace BirdAviaryManagement.Models;

public class Bird
{
    public string RingId
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }

    public int HatchYear
    {
        get;
        set;
    }

    public string Type
    {
        get;
        set;
    }

    public string Color
    {
        get;
        set;
    }

    public string Status
    {
        get;
        set;
    }

    public bool IsForSale
    {
        get;
        set;
    }

    public Bird
    (
        string ringId,
        string name,
        int hatchYear,
        string type,
        string color,
        string status,
        bool isForSale
    )
    {
        RingId = ringId;

        Name = name;

        HatchYear = hatchYear;

        Type = type;

        Color = color;

        Status = status;

        IsForSale = isForSale;
    }
}