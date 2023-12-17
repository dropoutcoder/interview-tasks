using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.UssEnterpriseHierarchyLookup
{
    [Flags]
    public enum LookupDirection : int
    {
        None = 0,
        Down = 1,
        Up = 2
    }
}
