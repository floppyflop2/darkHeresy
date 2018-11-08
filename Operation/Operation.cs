
using darkHeresyBiz.src;
using darkHeresyBiz.src.Biz.PlayerManagement;
using darkHeresyBiz.src.Biz.PlayerMentalManagement;
using darkHeresyBiz.src.PlayerManagement;

namespace Operations
{
    public static class Operation
    {

        public static object Get(string caller, int id)
        {
            return GetBusinessLogic(caller).Get(id);
        }
      
        public static object Add(string caller, object obj)
        {
            return GetBusinessLogic(caller).Add(obj);
        }

        public static void Remove(string caller, object obj)
        {
            GetBusinessLogic(caller).Remove(obj);
        }

        public static void Modify(string caller, object obj)
        {
            GetBusinessLogic(caller).Modify(obj);
        }


        public static BusinessLogic GetBusinessLogic(string caller)
        {
            switch (caller)
            {
                case "Player":
                    return new PlayerManager();
                case "PersonalInfo":
                    return new PersonalInfoManager();
                case "PlayerClass":
                    return new PlayerClassManager();
                case "PlayerMental":
                    return new PlayerMentalManager();
                case "Skill":
                    return new SkillManager();
                case "ClassEvolution":
                    return new ClassEvolutionManager();
                case "Organisation":
                    return new OrganisationManager();
                case "Characteristic":
                    return new CharacteristicManager();
                case "Item":
                    return new ItemManager();
                case "Weapon":
                    return new WeaponManager();

                default:
                    return null;
            }
        }
    }
}
