using System.Linq;
using darkHeresyModel;

namespace DispatchService.Models
{
    public class RequestModel
    {
        Player Players { get; set; }
        PlayerMental PlayerMentals { get; set; }
        PlayerClass PlayerClasses { get; set; }
        Skill Skills { get; set; }
        ClassEvolution ClassEvolutions { get; set; }
        Amelioration Ameliorations { get; set; }
        Organisation Organisations { get; set; }
        Characteristic Characteristics { get; set; }
        Item Items { get; set; }
        Weapon Weapons { get; set; }

        public object FindCorrectDTO()
        {
            return new object[] { Players, PlayerMentals, PlayerClasses, Skills, ClassEvolutions, Ameliorations, Organisations, Characteristics, Items, Weapons }.FirstOrDefault(w => w != null);
        }
    }
}