using System.Text.RegularExpressions;

namespace Crawler
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string websiteUrl = args[0];
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(websiteUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                string pattern = "[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}";
                Regex regex = new Regex(pattern);
                //HashSet<string> emails = new HashSet<string>();
                MatchCollection matchCollection= regex.Matches(content);
                //emails.Add(regex.Match(content).ToString());

                foreach(var email in matchCollection)
                {
                    Console.WriteLine(email);
                }

            }

            //Console.WriteLine(args[0]);


        }


    }
}