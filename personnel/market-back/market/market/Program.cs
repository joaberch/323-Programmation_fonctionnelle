using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

var i18n = new Dictionary<string, string>()
{
    { "Pommes","Apples"},
    { "Poires","Pears"},
    { "Pastèques","Watermelons"},
    { "Melons","Melons"},
    { "Noix","Nuts"},
    { "Raisin","Grapes"},
    { "Pruneaux","Plums"},
    { "Myrtilles","Blueberries"},
    { "Groseilles","Berries"},
    { "Tomates","Tomatoes"},
    { "Courges","Pumpkins"},
    { "Pêches","Peaches"},
    { "Haricots","Beans"}
};

List<Product> products = new List<Product>
{
    new Product { Location = 11, Producer = "Beaud", ProductName = "Courges", Quantity = 16, Unit = "pièce", PricePerUnit = 8.70 },
    new Product { Location = 11, Producer = "Beaud", ProductName = "Tomates", Quantity = 18, Unit = "kg", PricePerUnit = 5.30 },
    new Product { Location = 11, Producer = "Beaud", ProductName = "Pommes", Quantity = 8, Unit = "kg", PricePerUnit = 7.30 },
    new Product { Location = 11, Producer = "Beaud", ProductName = "Poires", Quantity = 13, Unit = "kg", PricePerUnit = 9.20 },
    new Product { Location = 12, Producer = "Corbaz", ProductName = "Pastèques", Quantity = 15, Unit = "pièce", PricePerUnit = 7.40 },
    new Product { Location = 12, Producer = "Corbaz", ProductName = "Melons", Quantity = 12, Unit = "kg", PricePerUnit = 1.60 },
    new Product { Location = 12, Producer = "Corbaz", ProductName = "Noix", Quantity = 11, Unit = "sac", PricePerUnit = 7.50 },
    new Product { Location = 12, Producer = "Corbaz", ProductName = "Raisin", Quantity = 16, Unit = "kg", PricePerUnit = 4.50 },
    new Product { Location = 12, Producer = "Corbaz", ProductName = "Pruneaux", Quantity = 20, Unit = "kg", PricePerUnit = 3.30 },
    new Product { Location = 13, Producer = "Amaudruz", ProductName = "Myrtilles", Quantity = 18, Unit = "kg", PricePerUnit = 5.70 },
    new Product { Location = 13, Producer = "Amaudruz", ProductName = "Groseilles", Quantity = 19, Unit = "kg", PricePerUnit = 8.00 },
    new Product { Location = 13, Producer = "Amaudruz", ProductName = "Pêches", Quantity = 12, Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 13, Producer = "Amaudruz", ProductName = "Haricots", Quantity = 13, Unit = "kg", PricePerUnit = 5.20 },
    new Product { Location = 13, Producer = "Amaudruz", ProductName = "Courges", Quantity = 7, Unit = "pièce", PricePerUnit = 9.60 },
    new Product { Location = 14, Producer = "Bühlmann", ProductName = "Tomates", Quantity = 12, Unit = "kg", PricePerUnit = 7.70 },
    new Product { Location = 14, Producer = "Bühlmann", ProductName = "Pommes", Quantity = 17, Unit = "kg", PricePerUnit = 1.90 },
    new Product { Location = 14, Producer = "Bühlmann", ProductName = "Poires", Quantity = 7, Unit = "kg", PricePerUnit = 3.00 },
    new Product { Location = 14, Producer = "Bühlmann", ProductName = "Pastèques", Quantity = 11, Unit = "pièce", PricePerUnit = 6.90 },
    new Product { Location = 14, Producer = "Bühlmann", ProductName = "Melons", Quantity = 7, Unit = "kg", PricePerUnit = 4.70 },
    new Product { Location = 15, Producer = "Crizzi", ProductName = "Noix", Quantity = 10, Unit = "sac", PricePerUnit = 1.60 },
    new Product { Location = 15, Producer = "Crizzi", ProductName = "Raisin", Quantity = 17, Unit = "kg", PricePerUnit = 7.80 },
    new Product { Location = 15, Producer = "Crizzi", ProductName = "Pruneaux", Quantity = 18, Unit = "kg", PricePerUnit = 9.00 },
    new Product { Location = 15, Producer = "Crizzi", ProductName = "Myrtilles", Quantity = 12, Unit = "kg", PricePerUnit = 3.00 },
    new Product { Location = 15, Producer = "Crizzi", ProductName = "Groseilles", Quantity = 12, Unit = "kg", PricePerUnit = 3.50 },
};

/*1.Chiffre d’affaire international anonyme
En transformant la liste initiale en une liste contenant:

Les 3 premières lettres du producteur suivies de "..." suivis de la dernière lettre du nom (Dumont --> Dum...t) [pseudo-anonymisation]
Le nom de l’aliment en anglais dictionnaire disponible ici
Le chiffre d’affaire maximum possible de la journée avec cet aliment (CA = Quantity * PricePerUnit)*/

var caia = products.Select(product => (product.Producer.Substring(0, 3) + "..." + product.Producer.Last(), i18n[product.ProductName], product.Quantity*product.PricePerUnit)).ToList();
//caia.ForEach(product => Console.WriteLine(product));

string filePath = "data.csv";

using (StreamWriter writer = new StreamWriter(filePath))
{
    writer.WriteLine("Seller, Product, CA");
    caia.ForEach(product => writer.WriteLine(product));
}

Console.WriteLine("CSV file created successfully!");

//quantity groseille
int groseilleQuantity = products.Where(product => product.ProductName == "Groseilles").Sum(product => product.Quantity);
Console.WriteLine("Quantité de groseille : " + groseilleQuantity);

//potential CA
var CA = products.Select(product => product.PricePerUnit * product.Quantity);
double potentialMaxCA = CA.Sum(product => product);
Console.WriteLine("Chiffre d'affaire potentiel : " + potentialMaxCA);

//highest CA
double highestCA = CA.Max(product => product);
Console.WriteLine("Le chiffre d'affaire le plus haut est de : " +  highestCA);

//lowest CA
double lowestCA = CA.Min(product => product);
Console.WriteLine("Le chiffre d'affaire le plus bas est de : " +  lowestCA);

//Average CA
double averageCA = CA.Average(product => product);
Console.WriteLine("Le chiffre d'affaire en moyenne est de : " +  averageCA);

//Highest nuts to sell
//var highestNutsSeller = products.Where(product => product.ProductName == "Noix").Max(product => product);
//Console.WriteLine("Le plus grand marchand de noix est : " + highestNutsSeller.Producer);

Console.ReadLine();

internal class Product
{
    private int location;
    private string producer;
    private string productName;
    private int quantity;
    private string unit;
    private double pricePerUnit;

    public int Location { get; set; }
    public string Producer { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; }
    public double PricePerUnit { get; set; }
}