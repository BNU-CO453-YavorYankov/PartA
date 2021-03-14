namespace ConsoleApp.Menu
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class creates a menu with different items.
    /// Items are links to the staring point of each application.
    /// The navigation through the menu is with arrow keys and enter btn.
    /// </summary>
    /// <author>Yavor Yankov</author>
    public class Menu
    {
        // Declare the event using EventHandler<T>
        public event EventHandler<string> LaunchApplicationEvent;

        private const string MENU_HEADING = "BNU CO453 Applications Programming 2020-2021!";
        private const string DISTANCE_CONVERTER = "Distance Converter";
        private const string BMI_CALCULATOR = "Body Mass Index Calculator";
        private const string STUDENT_GRADES = "Student Grades";

        /// <summary>
        /// Keeps the item that is chosen by the user
        /// </summary>
        private int _item;
        /// <summary>
        /// Store the last pressed key
        /// </summary>
        private ConsoleKeyInfo _key;
        /// <summary>
        /// All applications names as well as exit item
        /// </summary>
        private readonly List<string> _menuItems = new List<string>();

        /// <summary>
        /// Create new Menu instance and add menu items
        /// </summary>
        /// <param name="menuItems">The items of this menu</param>
        public Menu(List<string> menuItems)
        {
            menuItems.Add("Exit");

            this._menuItems = menuItems;
            
            new ConsoleModification();
        }

        /// <summary>
        /// Starts the menu
        /// </summary>
        public void Run()
        {
            PrintMenuHeading();

            SetItem();

            ExecuteChoice();
        }

        /// <summary>
        /// Executes the user`s choice item as raise the launch application event
        /// with application name as an arg.
        /// </summary>
        private void ExecuteChoice()
        {
            Console.Clear();
            ConsoleModification.ShowCursor();

            switch (this._item)
            {
                case 0:
                    OnLaunchApplicationEvent(DISTANCE_CONVERTER);
                    break;
                case 1:
                    OnLaunchApplicationEvent(BMI_CALCULATOR);
                    break;
                case 2:
                    OnLaunchApplicationEvent(STUDENT_GRADES);
                    break;
                case 3:
                    ExitCommand();
                    break;
            }
        }

        /// <summary>
        /// Wrap event invocations inside a protected virtual method
        /// to allow derived classes to override the event invocation behavior
        /// </summary>
        /// <param name="appName">The name of the app to be launched</param>
        protected virtual void OnLaunchApplicationEvent(string appName)
        {
            var raiseEvent = LaunchApplicationEvent;

            if (raiseEvent != null)
            {
                //Invoke the event
                LaunchApplicationEvent?.Invoke(this, appName);
            }
        }

        /// <summary>
        /// Iterate through the menu items as 
        /// clear the console, print the items, 
        /// read the user`s key while the user 
        /// press enter key and the item is set.
        /// </summary>
        private void SetItem()
        {
            do
            {
                Console.Clear();

                PrintMenuItems();

                this._key = Console.ReadKey(true);

                GetPressedKey();

            } while (this._key.Key.ToString() != "Enter");
        }

        /// <summary>
        /// Get the last pressed key
        /// </summary>
        private void GetPressedKey()
        {
            switch (this._key.Key.ToString())
            {
                case "DownArrow":
                    
                    this._item++;
                    
                    if (this._item > this._menuItems.Count - 1)
                        this._item = 0;
                    
                    break;

                case "UpArrow":
                    
                    this._item--;
                    
                    if (this._item < 0)
                        this._item = this._menuItems.Count - 1;
                    
                    break;
            }
        }

        /// <summary>
        /// Print out all menu items and highlight the current item
        /// </summary>
        private void PrintMenuItems()
        {
            ConsoleModification.AlignText();
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            PrintMenuHeading();

            for (int i = 0; i < this._menuItems.Count; i++)
            {
                ConsoleModification.ResetColor();

                ConsoleModification.SetCursorPosition(this._menuItems[i].Length);
                if (this._item == i)
                {
                    ConsoleModification.ChangeColour();
                }
                 
                Console.WriteLine(this._menuItems[i]);
            }
        }

        /// <summary>
        /// Print out the menu heading
        /// </summary>
        private void PrintMenuHeading() 
        {
            ConsoleModification.SetCursorPosition(MENU_HEADING.Length);

            Console.WriteLine($"{MENU_HEADING} \n\r\n\r");
        }

        /// <summary>
        /// Exit the menu
        /// </summary>
        private void ExitCommand() 
        {
            Environment.Exit(1);
        }
    }
}
