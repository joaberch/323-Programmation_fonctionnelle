/*Selon la liste de films suivants, réaliser les filtres suivants:

Filtrer les films qui ne sont pas du genre "Comédie" or "Drame".
Identifier les films dont le rating est inférieur à 7.
Afficher les films réalisés avant 2000.
Trouver les films qui n'ont pas de doublage en français.
Identifier les films non présents sur netflix*/

using System.Linq;

List<Movie> frenchMovies = new List<Movie>() {
new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
};

List<Movie> notDrameOrComedie = frenchMovies.Where(movie => movie.Genre != "Comédie" && movie.Genre != "Drame").ToList();
Console.WriteLine("1.\n");
notDrameOrComedie.ForEach(m => Console.WriteLine(m.Title)) ;

List<Movie> lowRatedMovies = frenchMovies.Where(movie => movie.Rating < 7).ToList(); //no data with condition
Console.WriteLine("\n2.\n");
lowRatedMovies.ForEach(m => Console.WriteLine(m.Title));

List<Movie> oldMovies = frenchMovies.Where(movie => movie.Year < 2000).ToList();
Console.WriteLine("\n3.\n");
oldMovies.ForEach(m => Console.WriteLine(m.Title));

List<Movie> withoutVF = frenchMovies.Where(movie => !movie.LanguageOptions.Contains("Français")).ToList();
Console.WriteLine("\n4.\n");
withoutVF.ForEach(m => Console.WriteLine(m.Title));

List<Movie> notOnNetflix = frenchMovies.Where(movie => !movie.StreamingPlatforms.Contains("Netflix")).ToList();
Console.WriteLine("\n5.\n");
notOnNetflix.ForEach(m => Console.WriteLine(m.Title));

List<Movie> allFilter = frenchMovies.Where(movie => movie.Genre != "Comédie" && movie.Genre != "Drame" && movie.Rating < 7 && movie.Year < 2000 && !movie.LanguageOptions.Contains("Français") && !movie.StreamingPlatforms.Contains("Netflix")).ToList();
Console.WriteLine("\nCumul :\n");
allFilter.ForEach(m => Console.WriteLine(m.Title));

Console.Write("Filtre du genre : ");
string userGenre = Console.ReadLine();
Console.Write("rating minimum : ");
int userRating = Convert.ToInt32(Console.ReadLine());

List<Movie> userinput = frenchMovies.Where(movie => movie.Genre == userGenre && movie.Rating >= userRating /*&& movie.Year < 3000 && !movie.LanguageOptions.Contains("Français") && !movie.StreamingPlatforms.Contains("Netflix")*/).ToList();
Console.WriteLine("\nDynamique.\n");
userinput.ForEach(m => Console.WriteLine(m.Title));

Console.ReadLine();

internal class Movie
{
    private string title;
    private string genre;
    private double rating;
    private int year;
    private string[] languageOptions;
    private string[] streamingPlatforms;

    public string Title { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public int Year { get; set; }
    public string[] LanguageOptions { get; set; }
    public string[] StreamingPlatforms { get; set;}
}