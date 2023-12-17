using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.UssEnterpriseHierarchyLookup.Data
{
    public interface ICommander : ICrewMember
    {
        Func<IEnumerable<ICrewMember>> Subordinates { get; }
    }
}
