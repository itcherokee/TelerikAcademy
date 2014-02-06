// Task 11: Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations 
//          and methods and holds a version in the format major.minor (e.g. 2.11). 
//          Apply the version attribute to a sample class and display its version at runtime.

namespace VersionAttribute
{
    using System;

    public struct VersionStruct
    {
        public int Major;
        public int Minor;
    }

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute : System.Attribute
    {
        private VersionStruct version;

        public VersionAttribute(int major, int minor)
        {
            this.version.Major = major;
            this.version.Minor = minor;
        }

        public string Version
        {
            get
            {
                return this.version.Major + "." + this.version.Minor;
            }
        }
    }
}