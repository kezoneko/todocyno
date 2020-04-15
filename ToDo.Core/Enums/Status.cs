using System;
using System.ComponentModel;

namespace ToDo.Core.Enums
{
    public enum Status
    {
        [Description("Undone")]
        Undone = 0,

        [Description("Done")]
        Done = 1,
        
        [Description("In Process")]
        InProcess = 2
    }
}
