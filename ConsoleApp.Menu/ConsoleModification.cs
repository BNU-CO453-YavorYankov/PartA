namespace ConsoleApp.Menu
{
    using System;
    
    /// <summary>
    /// This class modify the console as
    /// set window size, 
    /// hides or show the cursor, 
    /// set the cursor position
    /// </summary>
    /// <author>Yavor Yankov</author>
    public class ConsoleModification
    {
        /// <summary>
        /// Width of the console window
        /// </summary>
        private const int WIDTH = 80;
        /// <summary>
        /// Height of the console window
        /// </summary>
        private const int HEIGHT = 40;

        /// <summary>
        /// Initialize new instance of this class 
        /// and it is responsible to modify the console
        /// </summary>
        public ConsoleModification()
        {
            SetSize();
            HideCursor();
        }

        /// <summary>
        /// Hides the cursor of the console
        /// </summary>
        public static void HideCursor() => Console.CursorVisible = false;

        /// <summary>
        /// Shows the cursor of the console
        /// </summary>
        public static void ShowCursor() => Console.CursorVisible = true;

        /// <summary>
        /// Set cursor position depending on the lenght of the menu item`s name
        /// </summary>
        /// <param name="menuItemLenght">The lenght of the name of the menu item.</param>
        public static void SetCursorPosition(int menuItemLenght)
            => Console.SetCursorPosition(
                (Console.WindowWidth - menuItemLenght) / 2,
                Console.CursorTop);

        /// <summary>
        /// Change the colour of the current menu item to dark green
        /// </summary>
        public static void ChangeColour()
            => Console.ForegroundColor = ConsoleColor.DarkGreen;

        /// <summary>
        /// Reset the color of the console
        /// </summary>
        public static void ResetColor() => Console.ResetColor();
     
        /// <summary>
        /// Align the text on the console
        /// </summary>
        public static void AlignText()
        {
            for (int i = 0; i < 8; i++)
                Console.WriteLine();
        }

        /// <summary>
        /// Sets size of the console
        /// </summary>
        private void SetSize() => Console.SetWindowSize(WIDTH, HEIGHT);
    }
}
