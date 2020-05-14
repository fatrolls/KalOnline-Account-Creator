using Combinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCreator
{
    public class GenerateRandom
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch = ' ';
            int choice;

            for (int i = 0; i < size; i++)
            {
                choice = random.Next(1, 3);

                switch (choice)
                {
                    case 1:
                        ch = Convert.ToChar(random.Next(97, 122)); //Lowercase ASCII letters
                        break;
                    case 2:
                        ch = Convert.ToChar(random.Next(48, 57)); //Numbers
                        break;
                    case 3:
                        ch = Convert.ToChar(random.Next(65, 90)); //Uppercase ASCII Letters
                        break;
                }

                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static string RandomNumber(int min, int max)
        {
            return random.Next(min, max).ToString();
        }

        public static int RandomNumber(int max)
        {
            return random.Next(max);
        }

        public static string RandomStringOnlyChars(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch = ' ';

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(random.Next(97, 122));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static List<string> GenerateDotTrick(string email, int maxEmails)
        {
            string emailName = email.Replace("@gmail.com", string.Empty).Trim();
            emailName = emailName.Replace(".", string.Empty).Trim(); //remove previous dot trick transformations.

            List<string> results = new List<string>();
            IEnumerable<int> positions = Enumerable.Range(1, emailName.Length - 1);
            for (int i = 1; i <= positions.Count(); ++i)
            {
                Combinations<int> positionGenerator = new Combinations<int>(positions, i);
                foreach (int[] currentPositions in positionGenerator)
                {
                    StringBuilder emailBuilder = new StringBuilder(emailName);
                    foreach (int currentPosition in currentPositions.Reverse())
                    {
                        emailBuilder.Insert(currentPosition, '.');
                    }
                    results.Add(emailBuilder.ToString());
                    if (results.Count == maxEmails)
                    {
                        return results;
                    }
                }
            }
            return results;
        }

        public static List<string> GenerateCaptialTrick(string email, int maxEmails)
        {
            string emailName = email.Replace("@gmail.com", string.Empty).Trim();
            emailName = emailName.ToLower().Trim(); //remove previous Captial trick transformation.

            List<string> results = new List<string>();
            IEnumerable<int> positions = Enumerable.Range(0, emailName.Length - 1);
            for (int i = 0; i <= positions.Count(); ++i)
            {
                Combinations<int> positionGenerator = new Combinations<int>(positions, i);
                foreach (int[] currentPositions in positionGenerator)
                {
                    StringBuilder emailBuilder = new StringBuilder(emailName);
                    foreach (int currentPosition in currentPositions.Reverse())
                    {
                        char letter = emailBuilder[currentPosition];
                        if(Char.IsLetter(letter))
                        {
                            if (Char.IsUpper(letter))
                                letter = Char.ToLower(letter);
                            else
                                letter = Char.ToUpper(letter);
                        }
                        emailBuilder[currentPosition] = letter;
                    }
                    if(!results.Contains(emailBuilder.ToString()))
                        results.Add(emailBuilder.ToString());
                    if (results.Count == maxEmails)
                    {
                        return results;
                    }
                }
            }
            return results;
        }
    }
}
