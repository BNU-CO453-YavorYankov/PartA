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
        /// The result as a string of an application
        /// </summary>
        string Result { get; }
    }
}
