using System.Net.Security;

namespace DebuggerDecoder
{
    /* Debugger Scavenger Hunt
     * In each Clue method, you will find a variable that is used to calculate the answer.
     * Follow the instructions for each clue to find the answer.
     * You can check your answers by running the program and entering the answers for each one.
     * When you are done (for better or worse), take a screenshot of the 
     * program, your answers, and the result verification code and submit it as the assignment.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalRight = 0;
            int totalWrong = 0;
            int hashVerify = 0;
            string vert = "+--------------------------------------------+";

            Clue1();

            Clue2();

            Clue3();

            Clue4();

            Clue5();
            Console.WriteLine("8456".GetStableHashCode());
            Console.WriteLine(vert);
            Console.WriteLine("Welcome To The Debugger Scavenger Hunt!");
            Console.WriteLine("Use the debugger to find the clues hidden in the variables.");
            Console.WriteLine(vert);

            // Check answer for each clue
            for (int i = 0; i < 5; i++)
            {
                int hash = CheckAnswer(i);
                if (hash != 0)
                {
                    Console.WriteLine($"Clue #{i+1} is correct!");
                    hashVerify += hash;
                    totalRight++;
                }
                else
                {
                    Console.WriteLine($"Clue #{i+1} is WRONG!");
                    totalWrong++;
                }
                Console.WriteLine($"{vert}\n");
            }

            Console.WriteLine($"\n\nYou got {totalRight} right and {totalWrong} wrong.");
            Console.WriteLine($"Result Verification Code: {hashVerify + totalRight}");
            
        }

        // Clue #1
        // What is the final value of clue1?
        // You can probably get this one without the debugger.
        // But it's good practice for when you need it later.
        private static void Clue1()
        {
            string clue1 = "Debugger";
            clue1 += "Decoder";
        }


        // Clue #2
        // What is the final value of clue2?
        private static void Clue2()
        {
            string clue2 = "You say goodbye and I say";
            clue2 = string.Concat(Enumerable.Repeat("hello, ", 3));
        }

        // Clue #3
        // What is the value of clue3 WHEN i == 5?
        private static void Clue3()
        {
            double clue3 = 36.9;

            for (int i=3; i<9; i++)
            {
                clue3 += clue3 * Math.PI * i;
                int foo = clue3.ToString().GetStableHashCode();
            }
        }

        // Clue #4
        // What are the FIRST 4 digits of clue4 (ignore negative/positive)?
        // WHEN i = 5150?
        // HINT: You might want to check out the breakpoint settings
        //   unless you want to hit continue 4,283 times.
        private static void Clue4()
        {
            int clue4 = 0;

            for (int i=867; i<5309; i++)
            {
                if (i % 2 == 0)
                {
                    clue4 += i.ToString().GetStableHashCode();
                }
            }
        }

        // Clue #5
        // The final clue is found by combining the following:
        // The value of 'digit' when i = 405
        // with the final value of clue5

        // One way to do this is to use multiple break points.
        private static void Clue5()
        {
            string clue5 = "";

            for (int i=0; i < 1000; i++)
            {
                string digit = i.ToString().GetStableHashCode().ToString().Substring(3, 1);
                if (i % 31 == 0)
                {
                    clue5 += digit;
                }
            }
        }


        // Methods used for calculating answers and generating codes
        public static int CheckAnswer(int questionNumber)
        {
            Dictionary<int, (int, string)> d = new Dictionary<int, (int, string)>();
            d.Add(0, (947109595, "Clue #1: "));
            d.Add(1, (-1388073274, "Clue #2: "));
            d.Add(2, (1165526880, "Clue #3: "));
            d.Add(3, (1346211403, "Clue #4: "));
            d.Add(4, (1518383759, "Clue #5: "));

            Console.WriteLine($"{d[questionNumber].Item2}");
            string answer = Console.ReadLine();

            return answer.GetStableHashCode() == d[questionNumber].Item1 ? answer.GetStableHashCode() : 0;
        }
    }

    // Extension method for getting a stable hash code
    // Taken from GetHashCode with the seed removed from
    // https://stackoverflow.com/questions/36845430/persistent-hashcode-for-strings
    public static class StringExtensionMethods
    {
        public static int GetStableHashCode(this string str)
        {
            unchecked
            {
                int hash1 = 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length && str[i] != '\0'; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1 || str[i + 1] == '\0')
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }
    }
}