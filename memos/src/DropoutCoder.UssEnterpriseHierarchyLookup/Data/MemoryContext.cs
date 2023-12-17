using System.Collections.Generic;
using System.Linq;

namespace DropoutCoder.UssEnterpriseHierarchyLookup.Data
{
    public class MemoryContext
    {
        public IEnumerable<ICrewMember> CrewMembers { get; private set; }

        public void Initialize()
        {
            CrewMembers = new List<ICrewMember>() {
                new Subordinate {
                    Name = CrewNames.AlexanderRozhenko,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.KEhleyr)
                },
                new Subordinate {
                    Name = CrewNames.JulianBashir,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.AlyssaOgawa)
                },
                new Subordinate {
                    Name = CrewNames.TashaYar,
                    Gender = Gender.Woman,
                    Commander = () => CrewMembers.GetCommander(CrewNames.WorfSonOfMog)
                },
                new SubordinateCommander {
                    Name = CrewNames.KEhleyr,
                    Gender = Gender.Woman,
                    Commander = () => CrewMembers.GetCommander(CrewNames.WorfSonOfMog),
                    Subordinates = () => CrewMembers.GetSubordinates(CrewNames.KEhleyr)
                },
                new Subordinate {
                    Name = CrewNames.WesleyCrusher,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.BeverlyCrusher)
                },
                new SubordinateCommander {
                    Name = CrewNames.AlyssaOgawa,
                    Gender = Gender.Woman,
                    Commander = () => CrewMembers.GetCommander(CrewNames.BeverlyCrusher),
                    Subordinates = () => CrewMembers.GetSubordinates(CrewNames.AlyssaOgawa)
                },
                new SubordinateCommander {
                    Name = CrewNames.WorfSonOfMog,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.WilliamRiker),
                    Subordinates = () => CrewMembers.GetSubordinates(CrewNames.WorfSonOfMog)
                },
                new Subordinate {
                    Name = CrewNames.Guinan,
                    Gender = Gender.Woman,
                    Commander = () => CrewMembers.GetCommander(CrewNames.WilliamRiker)
                },
                new SubordinateCommander {
                    Name = CrewNames.BeverlyCrusher,
                    Gender = Gender.Woman,
                    Commander = () => CrewMembers.GetCommander(CrewNames.WilliamRiker),
                    Subordinates = () => CrewMembers.GetSubordinates(CrewNames.BeverlyCrusher)
                },
                new Subordinate {
                    Name = CrewNames.LwaxanaTrio,
                    Gender = Gender.Woman,
                    Commander = () => CrewMembers.GetCommander(CrewNames.DeanaTroi)
                },
                new Subordinate {
                    Name = CrewNames.ReginaldBarkley,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.DeanaTroi)
                },
                new Subordinate {
                    Name = CrewNames.MrData,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.JordiLaForge)
                },
                new Subordinate {
                    Name = CrewNames.MilesOBrien,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.JordiLaForge)
                },
                new SubordinateCommander {
                    Name = CrewNames.WilliamRiker,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.JeanLucPickard),
                    Subordinates = () => CrewMembers.GetSubordinates(CrewNames.WilliamRiker)
                },
                new SubordinateCommander {
                    Name = CrewNames.DeanaTroi,
                    Gender = Gender.Woman,
                    Commander = () => CrewMembers.GetCommander(CrewNames.JeanLucPickard),
                    Subordinates = () => CrewMembers.GetSubordinates(CrewNames.DeanaTroi)
                },
                new SubordinateCommander {
                    Name = CrewNames.JordiLaForge,
                    Gender = Gender.Man,
                    Commander = () => CrewMembers.GetCommander(CrewNames.JeanLucPickard),
                    Subordinates = () => CrewMembers.GetSubordinates(CrewNames.JordiLaForge)
                },
                new Commander {
                    Name = CrewNames.JeanLucPickard,
                    Gender = Gender.Man,
                    Subordinates = () => CrewMembers.GetSubordinates(CrewNames.JeanLucPickard)
                }
            };
        }
    }

    public class CrewNames
    {
        public static string AlexanderRozhenko = "Alexander Rozhenko";
        public static string JulianBashir = "Julian Bashir";
        public static string TashaYar = "Tasha Yar";
        public static string KEhleyr = "K'Ehleyr";
        public static string WesleyCrusher = "Wesley Crusher";
        public static string AlyssaOgawa = "Alyssa Ogawa";
        public static string WorfSonOfMog = "Worf son of Mog";
        public static string Guinan = "Guinan";
        public static string BeverlyCrusher = "Beverly Crusher";
        public static string LwaxanaTrio = "Lwaxana Trio";
        public static string ReginaldBarkley = "Reginald Barkley";
        public static string MrData = "Mr. Data";
        public static string MilesOBrien = "Miles O'Brien";
        public static string WilliamRiker = "William Riker";
        public static string DeanaTroi = "Deana Troi";
        public static string JordiLaForge = "Jordi La Forge";
        public static string JeanLucPickard = "Jean Luc Pickard";
    }

    public static class CrewMemberExtension
    {
        public static ICrewMember GetByName(this IEnumerable<ICrewMember> source, string name)
        {
            return source.SingleOrDefault(m => m.Name == name);
        }

        public static ICommander GetCommander(this IEnumerable<ICrewMember> source, string name)
        {
            return source.OfType<ICommander>().Single(m => m.Name == name);
        }

        public static IEnumerable<ICrewMember> GetSubordinates(this IEnumerable<ICrewMember> source, string name)
        {
            return source.OfType<ISubordinate>().Where(s => s.Commander.Invoke().Name == name);
        }
    }
}