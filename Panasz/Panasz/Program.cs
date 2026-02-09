using Panasz.database;
using Panasz.model;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    public static readonly string connectionString = "Server=localhost;Database=panaszotronix;User=root;";

    public static DataTable adatok = new DataTable();
    public static List<Data> PanaszLista = new List<Data>();
    public static int id = 0;
    private static void Main(string[] args) {

        SelectFromTable("panaszkonyv",connectionString);
        DBCheck(connectionString);
        Beirszitu();
        



    }

    private static void Beirszitu()
    {
        Console.Write("Add meg a tanárod nevét: ");
        string tanarnev = Console.ReadLine();

        Console.Write("Add meg a neved: ");
        string diaknev = Console.ReadLine();

        Console.Write("Add meg az emailed: ");
        string email = Console.ReadLine();

        Console.Write("Add meg a telefonszámod: ");
        string telefon = Console.ReadLine();

        Console.Write("Add meg a dátumot: ");
        string datum = Console.ReadLine();

        Console.Write("Add meg a panaszod: ");
        string panasz = Console.ReadLine();

        

        DatabaseService.InsertUser(tanarnev, diaknev, email, telefon, datum, panasz, connectionString);

        Console.WriteLine("Sikeresen elmentve!");
        Console.ReadKey();
    }

    private static void SelectFromTable(string tableName, string connectionString)
    {
        adatok = DatabaseService.GetAllData(tableName, connectionString);
        Console.WriteLine("Adatok sikeresen szinkronizálva az adatbázisból, átmeneti tárolóba");
        Console.WriteLine("Adatok betöltve: " + adatok.Rows.Count + " sor");
    }


    private static void DBCheck(string connectionString)
    {
        DatabaseService.DbConnectionCheck(connectionString);
    }

}