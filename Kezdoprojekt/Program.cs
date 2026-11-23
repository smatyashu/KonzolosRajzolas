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

        static void belsoMenu()
        {
            string[] menupontok = { "Szín választása", "Karakter választása", "Ugrás középre", "Vissza a rajzolóhoz" };
            int pozicio = 0;
            bool menuben = true;

            while (menuben)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("=== MENÜ ===".PadRight(40));
                Console.WriteLine("".PadRight(40));

                for (int i = 0; i < menupontok.Length; i++)
                {
                    Console.SetCursorPosition(0, i + 2);
                    Console.Write((i == pozicio ? "->" : "  ") + menupontok[i].PadRight(38));
                }
                Console.WriteLine();
                Console.Write("".PadRight(40));

                Console.SetCursorPosition(0, 7);
                Console.WriteLine();
                Console.Write("Nyilak: választás \n Enter: kiválasztás \n Esc: vissza".PadRight(65));

                ConsoleKey billentyu = Console.ReadKey(true).Key;
                switch (billentyu)
                {
                    case ConsoleKey.DownArrow:
                        pozicio = (pozicio + 1) % menupontok.Length;
                        break;
                    case ConsoleKey.UpArrow:
                        pozicio = (pozicio - 1 + menupontok.Length) % menupontok.Length;
                        break;
                    case ConsoleKey.Enter:
                        if (pozicio == 0)
                        {
                            SzinValasztas();
                        }
                        else if (pozicio == 1)
                        {
                            KarakterValasztas();
                        }
                        else if (pozicio == 2)
                        {
                            kurzorPozBalrol = 65;
                            kurzorPozFentrol = 12;
                            menuben = false;
                        }
                        else
                        {
                            menuben = false;
                        }
                        break;
                    case ConsoleKey.Escape:
                        menuben = false;
                        break;
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("=== KONZOLOS RAJZOLÓ ===".PadRight(40));
            Console.WriteLine(" M - Menü megnyitása".PadRight(40));
            Console.WriteLine(" Esc - Kilépés".PadRight(40));
            Console.WriteLine("".PadRight(40));
            Console.WriteLine(" Nyilak: mozgás".PadRight(40));
            Console.WriteLine(" Szóköz: eszköz letétele/felvétele".PadRight(40));
            Console.WriteLine(" F1-F12: alakzat nyomdák".PadRight(40));
        }

        static void SzinValasztas()
        {
            ConsoleColor[] szinek = {
                ConsoleColor.Black, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen,
                ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta,
                ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.DarkGray,
                ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan,
                ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow,
                ConsoleColor.White
            };

            int index = Array.IndexOf(szinek, jelenlegiSzin);
            bool valaszt = true;

            while (valaszt)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("=== SZÍN VÁLASZTÁSA ===".PadRight(40));
                Console.WriteLine($"Bal/Jobb: váltás | Enter: alkalmaz | Esc: vissza".PadRight(40));
                Console.ForegroundColor = szinek[index];
                Console.WriteLine($"  Kiválasztott szín: {szinek[index]}".PadRight(40));
                Console.ResetColor();

                ConsoleKey billentyu = Console.ReadKey(true).Key;
                switch (billentyu)
                {
                    case ConsoleKey.RightArrow:
                        index = (index + 1) % szinek.Length;
                        break;
                    case ConsoleKey.LeftArrow:
                        index = (index - 1 + szinek.Length) % szinek.Length;
                        break;
                    case ConsoleKey.Enter:
                        jelenlegiSzin = szinek[index];
                        valaszt = false;
                        break;
                    case ConsoleKey.Escape:
                        valaszt = false;
                        break;
                }
            }
        }

        static void KarakterValasztas()
        {
            char[] karakterek = { '#', '*', '+', 'x', 'o', '@', '%', '&', '=', '~', '$', '!' };
            int index = Array.IndexOf(karakterek, jelenlegiKarakter);
            bool valaszt = true;

            while (valaszt)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("=== KARAKTER VÁLASZTÁSA ===".PadRight(40));
                Console.WriteLine("Bal/Jobb: váltás \n Enter: alkalmaz \n Esc: vissza".PadRight(40));
                Console.WriteLine($"  Kiválasztott karakter: {karakterek[index]}".PadRight(40));

                ConsoleKey billentyu = Console.ReadKey(true).Key;
                switch (billentyu)
                {
                    case ConsoleKey.RightArrow:
                        index = (index + 1) % karakterek.Length;
                        break;
                    case ConsoleKey.LeftArrow:
                        index = (index - 1 + karakterek.Length) % karakterek.Length;
                        break;
                    case ConsoleKey.Enter:
                        jelenlegiKarakter = karakterek[index];
                        valaszt = false;
                        break;
                    case ConsoleKey.Escape:
                        valaszt = false;
                        break;
                }
            }
        }

        static void AllapotKijelzes(ConsoleKey billentyu)
        {
            Console.SetCursorPosition(0, 12);

            string billentyuSzoveg = billentyu switch
            {
                ConsoleKey.UpArrow => "Felfelé nyíl",
                ConsoleKey.DownArrow => "Lefelé nyíl",
                ConsoleKey.LeftArrow => "Bal nyíl",
                ConsoleKey.RightArrow => "Jobb nyíl",
                _ => billentyu.ToString()
            };

            Console.WriteLine($" Billentyű: {billentyuSzoveg}".PadRight(40));
            Console.WriteLine($" Pozíció: ({kurzorPozBalrol - 41}, {kurzorPozFentrol - 1})".PadRight(20));
            Console.WriteLine($" Karakter: {jelenlegiKarakter}".PadRight(20));
            Console.WriteLine($" Szín: {jelenlegiSzin}".PadRight(20));
            Console.WriteLine($" Eszköz: {(rajzole ? "letéve" : "felemelve")}".PadRight(20));
        }

        static void KarakterKiirasa()
        {
            ConsoleColor elozoSzin = Console.ForegroundColor;
            Console.ForegroundColor = jelenlegiSzin;
            Console.Write(jelenlegiKarakter);
            Console.ForegroundColor = elozoSzin;
        }

        static void Main(string[] args)
        {
            menuRajzolas(25, 51);

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("=== KONZOLOS RAJZOLÓ ===");
            Console.WriteLine(" M - Menü megnyitása");
            Console.WriteLine(" Esc - Kilépés");
            Console.WriteLine();
            Console.WriteLine(" Nyilak: mozgás");
            Console.WriteLine(" Szóköz: eszköz letétele/felvétele");
            Console.WriteLine(" F1-F12: alakzat nyomdák");
            Console.WriteLine();

            bool fut = true;
            Console.SetCursorPosition(65, 12);

            while (fut)
            {
                ConsoleKey billentyu = Console.ReadKey(true).Key;

                AllapotKijelzes(billentyu);

                Console.SetCursorPosition(kurzorPozBalrol, kurzorPozFentrol);

                switch (billentyu)
                {
                    case ConsoleKey.UpArrow:
                        if (kurzorPozFentrol > 1)
                        {
                            kurzorPozFentrol--;

                            if (rajzole)
                            {
                                KarakterKiirasa();
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
                                KarakterKiirasa();
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
                                KarakterKiirasa();
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
                                KarakterKiirasa();
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
                    case ConsoleKey.M:
                        belsoMenu();


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