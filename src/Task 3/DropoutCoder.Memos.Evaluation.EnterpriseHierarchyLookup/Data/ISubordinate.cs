using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.Memos.Evaluation.EnterpriseHierarchyLookup.Data {
    public interface ISubordinate : ICrewMember {
        Func<ICommander> Commander { get; }
    }
}
