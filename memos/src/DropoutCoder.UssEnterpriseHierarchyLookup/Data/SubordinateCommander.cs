using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.UssEnterpriseHierarchyLookup.Data
{
    public class SubordinateCommander : CrewMember, ISubordinate, ICommander
    {
        public Func<IEnumerable<ICrewMember>> Subordinates { get; set; }
        public Func<ICommander> Commander { get; set; }
    }
}
