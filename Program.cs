namespace ErsteAufgabe
{
    public class HS
    {

        //Normal Main that starts reading the first Method
        public static void Main(string[] args)
        {
            //Fixes the Error IDE0060 that comes when args is null
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            DataInformation();
        }

        //Variables
        public static void DataInformation()
        {
            //The Character that is used to Draw the Letters
            const char Symbol = '#';

            //The Height and Width of the Letters
            int Height = 9;
            int Width = Height;
            int _HeightS = Height + 2;

            //The Booleans to allow the changes to make it Move Left, Move Right or Get Big and Small
            bool _BigandSmall = true;
            bool _Movement = true;

            //Integer that makes everything Move from one Side to the other
            int Movement = 0;

            //Inputs so the Color can be changed through all the While constantly
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            ConsoleColor currentBackground = Console.BackgroundColor;

            //The Loop for making it Bigger, Smaller or Move from Left to Right
            while (true)
            {
                foreach (var color in colors)
                {
                    if (color == currentBackground) continue;

                    Console.ForegroundColor = color;

                    //Makes the Letters move to Right because the Boolean is true
                    if (_Movement == true)
                    {
                        Console.CursorVisible = false;
                        Console.Clear();
                        Movement++;
                        DrawH(Height, Width, Symbol, Movement);
                        DrawS(_HeightS, Width, Symbol, Movement);
                        Thread.Sleep(10);
                    }
                    //Makes it Stop at the designated Integer and changes the Booleans statement
                    if (Movement == 40)
                    {
                        _Movement = false;
                    }
                    //Makes the Letters move to the Left because the Boolean is false
                    if (_Movement == false)
                    {
                        Console.CursorVisible = false;
                        Console.Clear();
                        Movement--;
                        DrawH(Height, Width, Symbol, Movement);
                        DrawS(_HeightS, Width, Symbol, Movement);
                        Thread.Sleep(10);
                    }
                    //Makes it stop at the designated Integer and changes the Booleans statement
                    if (Movement == 0)
                    {
                        _Movement = true;
                    }
                    //Checks if the Boolean to make it big is true and if the Height is lower than the designated Integer
                    if (_BigandSmall == true && Height < 12)
                    {
                        Height++;
                        Width++;
                        _HeightS++;
                        Console.Clear();
                        DrawH(Height, Width, Symbol, Movement);
                        DrawS(_HeightS, Width, Symbol, Movement);
                        Thread.Sleep(80);
                    }
                    //Checks if the Height has hit the designated Integer
                    else if (Height == 12)
                    {
                        _BigandSmall = false;

                    }
                    //Checks if the Boolean to make it big is false
                    if (_BigandSmall == false)
                    {
                        Height--;
                        Width--;
                        _HeightS--;
                        Console.Clear();
                        DrawH(Height, Width, Symbol, Movement);
                        DrawS(_HeightS, Width, Symbol, Movement);
                        Thread.Sleep(80);
                    }
                    if (Height == 5)
                    {
                        _BigandSmall = true;
                    }
                }
            }
        }

        //Build of Letter H
        public static void DrawH(int Height, int Width, char Symbol, int Movement)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {

                    //Vertikal Lines

                    Console.SetCursorPosition(i + (Height / Height % 1) + Movement, j); // Vertical Line Left

                    if (i % Height == 0)
                    {
                        Console.WriteLine(Symbol);
                    }

                    Console.SetCursorPosition(Height + Movement, j); //Vertical Line Right
                    if (i % Height == 0)
                    {
                        Console.WriteLine(Symbol);
                    }

                    //Horizontal Line

                    Console.SetCursorPosition(i + Movement, j); // Horizontal Line 
                    if (j % Width == Width / 2)
                    {
                        Console.WriteLine(Symbol);
                    }
                }
            }
        }

        //Build of the Letter S
        public static void DrawS(int Height, int Width, char Symbol, int Movement)
        {
            for (int k = 0; k < Height; k++)
            {
                for (int l = 0; l < Width; l++)
                {

                    //Vertikal Lines

                    // Top Left Vertikal Line
                    Console.SetCursorPosition(Height + Movement, l % Width / 2);
                    if (k % Height == 2)
                    {
                        Console.WriteLine(Symbol);
                    }

                    // Bottom Right Vertikal Line
                    Console.SetCursorPosition(k + (Height + Height - 1) + Movement, l % Width / 2 + Width / 2); 
                    if (k % Height == 0)
                    {
                        Console.WriteLine(Symbol);
                    }

                    // Horizonal Lines

                    // Top Horizontal Line
                    Console.SetCursorPosition(k + Height + Movement, l);
                    if (l % Width == 0) 
                    {
                        Console.WriteLine(Symbol);
                    }

                    // Middle Horizontal Line 
                    Console.SetCursorPosition(k + Height + Movement, l); 
                    if (l % Width == Width / 2)
                    {
                        Console.WriteLine(Symbol);
                    }

                    // Bottom Horizonal Line
                    Console.SetCursorPosition(k + Height + Movement, l);
                    if (l % Width == Width - 1) 
                    {
                        Console.WriteLine(Symbol);
                    }
                }
            }
        }
    }
}