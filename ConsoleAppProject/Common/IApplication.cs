namespace ConsoleAppProject.Common
{
    /// <summary>
    /// Interface that is responsible to provide related functionalities to inherited class.
    /// In each application should has Result property.
    /// </summary>
    /// <author>Yavor Yankov</author>
    public interface IApplication
    {
        /// <summary>
        /// The result as a string of the application
        /// </summary>
        string Result { get; }
        
        /// <summary>
        /// Runs the application
        /// </summary>
        void Run();

        /// <summary>
        /// Validate all of the properties of the application
        /// </summary>
        void Validation();

    }
}
