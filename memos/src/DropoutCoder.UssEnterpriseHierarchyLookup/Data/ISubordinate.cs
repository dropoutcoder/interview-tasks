using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.UssEnterpriseHierarchyLookup.Data
{
    public interface ISubordinate : ICrewMember
    {
        Func<ICommander> Commander { get; }
    }
}
