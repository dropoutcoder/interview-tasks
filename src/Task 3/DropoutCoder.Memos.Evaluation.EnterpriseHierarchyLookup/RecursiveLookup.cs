using System.Collections.Generic;
using System.Linq;

using DropoutCoder.Memos.Evaluation.EnterpriseHierarchyLookup.Data;

namespace DropoutCoder.Memos.Evaluation.EnterpriseHierarchyLookup {
    public class RecursiveLookup {
        public IEnumerable<ICrewMember> Lookup(ICrewMember member, LookupDirection direction) {
            if (direction == LookupDirection.None) {
                return Enumerable.Empty<ICrewMember>();
            }

            var result = new List<ICrewMember>();

            if (direction.HasFlag(LookupDirection.Up)) {
                RecursiveUp(member, ref result);
            }

            if (direction.HasFlag(LookupDirection.Down)) {
                RecursiveDown(member, ref result);                
            }

            return result;
        }

        private void RecursiveUp(ICrewMember member, ref List<ICrewMember> result) {
            if (!member.IsSubordinate) {
                return;
            }

            var commander = (member as ISubordinate).Commander.Invoke();

            if(commander != null) {
                result.Add(commander);
                if (commander.IsSubordinate) {
                    RecursiveUp(commander, ref result);
                }
            }
        }

        private void RecursiveDown(ICrewMember member, ref List<ICrewMember> result) {
            if (!member.IsCommander) {
                return;
            }

            var subordinates = (member as ICommander).Subordinates.Invoke();

            foreach (var subordinate in subordinates) {
                result.Add(subordinate);
                if (subordinate.IsCommander) {
                    RecursiveDown(subordinate, ref result);
                }
            }
        }
    }
}
