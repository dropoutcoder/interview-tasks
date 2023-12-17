using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.CodingFun.EnterpriseHierarchyLookup.Data {
    public interface ICommander : ICrewMember {
        Func<IEnumerable<ICrewMember>> Subordinates { get; }
    }
}
