namespace Crawler
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string websiteUrl = args[0];
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(websiteUrl);



            Console.WriteLine(response);


        }


    }
}