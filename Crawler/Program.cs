using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Crawler
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            

            HttpClient client = new HttpClient();

            try
            {
                if (args.Length == 0) throw new ArgumentNullException();
                if (!Uri.IsWellFormedUriString(args[0], UriKind.Absolute)) throw new ArgumentException("NIEPRAWIDŁOWY ADRES STRONY");
                string websiteUrl = args[0];
                HttpResponseMessage response = await client.GetAsync(websiteUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    string pattern = "[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}";
                    Regex regex = new Regex(pattern);
                    HashSet<string> emails = new HashSet<string>();
                    MatchCollection matchCollection = regex.Matches(content);
                    foreach (Match match in matchCollection)
                    {
                        emails.Add(match.Value);
                    }
                    if (emails.Count() == 0) { Console.Write("Nie znaleziono adresów email"); }
                    foreach (var email in emails)
                    {
                        Console.WriteLine(email);
                    }
                }
            }
            catch (Exception e) 
            {
               switch(e)
                {
                    case ArgumentNullException:
                        Console.WriteLine("BRAK ADRESU STRONY");
                        break;
                    case ArgumentException:
                        Console.WriteLine("NIEPRAWIDŁOWY ADRES STRONY");
                        break;
                    default: 
                        Console.WriteLine("Błąd w czasie pobierania strony");
                        break;
                }
            }
            finally 
            { 
                client.Dispose(); 
            }


            

            }

            //Console.WriteLine(args[0]);


        }


    
}
