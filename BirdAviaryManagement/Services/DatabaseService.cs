using BirdAviaryManagement.Models;
using Microsoft.Data.Sqlite;

namespace BirdAviaryManagement.Services;

public class DatabaseService
{
    private string connectionString =
        "Data Source=birds.db";

    public DatabaseService()
    {
        CreateTable();
    }

    private void CreateTable()
    {
        using SqliteConnection connection =
            new SqliteConnection(
                connectionString
            );

        connection.Open();

        string query =
        @"
        CREATE TABLE IF NOT EXISTS Birds
        (
            RingId TEXT PRIMARY KEY,
            Name TEXT,
            HatchYear INTEGER,
            Type TEXT,
            Color TEXT,
            Status TEXT,
            IsForSale INTEGER
        )
        ";

        SqliteCommand command =
            new SqliteCommand(
                query,
                connection
            );

        command.ExecuteNonQuery();
    }

    public void AddBird(
        Bird bird
    )
    {
        using SqliteConnection connection =
            new SqliteConnection(
                connectionString
            );

        connection.Open();

        string query =
        @"
        INSERT INTO Birds
        (
            RingId,
            Name,
            HatchYear,
            Type,
            Color,
            Status,
            IsForSale
        )
        VALUES
        (
            @RingId,
            @Name,
            @HatchYear,
            @Type,
            @Color,
            @Status,
            @IsForSale
        )
        ";

        SqliteCommand command =
            new SqliteCommand(
                query,
                connection
            );

        command.Parameters.AddWithValue(
            "@RingId",
            bird.RingId
        );

        command.Parameters.AddWithValue(
            "@Name",
            bird.Name
        );

        command.Parameters.AddWithValue(
            "@HatchYear",
            bird.HatchYear
        );

        command.Parameters.AddWithValue(
            "@Type",
            bird.Type
        );

        command.Parameters.AddWithValue(
            "@Color",
            bird.Color
        );

        command.Parameters.AddWithValue(
            "@Status",
            bird.Status
        );

        command.Parameters.AddWithValue(
            "@IsForSale",
            bird.IsForSale
        );

        command.ExecuteNonQuery();
    }

    public List<Bird> GetAllBirds()
    {
        List<Bird> birds =
            new List<Bird>();

        using SqliteConnection connection =
            new SqliteConnection(
                connectionString
            );

        connection.Open();

        string query =
            "SELECT * FROM Birds";

        SqliteCommand command =
            new SqliteCommand(
                query,
                connection
            );

        SqliteDataReader reader =
            command.ExecuteReader();

        while (reader.Read())
        {
            Bird bird =
                new Bird
                (
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetBoolean(6)
                );

            birds.Add(bird);
        }

        return birds;
    }

    public void DeleteBird(
        string ringId
    )
    {
        using SqliteConnection connection =
            new SqliteConnection(
                connectionString
            );

        connection.Open();

        string query =
            "DELETE FROM Birds WHERE RingId = @RingId";

        SqliteCommand command =
            new SqliteCommand(
                query,
                connection
            );

        command.Parameters.AddWithValue(
            "@RingId",
            ringId
        );

        command.ExecuteNonQuery();
    }

    public Bird? FindBird(
        string ringId
    )
    {
        return GetAllBirds()
            .FirstOrDefault(
                b => b.RingId == ringId
            );
    }
}