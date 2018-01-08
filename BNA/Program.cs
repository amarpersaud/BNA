using System;
namespace BNA
{
    public class Program
    {

        public static void Main()
        {

            int linesPerSin = 100;
            double angPerLine = Math.PI * (360.0 / linesPerSin) / 180.0;
            double lines = linesPerSin * 3;
            double amplitude = 40;
            char[] text = "boolbean".ToCharArray();
            double slope = 1.6;
            int charIndex = 0;

            bool lastIs = false;


            string pre = @"
╔═════════════════════════════════════════════════════════════════════════════════╗
║                                                                                 ║ 
║                                                                                 ║ 
║                                                                                 ║
║                           ██████╗ ███╗   ██╗ █████╗                             ║
║                           ██╔══██╗████╗  ██║██╔══██╗                            ║
║                           ██████╔╝██╔██╗ ██║███████║                            ║
║                           ██╔══██╗██║╚██╗██║██╔══██║                            ║
║                           ██████╔╝██║ ╚████║██║  ██║                            ║
║                           ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝                            ║
║                                                                                 ║            
║                           The Source Code of all Code                           ║
║                                                                                 ║
║                                      Bases                                      ║
║                           ===========================                           ║
║                               -b      -o      -l                                ║
║                               -e      -a      -n                                ║
║                                                                                 ║
║                                Typical Pairings                                 ║
║                           ===========================                           ║
║                               -bo     -ol    -lb                                ║
║                               -be     -ea    -an                                ║ 
║                                                                                 ║ 
║                                                                                 ║ 
╚═════════════════════════════════════════════════════════════════════════════════╝


";

            Console.WriteLine(pre);

            for (int i = -6; i < lines + 6; i++)
            {
                int NS1 = (int)Math.Round(amplitude * (roundGraph(i * angPerLine, slope) + 1.0));
                int NS2 = (int)Math.Round(amplitude * (-roundGraph(i * angPerLine, slope) + 1.0));

                int left = min(NS1, NS2);
                int right = max(NS1, NS2);



                Console.Write(new String(' ', left) + text[charIndex]);


                bool completeLine = ((right - left) % text.Length) == 0;
                bool canDrawLine = (i >= 0 && i <= lines);

                if (canDrawLine && completeLine && i != 0 && !lastIs)
                {
                    lastIs = true;
                    if (right - left != 0)
                    {
                        int b = charIndex + 1;
                        for (int j = 0; j < right - left - 1; j++)
                        {
                            if (b >= text.Length) { b = 0; }
                            Console.Write(text[b]);
                            b++;
                        }
                        Console.WriteLine(text[charIndex]);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                else
                {
                    lastIs = false;
                    string rightSide = new String(' ', right - left) + text[charIndex];
                    Console.WriteLine(rightSide.Substring(1, rightSide.Length - 1));
                }
                charIndex++;
                if (charIndex >= text.Length)
                {
                    charIndex = 0;
                }
            }
        }
        static int max(int a, int b)
        {
            return a > b ? a : b;
        }
        static int min(int a, int b)
        {
            return a < b ? a : b;
        }

        static int abs(int x)
        {
            return x < 0 ? -x : x;
        }

        static double roundGraph(double x, double slope)
        {
            double sinus = Math.Sin(x);
            double sign = (sinus < 0 ? -1 : 1);

            return sign * (1.0 - Math.Pow(1.0 - Math.Abs(sinus), slope));
        }

    }
}