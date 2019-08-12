using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.Memos.Evaluation.EnterpriseHierarchyLookup.Data {
    public class Commander : CrewMember, ICommander {
        public Func<IEnumerable<ICrewMember>> Subordinates { get; set; }
    }
}
