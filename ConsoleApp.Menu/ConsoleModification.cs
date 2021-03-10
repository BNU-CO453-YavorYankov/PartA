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
        private const int HEIGHT = 80;

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
        public void HideCursor() => Console.CursorVisible = false;

        /// <summary>
        /// Shows the cursor of the console
        /// </summary>
        public void ShowCursor() => Console.CursorVisible = true;

        /// <summary>
        /// Set cursor position depending on the lenght of the menu item`s name
        /// </summary>
        /// <param name="menuItemLenght">The lenght of the name of the menu item.</param>
        public void SetCursorPosition(int menuItemLenght)
            => Console.SetCursorPosition(
                (Console.WindowWidth - menuItemLenght) / 2,
                Console.CursorTop);

        /// <summary>
        /// Change the colour of the current menu item to dark green
        /// </summary>
        public void ChangeColour()
            => Console.ForegroundColor = ConsoleColor.DarkGreen;
     
        /// <summary>
        /// Sets size of the console
        /// </summary>
        private void SetSize() => Console.SetWindowSize(WIDTH, HEIGHT);
    }
}
