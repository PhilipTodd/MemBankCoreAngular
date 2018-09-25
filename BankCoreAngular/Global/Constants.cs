using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.Global
{
    public static class Constants
    {
        //public const string DEFAULT_FIGHTERNAME = "X-Wing";
        //public static readonly Guid DEFAULT_FIGHTER_ID = Guid.Empty; // static readonly values work, too

        public static class Tag
        {
            public static class ParentType
            {
                public const int CodeItem = 1;
                public const int SqlItem = 2;
                public const int MemoryItem = 3;
                public const int ContactItem = 4;
            }
        }

        //public enum Status
        //{
        //    Pending,
        //    AwaitingPickup,
        //    InTransit,
        //    Delivered
        //}
    }
}
