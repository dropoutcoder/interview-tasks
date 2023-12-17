using System;
using System.Collections.Generic;
using System.Text;

namespace DropoutCoder.UssEnterpriseHierarchyLookup.Data
{
    public abstract class CrewMember : ICrewMember
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        bool ICrewMember.IsCommander
        {
            get
            {
                return this is ICommander;
            }
        }
        bool ICrewMember.IsSubordinate
        {
            get
            {
                return this is ISubordinate;
            }
        }
    }
}
