using System;
using Microsoft.Data.Sqlite;

namespace ConanExilesCharacterTransfererCsharp;

public sealed class DatabaseConnector : IDisposable
{
    private readonly SqliteConnection _baseGameConnection;
    private readonly SqliteConnection _siptahConnection;
    
    public SqliteConnection BaseGameConnection => _baseGameConnection;
    public SqliteConnection SiptahConnection => _siptahConnection;
    
    public DatabaseConnector()
    {
        _baseGameConnection = new SqliteConnection("Data Source=" + Constants.ExilesDatabaseName);
        _siptahConnection = new SqliteConnection("Data Source=" + Constants.SiptahDatabaseName);
    }

    public static void RunTest()
    {
        using (var connector = new DatabaseConnector())
        {
            connector.Initialize();
            var command = connector.BaseGameConnection.CreateCommand();
            command.CommandText = "SELECT id,char_name,level FROM characters";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var printStatement = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        printStatement += reader.GetValue(i) + " ";
                    }
                    Debug.LogInfo(printStatement);
                }
            }
        }
    }

    public void Initialize()
    {
        try
        {
            Debug.LogInfo("Initializing database connections...");
            _baseGameConnection.Open();
            _siptahConnection.Open();
            Debug.LogInfo("Database connections initialized");
        }
        catch (SqliteException ex)
        {
            Debug.LogError("Error OPENING database connections " + ex.Message);
        }
    }

    private void CloseConnectionsToDatabases()
    {
        try
        {
            Debug.LogInfo("Closing database connections...");
            _baseGameConnection.Close();
            _siptahConnection.Close();
            Debug.LogInfo("Database connections closed");
        }
        catch (SqliteException ex)
        {
            Debug.LogError("Error CLOSING database connections " + ex.Message);
        }
    }
    
    public void Dispose()
    {
        CloseConnectionsToDatabases();
        
        _baseGameConnection.Dispose();
        _siptahConnection.Dispose();
    }
}