using System;
using System.ComponentModel;

namespace ToDo.Core.Enums
{
    public enum Status
    {
        [Description("Done")]
        Done = 1,
        [Description("Undone")]
        Undone = 0,
        [Description("In Process")]
        InProcess = 2
    }
}
