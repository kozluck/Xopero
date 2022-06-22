using System;
using System.Collections.Generic;
using static GitHubComments.JSONModel;

namespace GitHubComments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string owner = String.Empty, repo = String.Empty, token = String.Empty;
            do
            {
                Console.WriteLine("Insert repository owner name:");
                owner = Console.ReadLine();
                Console.WriteLine("Insert repository name:");
                repo = Console.ReadLine();
                Console.WriteLine("Insert your token:");
                token = Console.ReadLine();
            } while (owner == null || repo == null || token == null);

            ApiHandler handler = new(owner, repo, token);
            List<Root> issuesAndPulls = handler.GetIssuesAndPulls();
            int number = 0;

            do
            {
                try
                {
                    Console.WriteLine("How many comments do you want?");
                    number = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Try one more time.");
                    continue;
                }
            } while (number <= 0);

            handler.writeCommentsToIssuesAndPulls(issuesAndPulls, number);
        }
    }
}
