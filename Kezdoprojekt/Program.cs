
namespace projektcucc
{
    internal class Program
    {
        static bool rajzole = true;
        static int kurzorX;
        static int kurzorY;

        static void menuRajzolas(int magassag, int szelesseg)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("=== KONZOLOS RAJZOLÓ ===");
            Console.WriteLine(" M - Menü megnyitása");
            Console.WriteLine(" X - Kilépés");
            Console.WriteLine();
            Console.WriteLine($" Pozíció: ({kurzorX}, {kurzorY})");
            Console.WriteLine(" Karakter: {currentSkin}");
            Console.WriteLine(" Szín: {currentColor}");
            Console.WriteLine($" Eszköz: {(rajzole ? "letéve" : "felemelve")}");
            Console.WriteLine();
            Console.WriteLine(" Nyilak: mozgás");
            Console.WriteLine(" Szóköz: eszköz váltás");
            Console.WriteLine(" F1-F12: alakzat nyomdák");
            Console.WriteLine();
            Console.SetCursorPosition(40, 0);
            for (int sor = 0; sor <= magassag; sor++)
            {
                for (int oszlop = 0; oszlop <= szelesseg; oszlop++)
                {
                    if (sor == 0)
                    {
                        Console.Write('_');
                    }
                    else if (sor == magassag)
                    {
                        Console.Write('-');
                    }
                    else if (oszlop == szelesseg || oszlop == 0)
                    {
                        Console.Write('|');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.SetCursorPosition(40, sor + 1);

            }
        }

        static void Main(string[] args)
        {
            menuRajzolas(25, 50);
            bool fut = true;
            while (fut)
            {
                ConsoleKey billentyu = Console.ReadKey(true).Key;
                Console.SetCursorPosition(0, 20);
                Console.Write(("Billentyű: " + billentyu).PadRight(75));

                switch (billentyu)
                {
                    case ConsoleKey.F1:
                        Console.SetCursorPosition(26, 4); // oszlop, majd sor
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write('#');
                        Console.ResetColor();
                        break;
                    case ConsoleKey.B:
                        if (OperatingSystem.IsWindows())
                            Console.Beep(800, 120);
                        else
                            Console.Write("\a");
                        break;
                    case ConsoleKey.L:
                        string utvonal = Path.Combine(AppContext.BaseDirectory, "minta.txt");
                        if (File.Exists(utvonal))
                        {
                            string[] sorok = File.ReadAllLines(utvonal);
                            for (int i = 0; i < sorok.Length && i < 5; i++)
                            {
                                Console.SetCursorPosition(26, 7 + i);
                                Console.Write(sorok[i]);
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(26, 7);
                            Console.Write("A mintafájl nem található.");
                        }
                        break;
                    case ConsoleKey.Escape:
                        fut = false;
                        break;
                }
            }
        }
    }
}
