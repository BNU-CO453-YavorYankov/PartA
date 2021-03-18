using System;

namespace Test
{
    //// Define a class to hold custom event info
    //public class CustomEventArgs : EventArgs
    //{
    //    public CustomEventArgs(string message)
    //    {
    //        Message = message;
    //    }

    //    public string Message { get; set; }
    //}

    // Class that publishes an event
    public class Publisher
    {
        // Declare the event using EventHandler<T>

        public void DoSomething()
        {
            // Write some code that does something useful here
            // then raise the event. You can also raise an event
            // before you execute a block of code.
            OnRaiseCustomEvent(new CustomEventArgs("Event triggered"));
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += $" at {DateTime.Now}";

                // Call to raise the event.
                raiseEvent(this, e);
            }
        }
    }

    //Class that subscribes to an event
    class Subscriber
    {
        private readonly string _id;

        public Subscriber(string id, Publisher pub)
        {
            _id = id;

            // Subscribe to the event
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        // Define what actions to take when the event is raised.
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"{_id} received this message: {e.Message}");
        }
    }

    class Program
    {
        static void Main()
        {
            var pub = new Publisher();
            var sub1 = new Subscriber("sub1", pub);
            var sub2 = new Subscriber("sub2", pub);

            // Call the method that raises the event.
            pub.DoSomething();

            // Keep the console window open
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }


    #region

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        ConsoleModifications.Run();

    //        Menu.Items();
    //    }
    //}

    //public class Menu
    //{
    //    //Current option
    //    private static int Item { get; set; }

    //    private static ConsoleKeyInfo Key { get; set; }

    //    public static void Items()
    //    {
    //        string[] menuItems =
    //        {
    //            "Add journey",
    //            "Calendar",
    //            "Exit"
    //        };

    //        //Loop iterate all options 
    //        do
    //        {
    //            Console.Clear();

    //            Item = PrintMenuItems(Item, menuItems);

    //            Key = Console.ReadKey(true);

    //            Item = PressedKey(Key, Item, menuItems);

    //        } while (Key.Key.ToString() != "Enter");

    //        switch (Item)
    //        {
    //            case 0:
    //                Options.AddJourney();
    //                break;
    //            case 2:
    //                Options.Exit();
    //                break;
    //        }
    //    }

    //    private static int PressedKey(ConsoleKeyInfo key, int item, string[] menuItems)
    //    {
    //        switch (key.Key.ToString())
    //        {
    //            case "DownArrow":
    //                item++;
    //                if (item > menuItems.Length - 1)
    //                    item = 0;
    //                break;
    //            case "UpArrow":
    //                item--;
    //                if (item < 0)
    //                    item = menuItems.Length - 1;
    //                break;
    //        }
    //        return item;
    //    }

    //    private static int PrintMenuItems(int item, string[] menuItems)
    //    {
    //        ConsoleModifications.TextAlign();

    //        for (int i = 0; i < menuItems.Length; i++)
    //        {
    //            Console.ResetColor();
    //            ConsoleModifications.SetCursorPosition(i, menuItems[i].Length);
    //            if (item == i)
    //            {
    //                ConsoleModifications.ChangeColour();
    //                Console.WriteLine(menuItems[i]);
    //            }
    //            else
    //            {
    //                Console.WriteLine(menuItems[i]);
    //            }

    //        }
    //        return item;
    //    }
    //}

    //public class ConsoleModifications
    //{
    //    public static void Run()
    //    {
    //        SetSize();
    //        CursorVisible();
    //    }

    //    public static void SetSize() => Console.SetWindowSize(80, 20);

    //    public static void CursorVisible() => Console.CursorVisible = false;

    //    public static void TextAlign()
    //    {
    //        for (int i = 0; i < 8; i++)
    //            Console.WriteLine();
    //    }

    //    public static void SetCursorPosition(int iteration, int menuItemLenght)
    //    {
    //        Console.SetCursorPosition(
    //            (Console.WindowWidth - menuItemLenght) / 2
    //            , Console.CursorTop);
    //    }

    //    public static void ChangeColour()
    //    {
    //        Console.ForegroundColor = ConsoleColor.DarkGreen;
    //    }
    //}

    //public class Options
    //{
    //    #region AddJourney
    //    public static void AddJourney()
    //    {
    //        Console.Clear();

    //        //using (var db = new YYLTDDbContext())
    //        //{
    //        //    Tracker journey = NewJourney();

    //        //    db.Trackers.Add(journey);
    //        //    db.SaveChanges();
    //        //}
    //    }

    //    private static void NewJourney()
    //    {
    //        //var journey = new Tracker();
    //        ////Current date
    //        //journey.Date = DateTime.Now.Date;
    //        //Console.WriteLine(journey.Date);

    //        ////Is working on that day?
    //        //Console.Write("Do you work on that day? Y/N : ");
    //        //var isWork = Console.ReadLine();

    //        //if (isWork.ToLower() == "y")
    //        //{
    //        //    journey.IsWork = true;

    //        //    Console.Write("Route : ");
    //        //    journey.Route = short.Parse(Console.ReadLine());

    //        //    Console.Write("Miles : ");
    //        //    journey.Miles = short.Parse(Console.ReadLine());

    //        //    Console.Write("Stops : ");
    //        //    journey.StopsToDeliver = short.Parse(Console.ReadLine());
    //        //}
    //        //else
    //        //{
    //        //    journey.IsWork = false;
    //        //}
    //        //return journey;
    //    }
    //    #endregion

    //    #region Calendar
    //    public static void Calendar()
    //    {
    //        //using (var db = new YYLTDDbContext())
    //        //{

    //        //}
    //    }
    //    #endregion

    //    public static void Exit()
    //    {
    //        Console.Clear();
    //    }
    //}
    #endregion
}
