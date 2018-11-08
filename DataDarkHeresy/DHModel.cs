namespace DataDarkHeresy
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class DHModel : DbContext
    {

        public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<PlayerMental> PlayerMentals { get; set; }
        public virtual DbSet<PlayerClass> PlayerClasses { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<ClassEvolution> ClassEvolutions { get; set; }
        public virtual DbSet<Amelioration> Ameliorations { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        public class PersonalInfo
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int? Age { get; set; }
            public string Description { get; set; }
            public Gender PersonalGender { get; set; }
            public string Build { get; set; }
            public string Hair { get; set; }
            public string Complexion { get; set; }
        }

        public class Player
        {
            [Key]
            public int Id { get; set; }
            public PersonalInfo Info { get; set; }
            public Characteristic Stats { get; set; }
            public string Background { get; set; }
            public int XpToSpend { get; set; }
            public int TotalXP { get; set; }
            public int TreshHold { get; set; }
            public int CurrentTreshHold { get; set; }
        }

        public class PlayerMental
        {
            [Key]
            public int Id { get; set; }
            public int CorruptionValue { get; set; }
            public int InsanityValue { get; set; }
            public string Mutation { get; set; }
            public string Malignance { get; set; }
            public string MentalDisorder { get; set; }
        }

        public class PlayerClass
        {
            [Key]
            public int Id { get; set; }
            [Index(IsUnique = true)]
            public string ClassName { get; set; }
            public ClassEvolution Grades { get; set; }
            public List<Skill> SkillList { get; set; }
            public string Role { get; set; }
            public string EliteAdvances { get; set; }
            public string Divination { get; set; }
            public string Notes { get; set; }
            public string Quirks { get; set; }

        }

        public class Skill
        {
            [Key]
            public int Id { get; set; }
            [Index(IsUnique = true)]
            public string Name { get; set; }
            public int modifValue { get; set; }
            public bool positive { get; set; }
        }

        public class ClassEvolution
        {
            [Key]
            public int Id { get; set; }
            [Index(IsUnique = true)]
            public string Name { get; set; }
            public PlayerClass ClassRelated { get; set; }
            public List<Amelioration> Ameliorations { get; set; }
        }

        public class Amelioration
        {
            [Key]
            public int Id { get; set; }
            public string Type { get; set; }
            public int Cost { get; set; }
            public string condition { get; set; }
        }

        public enum Gender
        {
            [Description("Male")]
            MALE,
            [Description("Female")]
            FEMALE,
            [Description("Undefined")]
            UNDEFINED
        }

        public enum AmeliorationType
        {
            [Description("C")]
            C
        }

        public enum OrganisationLevel
        {
            [Description("Local Influence")]
            LOCAL,
            [Description("Regional Influence")]
            REGIONAL,
            [Description("National Influence")]
            NATIONAL,
            [Description("All the Planet")]
            PLANETARY,
            [Description("All the galaxy & beyond")]
            INTERGALACTICAL
        }

        public class Organisation
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public OrganisationLevel Influence { get; set; }
        }

        public class Characteristic
        {
            public int Id { get; set; }
            public int WeaponSkill { get; set; }
            public int BalisticSkill { get; set; }
            public int Strength { get; set; }
            public int Toughness { get; set; }
            public int Agility { get; set; }
            public int Intelligence { get; set; }
            public int Perception { get; set; }
            public int WillPower { get; set; }
            public int FellowShip { get; set; }
            public int Influence { get; set; }
        }

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ItemAvailibility Rarity { get; set; }
            public int Cost { get; set; }
        }

        public class Weapon
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public WeaponClass Class { get; set; }
            public int Range { get; set; }
            public string Rof { get; set; }
            public int Damage { get; set; }
            public int Clip { get; set; }
            public string Special { get; set; }
            public int Weight { get; set; }
            public ItemAvailibility Rarity { get; set; }
        }

        public class Test
        {
            public int TestId { get; set; }
        }

        public enum WeaponClass
        {
            [Description("Pistol")]
            PISTOL,
            [Description("Basic")]
            BASIC,
            [Description("Heavy")]
            HEAVY,
            [Description("Thrown")]
            THROWN,
            [Description("Melee")]
            MELEE
        }

        public enum ItemAvailibility
        {
            [Description("Automatic")]
            UBIQUITOUS = 100,
            [Description("Easy")]
            ABUNDANT = 30,
            [Description("Routine")]
            PLENTIFUL = 20,
            [Description("Ordinary")]
            COMMON = 10,
            [Description("Challenging")]
            AVERAGE = 0,
            [Description("Difficult")]
            SCARCE = -10,
            [Description("Hard")]
            RARE = -20,
            [Description("Very Hard")]
            VERY_RARE = -30,
            [Description("Arduous ")]
            EXTREMELY_RARE = -40,
            [Description("Punishing ")]
            NEAR_UNIQUE = -50,
            [Description("Hellish")]
            UNIQUE = -60
        }
        public DHModel()
            : base("name=DHModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
