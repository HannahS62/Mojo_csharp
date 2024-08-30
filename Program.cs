using System.Data;
using System.Data.SQLite;
using Dapper;



namespace Mojo_The_Summoning_C_;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=localdb.db";
        using var connection = new SQLiteConnection(connectionString);

        CreateUsersTable(connection);
        CreateCardsTable(connection);
        CreateDeckTable(connection);
        CreateAttackTable(connection);
       
       /*
       InsertUser(connection, "v1per");
       InsertUser(connection, "trinity");
       InsertUser(connection, "mr_spoon");

       InsertCard(connection, "Spellweaver", 100, 10, "http://localhost:5000/img/arcturus-spellweaver.jpg");
       InsertCard(connection, "Mistral", 100, 10, "http://localhost:5000/img/nimue-mistral.jpg");
       InsertCard(connection, "Theron Thunderstrike", 100, 10, "http://localhost:5000/img/theron-thunderstrike.jpg");
       InsertCard(connection, "Lirien Moonshadow", 100, 10, "http://localhost:5000/img/lirien-moonshadow.jpg");
       InsertCard(connection, "Alaric Flamecaller", 100, 10, "http://localhost:5000/img/alaric-flamecaller.jpg");
    
       InsertDeck(connection, "Snake Pit", 75);
       InsertDeck(connection, "The Matrix", 80);
       InsertDeck(connection, "Doom Burger", 65);

       InsertAttack(connection, "sword", 60, 40);
       InsertAttack(connection, "rope", 20, 75);
       InsertAttack(connection, "fire", 80, 30);
       */

    }

    static void CreateUsersTable(SQLiteConnection connection)
    {
        string sql = @"
        CREATE TABLE IF NOT EXISTS Users (
        Id INTEGER PRIMARY KEY,
        username STRING NOT NULL
        )";
        connection.Execute(sql);
    }

    static void CreateCardsTable(SQLiteConnection connection)
    {
        string sql = @"
        CREATE TABLE IF NOT EXISTS Cards (
        Id INTEGER PRIMARY KEY,
        name STRING NOT NULL,
        mojo INTEGER NOT NULL,
        stamina INTEGER NOT NULL,
        imgUrl STRING NOT NULL
        )";
        connection.Execute(sql);
    }
    static void CreateDeckTable(SQLiteConnection connection) 
    {
        string sql = @"
        CREATE TABLE IF NOT EXISTS Deck (
        Id INTEGER PRIMARY KEY,
        name STRING NOT NULL,
        xp INTEGER NOT NULL
        )";
        connection.Execute(sql);
    }
    static void CreateAttackTable(SQLiteConnection connection) 
    {
        string sql = @"
        CREATE TABLE IF NOT EXISTS Attack (
        Id INTEGER PRIMARY KEY,
        title STRING NOT NULL,
        mojoCost INTEGER NOT NULL,
        staminaCost INTEGER NOT NULL
        )";
        connection.Execute(sql);
    }

    static void InsertUser(SQLiteConnection connection, string username) 
    {
        string sql = "INSERT INTO Users (username) VALUES (@Username)";
        connection.Execute(sql, new {Username = username});
    }

    static void InsertCard(SQLiteConnection connection, string name, int mojo, int stamina, string imgUrl)
    {
        string sql = "INSERT INTO Cards (name, mojo, stamina, imgUrl) VALUES (@Name, @Mojo, @Stamina, @ImgUrl)";
        connection.Execute(sql, new {Name = name, Mojo = mojo, Stamina = stamina, ImgUrl = imgUrl});
    }

    static void InsertDeck(SQLiteConnection connection, string name, int xp) 
    {
        string sql = "INSERT INTO Deck (name, xp) VALUES (@Name, @Xp)";
        connection.Execute(sql, new {Name = name, Xp = xp});
    }
    
    static void InsertAttack(SQLiteConnection connection, string title, int mojoCost, int staminaCost)
    {
        string sql = "INSERT INTO Attack (title, mojoCost, staminaCost) VALUES (@Title, @MojoCost, @StaminaCost)";
        connection.Execute(sql, new{Title = title, MojoCost = mojoCost, StaminaCost = staminaCost});
    }

        static void DisplayUsers(SQLiteConnection connection)
    {
        var users = connection.Query<User>("SELECT * FROM Users");
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
        static void DisplayCards(SQLiteConnection connection)
    {
        var cards = connection.Query<Card>("SELECT * FROM Cards");
        foreach (var card in cards)
        {
            Console.WriteLine(card);
        }
    }
        static void DisplayAttack(SQLiteConnection connection)
    {
        var attacks = connection.Query<Attack>("SELECT * FROM Attack");
        foreach (var attack in attacks)
        {
            Console.WriteLine(attack);
        }
    }
}
 