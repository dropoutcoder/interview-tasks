using System;
using DropoutCoder.UssEnterpriseHierarchyLookup.Data;

namespace DropoutCoder.UssEnterpriseHierarchyLookup
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MemoryContext();
            context.Initialize();

            var lookup = new RecursiveLookup();

            var member = context.CrewMembers.GetByName(CrewNames.WorfSonOfMog);

            var result = lookup.Lookup(member, LookupDirection.Down | LookupDirection.Up);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} is a {item.Gender}");
            }

            Console.ReadLine();
        }
    }
}
