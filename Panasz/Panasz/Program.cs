using Panasz.database;
using Panasz.model;
using System.Data;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
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
        Console.WriteLine("Írni, törölni vagy lekérdezni szeretnél? (i/t/k)");
        string val = Console.ReadLine();

        if (val == "i")
        {
            Beirszitu();
        }
        else if(val=="k")
        {
            Lekerdszitu();
        }
        else if (val == "t")
        {
            Torloszitu();
        }
        else
        {
            Console.WriteLine("Rendes választ kér a program. lásd-->()");
        }

    }

    private static void Torloszitu()
    {
        Console.WriteLine("Melyik adatsort szeretnéd törölni? (id szám)");
        int id =Convert.ToInt32( Console.ReadLine());
        DatabaseService.DeleteById(connectionString,"panaszkonyv",id);
        Console.WriteLine("A tanár bűnei törölve");

    }

    private static void Lekerdszitu()
    {
        Console.WriteLine("Mi alapján szeretnél lekérdezni? (nev/tanarnev/datum)");

        string val = Console.ReadLine();

        if (val == "nev")
        {
            Console.WriteLine("Melyik diáknak a panaszadási adatait szeretnéd látni?");
            string gyerek=Console.ReadLine();

            DataTable dt=  DatabaseService.GetAllDatafromnev("panaszkonyv", "diak_neve", connectionString, gyerek);
            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine($"{gyerek} adatai:-> ");
                Console.WriteLine($"    ID: {row["id"]}");
                Console.WriteLine($"    tanár neve: {row["tanar_neve"]}");
                Console.WriteLine($"    diák neve: {row["diak_neve"]}");
                Console.WriteLine($"    email: {row["email"]}");
                Console.WriteLine($"    telefon: {row["telefon"]}");
                Console.WriteLine($"    dátum: {row["datum"]}");
                Console.WriteLine($"    panasz: {row["panasz"]}");
            }
        }

        else if (val == "tanarnev")
        {
            Console.WriteLine("Melyik tanárnak a panaszait szeretnéd látni?");
            string tanar = Console.ReadLine();

            DataTable dt = DatabaseService.GetAllDatafromnev("panaszkonyv", "tanar_neve", connectionString, tanar);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{tanar} adatai:-> ");
                Console.WriteLine($"    ID: {row["id"]}");
                Console.WriteLine($"    tanár neve: {row["tanar_neve"]}");
                Console.WriteLine($"    diák neve: {row["diak_neve"]}");
                Console.WriteLine($"    email: {row["email"]}");
                Console.WriteLine($"    telefon: {row["telefon"]}");
                Console.WriteLine($"    dátum: {row["datum"]}");
                Console.WriteLine($"    panasz: {row["panasz"]}");
            }

        }

        else if (val == "datum")
        {
            Console.WriteLine("Melyik dátum panasz adatait szeretnéd látni? (0000-00-00)");
            string datum = Console.ReadLine();

            DataTable dt = DatabaseService.GetAllDatafromnev("panaszkonyv", "datum", connectionString, datum);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{datum} adatai:-> ");
                Console.WriteLine($"    ID: {row["id"]}");
                Console.WriteLine($"    tanár neve: {row["tanar_neve"]}");
                Console.WriteLine($"    diák neve: {row["diak_neve"]}");
                Console.WriteLine($"    email: {row["email"]}");
                Console.WriteLine($"    telefon: {row["telefon"]}");
                Console.WriteLine($"    dátum: {row["datum"]}");
                Console.WriteLine($"    panasz: {row["panasz"]}");
            }

        }
        else
        {
            Console.WriteLine("A program rendes választ igényel. lásd-->()");
        }

        
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