string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };

List<string> selectedWords1 = words.Where(w => !w.Contains("b")).ToList();
List<string> selectedWords2 = words.Where(w => w.Length >= 5).ToList();
List<string> selectedWords3 = words.Where(w => w.Length == Math.Round(words.Average(w => w.Length))).ToList();

Console.WriteLine("Filtre 1 :");
foreach (var word in selectedWords1)
{
    Console.WriteLine(word);
}

Console.WriteLine("\n\nFiltre 2 :");
foreach (var word in selectedWords2)
{
    Console.WriteLine(word);
}

Console.WriteLine("\n\nFiltre 3 :");
foreach (var word in selectedWords3)
{
    Console.WriteLine(word);
}
/////////////////////////////////////////////////////////////////////////////// EXO 2 //////////////////////////////////////////////////////////

Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

List<string> selectedWords4 = words.ToList();

Epsilon(words.ToList());

Console.ReadLine();

double[] Epsilon(List<string> word)
{
    double[] totalEpsilon = { 0 };
    int epsilonIndex = 0;
    Dictionary<char, double> letterFrequencies = new Dictionary<char, double>
        {
            {'a', 7.11},
            {'b', 1.14},
            {'c', 3.18},
            {'d', 3.67},
            {'e', 12.10},
            {'f', 1.11},
            {'g', 1.23},
            {'h', 1.11},
            {'i', 6.59},
            {'j', 0.34},
            {'k', 0.29},
            {'l', 4.96},
            {'m', 2.62},
            {'n', 6.39},
            {'o', 5.02},
            {'p', 2.49},
            {'q', 0.65},
            {'r', 6.07},
            {'s', 6.51},
            {'t', 5.92},
            {'u', 4.49},
            {'v', 1.11},
            {'w', 0.17},
            {'x', 0.38},
            {'y', 0.46},
            {'z', 0.15}
        };

    //List<string> wordList = word.ToList().ForEach();

    foreach (var item in word)
    {
        foreach (var item1 in item)
        {
            double epsilonNumber = 0;
            foreach (var item2 in letterFrequencies)
            {
                if(item1 == item2.Key)
                {
                    epsilonNumber += item2.Value;
                    //Console.WriteLine(item1 + "  " + item2 + "   " + item);
                }
            }
            epsilonIndex++;
            //totalEpsilon[epsilonIndex] = epsilonNumber;
            Console.WriteLine(epsilonNumber);
        }

    }

    return totalEpsilon;
}