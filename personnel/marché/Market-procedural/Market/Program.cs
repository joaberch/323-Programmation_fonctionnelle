int peachSellerNbr = 0;

string[] sellers = new string[50] ;
int[] stand = new int[50];
int[] quantity = new int[50];
int nbrSeller = 0;

int index = 0;

char[] seperators = { ';' };

StreamReader sr = new StreamReader("./market.csv");

string data = sr.ReadLine();

//get data from CSV
while ((data = sr.ReadLine()) != null)
{
    //Get the peach nbr
    if (data.Contains("Pêche"))
    {
        peachSellerNbr++;
    }

    //Get every watermelon seller
    if(data.Contains("Melon"))
    {
        string[] words = data.Split(";");

        stand[nbrSeller] = Convert.ToInt32(words[0]);
        sellers[nbrSeller] = words[1];
        quantity[nbrSeller++] = Convert.ToInt32(words[3]);
    }
}

int piece = quantity[0];

for (int i = 0; i < nbrSeller; i++)
{
    if (quantity[i] > piece)
    {
        piece = quantity[i];
        index = i;
    }
}

Console.WriteLine("Il y a " + peachSellerNbr + " vendeurs de pêches");
Console.WriteLine("C'est " + sellers[index] + " qui a le plus de pastèques (stand " + stand[index] + ", " + quantity[index] + " pièces)");

Console.ReadLine();
