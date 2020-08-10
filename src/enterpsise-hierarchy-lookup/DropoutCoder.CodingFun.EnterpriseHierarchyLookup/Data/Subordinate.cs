using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.CodingFun.EnterpriseHierarchyLookup.Data {
    public class Subordinate : CrewMember, ISubordinate {
        public Func<ICommander> Commander { get; set; }
    }
}
