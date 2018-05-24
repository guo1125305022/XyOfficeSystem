namespace SqlDataBaseService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Page<T>
    {
        [CompilerGenerated, DebuggerBrowsable(0)]
        private int <CountPage>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private int <CurrentPage>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private int <EndIndex>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private List<T> <Items>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private int <PageSize>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private int <StartIndex>k__BackingField;

        public Page()
        {
            base..ctor();
            return;
        }

        public int CountPage
        {
            [CompilerGenerated]
            get => 
                this.<CountPage>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<CountPage>k__BackingField = value;
                return;
            }
        }

        public int CurrentPage
        {
            [CompilerGenerated]
            get => 
                this.<CurrentPage>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<CurrentPage>k__BackingField = value;
                return;
            }
        }

        public int EndIndex
        {
            [CompilerGenerated]
            get => 
                this.<EndIndex>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<EndIndex>k__BackingField = value;
                return;
            }
        }

        public List<T> Items
        {
            [CompilerGenerated]
            get => 
                this.<Items>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<Items>k__BackingField = value;
                return;
            }
        }

        public int PageSize
        {
            [CompilerGenerated]
            get => 
                this.<PageSize>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<PageSize>k__BackingField = value;
                return;
            }
        }

        public int StartIndex
        {
            [CompilerGenerated]
            get => 
                this.<StartIndex>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<StartIndex>k__BackingField = value;
                return;
            }
        }
    }
}

