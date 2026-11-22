namespace rajzolo
{
    internal class Program
    {
        static bool rajzole = false;
        static int kurzorPozBalrol = 65;
        static int kurzorPozFentrol = 12;
        static char jelenlegiKarakter = '#';
        static ConsoleColor jelenlegiSzin = ConsoleColor.White;

        static void menuRajzolas(int magassag, int szelesseg)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("=== KONZOLOS RAJZOLÓ ===");
            Console.WriteLine(" M - Menü megnyitása");
            Console.WriteLine(" Esc - Kilépés");
            Console.WriteLine();
            Console.WriteLine(" Nyilak: mozgás");
            Console.WriteLine(" Szóköz: eszköz letétele/felvétele");
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
            Console.SetCursorPosition(65, 12);

            while (fut)
            {
                ConsoleKey billentyu = Console.ReadKey(true).Key;

                Console.SetCursorPosition(0, 10);

                if (billentyu == ConsoleKey.UpArrow)
                {
                    Console.WriteLine(" Billentyű: Felfelé nyíl");
                }
                else if (billentyu == ConsoleKey.DownArrow)
                {
                    Console.WriteLine(" Billentyű: Lefelé nyíl");
                }
                else if (billentyu == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine(" Billentyű: Bal nyíl");
                }
                else if (billentyu == ConsoleKey.RightArrow)
                {
                    Console.WriteLine(" Billentyű: Jobb nyíl");
                }
                else
                {
                    Console.WriteLine((" Billentyű: " + billentyu).PadRight(40));
                }

                Console.WriteLine(($" Pozíció: ({kurzorPozBalrol - 41}, {kurzorPozFentrol - 1})").PadRight(20));
                Console.WriteLine($" Karakter: {jelenlegiKarakter}");
                Console.WriteLine($" Szín: {jelenlegiSzin}");
                Console.WriteLine($" Eszköz: {(rajzole ? "letéve" : "felemelve")}");

                Console.SetCursorPosition(kurzorPozBalrol, kurzorPozFentrol);

                switch (billentyu)
                {
                    case ConsoleKey.UpArrow:
                        if (kurzorPozFentrol > 1)
                        {
                            kurzorPozFentrol--;

                            if (rajzole)
                            {
                                Console.Write(jelenlegiKarakter);
                            }

                            Console.SetCursorPosition(kurzorPozBalrol, kurzorPozFentrol);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (kurzorPozFentrol < 24)
                        {
                            kurzorPozFentrol++;

                            if (rajzole)
                            {
                                Console.Write(jelenlegiKarakter);
                            }

                            Console.SetCursorPosition(kurzorPozBalrol, kurzorPozFentrol);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (kurzorPozBalrol > 41)
                        {
                            kurzorPozBalrol--;

                            if (rajzole)
                            {
                                Console.Write(jelenlegiKarakter);
                            }

                            Console.SetCursorPosition(kurzorPozBalrol, kurzorPozFentrol);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (kurzorPozBalrol < 90)
                        {
                            kurzorPozBalrol++;

                            if (rajzole)
                            {
                                Console.Write(jelenlegiKarakter);
                            }

                            Console.SetCursorPosition(kurzorPozBalrol, kurzorPozFentrol);
                        }
                        break;

                    case ConsoleKey.Spacebar:
                        if (rajzole)
                        {
                            rajzole = false;
                        }
                        else
                        {
                            rajzole = true;
                        }
                        break;

                    case ConsoleKey.F1:
                        Console.SetCursorPosition(26, 4);
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

                            for (int i = 0; i < sorok.Length && i < 24; i++)
                            {
                                Console.SetCursorPosition(41, 1 + i);

                                string szoveg = sorok[i];

                                if (szoveg.Length > 49)
                                {
                                    szoveg = szoveg.Substring(0, 49);
                                }

                                Console.Write(szoveg);
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(41, 1);
                            Console.Write("A mintafájl nem található.");
                        }
                        break;

                    case ConsoleKey.Escape:
                        fut = false;
                        break;
                }
            }

            Console.ResetColor();
        }
    }
}