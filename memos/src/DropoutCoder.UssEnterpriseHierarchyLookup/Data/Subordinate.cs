using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.UssEnterpriseHierarchyLookup.Data
{
    public class Subordinate : CrewMember, ISubordinate
    {
        public Func<ICommander> Commander { get; set; }
    }
}
