using AdatbazisTeszt.Database;
using Panasz.model;
using System.Data;

internal class Program
{
    private static void Main(string[] args) { }
    //{
        //* public static readonly string connectionString
      //  = "Server=localhost;Database=11a_foldrajz;User=root;";
   // public static DataTable adatok = new DataTable();
    //public static List<Orszag> orszagLista = new List<Orszag>();
    private static void SelectFromTable(string tableName, string connectionString)
    {
       //adatok = DatabaseService.GetAllData(tableName, connectionString);
        Console.WriteLine("Adatok sikeresen szinkronizálva az adatbázisból, átmeneti tárolóba");
    }

    private static void DBCheck(string connectionString)
    {
        DatabaseService.DbConnectionCheck(connectionString);
    }

}