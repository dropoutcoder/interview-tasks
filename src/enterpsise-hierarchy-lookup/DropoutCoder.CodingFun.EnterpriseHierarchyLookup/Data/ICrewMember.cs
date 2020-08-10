using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.CodingFun.EnterpriseHierarchyLookup.Data {
    public interface ICrewMember {
        string Name { get; }
        Gender Gender { get; }
        bool IsCommander { get; }
        bool IsSubordinate { get; }
    }
}
