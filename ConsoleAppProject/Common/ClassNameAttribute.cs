namespace ConsoleAppProject.Common
{
    using System;
    
    /// <summary>
    /// The custom attribute class name will be used in the commands from app03.
    /// This attribute cannot be used more than one in a same class, 
    /// also can be used only on classes.
    /// </summary>
    /// <author>Yavor Yankov</author>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ClassNameAttribute : Attribute
    {
        /// <summary>
        /// backing field of the Name prop
        /// </summary>
        private string _name;

        /// <summary>
        /// Create the attribute and assign the name 
        /// of a given class that is applid on. 
        /// </summary>
        /// <param name="name"></param>
        public ClassNameAttribute(string name)
        {
            this._name = name;
        }

        /// <summary>
        /// The name of the class
        /// </summary>
        public virtual string Name => this._name;
    }
}
