using System;

namespace CheckListwithEnumFlag.Models
{
    [Flags]
    public enum FlaggedDayOfWeek
    {
        None = 0x0,
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x16,
        Friday = 0x32,
        Saturday= 0x61
    }
}
