using Panasz.database;
using Panasz.model;
using System.Data;

internal class Program
{
    public static readonly string connectionString = "Server=localhost;Database=panaszotronix;User=root;";

    public static DataTable adatok = new DataTable();
    public static List<Data> PanaszLista = new List<Data>();
    private static void Main(string[] args) {

        SelectFromTable("panaszkonyv",connectionString);
        DBCheck(connectionString);



    }
    private static void SelectFromTable(string tableName, string connectionString)
    {
       adatok = DatabaseService.GetAllData(tableName, connectionString);
        Console.WriteLine("Adatok sikeresen szinkronizálva az adatbázisból, átmeneti tárolóba");
    }

    private static void DBCheck(string connectionString)
    {
        DatabaseService.DbConnectionCheck(connectionString);
    }

}