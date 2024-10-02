const string PATH = "C:\\\\Temp";
(int, int) file = getFile(PATH, (0, 0));

Console.WriteLine($"Dossier : {PATH}");
Console.WriteLine($"{PATH} contient {file.Item1} fichiers et {file.Item2} dossiers");
Console.ReadLine();

(int, int) getFile(string path, (int , int ) nbr)
{
    nbr.Item1+= Directory.GetFiles(path).Count();
    nbr.Item2+= Directory.GetDirectories(path).Count();
    string[] directories = Directory.GetDirectories(path);
    foreach (var item in directories)
    {
        (int, int) newFile = getFile(item, (0, 0));
        nbr.Item1 += newFile.Item1;
        nbr.Item2 += newFile.Item2;
    }
    return (nbr.Item1, nbr.Item2);
}