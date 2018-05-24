namespace SqlDataBaseService.table
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [AttributeUsage(4)]
    public class TargetTbaleAttribute : Attribute
    {
        [CompilerGenerated, DebuggerBrowsable(0)]
        private string <Name>k__BackingField;

        public TargetTbaleAttribute()
        {
            base..ctor();
            return;
        }

        public TargetTbaleAttribute(string name)
        {
            base..ctor();
            this.Name = name;
            return;
        }

        public string Name
        {
            [CompilerGenerated]
            get => 
                this.<Name>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<Name>k__BackingField = value;
                return;
            }
        }
    }
}

