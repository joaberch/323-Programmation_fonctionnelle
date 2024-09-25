using Newtonsoft.Json;

const string baseAddress = "https://swapi.dev/";

Console.WriteLine("Quel est le film Star Wars dont le titre est le plus long ?");

string[] words = { "aba", "coucou" };
Console.WriteLine(words.Where(word => !word.Contains('x')));

Console.Read();

using (var client = new HttpClient())
{
    using (var response = client.GetAsync(baseAddress).Result)
    {
        if (response.IsSuccessStatusCode)
        {
            var customerJsonString = await response.Content.ReadAsStringAsync();
            //var cust = JsonConvert.DeserializeObject<Response>(customerJsonString);
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
