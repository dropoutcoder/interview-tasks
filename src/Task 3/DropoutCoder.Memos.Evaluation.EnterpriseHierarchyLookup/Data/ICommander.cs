using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.Memos.Evaluation.EnterpriseHierarchyLookup.Data {
    public interface ICommander : ICrewMember {
        Func<IEnumerable<ICrewMember>> Subordinates { get; }
    }
}
