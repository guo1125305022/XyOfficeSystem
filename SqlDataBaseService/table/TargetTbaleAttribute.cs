namespace SqlDataBaseService.table
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class TargetTbaleAttribute : Attribute
    {
        public TargetTbaleAttribute(string name=null)
        {
            this.Name = name;
        }

        public string Name
        {
            get;set;
        }
    }
}

