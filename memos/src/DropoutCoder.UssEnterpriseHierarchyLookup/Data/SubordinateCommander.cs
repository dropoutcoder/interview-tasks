using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.CodingFun.EnterpriseHierarchyLookup.Data {
    public class SubordinateCommander : CrewMember, ISubordinate, ICommander {
        public Func<IEnumerable<ICrewMember>> Subordinates { get; set; }
        public Func<ICommander> Commander { get; set; }
    }
}
