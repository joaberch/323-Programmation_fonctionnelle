int nbrFileCount = 0;
const string PATH = "C:\\\\Temp";
getFile(PATH);

Console.Write($"nbr : {nbrFileCount}");
Console.ReadLine();

void getFile(string path)
{
    nbrFileCount += Directory.GetFiles(path).Count();
    string[] directories = Directory.GetDirectories(path);
    foreach (string directory in directories)
    {
        getFile(directory);
    }
}