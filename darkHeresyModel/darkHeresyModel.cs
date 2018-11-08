namespace darkHeresyModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class DarkHeresyModel : DbContext
    {
        // Your context has been configured to use a 'darkHeresyModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'darkHeresyModel.darkHeresyModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'darkHeresyModel' 
        // connection string in the application configuration file.
        public DarkHeresyModel()
            : base("name=DarkHeresyModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        //public virtual DbSet<MyEntity> MyEntities { get; set; }
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

        public virtual DbSet<Test> Tests { get; set; }
    

    }

    [Table("PersonalInfo")]
    public class PersonalInfo
    {
        [Key]
        public int PersonalInfoId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Description { get; set; }
        public virtual Gender PersonalGender { get; set; }
        public string Build { get; set; }
        public string Hair { get; set; }
        public string Complexion { get; set; }
    }

    [Table("Player")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public virtual PersonalInfo Info { get; set; }
        public virtual Characteristic Stats { get; set; }
        public string Background { get; set; }
        public int XpToSpend { get; set; }
        public int TotalXP { get; set; }
        public int TreshHold { get; set; }
        public int CurrentTreshHold { get; set; }
    }

    [Table("PlayerMental")]
    public class PlayerMental
    {
        [Key]
        public int PlayerMentalId { get; set; }
        public int CorruptionValue { get; set; }
        public int InsanityValue { get; set; }
        public string Mutation { get; set; }
        public string Malignance { get; set; }
        public string MentalDisorder { get; set; }
    }

    [Table("PlayerClass")]
    public class PlayerClass
    {
        [Key]
        public int PlayerClassId { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<ClassEvolution> Grades { get; set; }
        public virtual ICollection<Skill> SkillList { get; set; }
        public string Role { get; set; }
        public string EliteAdvances { get; set; }
        public string Divination { get; set; }
        public string Notes { get; set; }
        public string Quirks { get; set; }

    }

    [Table("Skill")]
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int modifValue { get; set; }
        public bool positive { get; set; }
    }

    [Table("ClassEvolution")]
    public class ClassEvolution
    {
        [Key]
        public int ClassEvolutionId { get; set; }
        [Required]
        public string ClassEvolutionName { get; set; }
        public virtual PlayerClass ClassRelated { get; set; }
        public virtual ICollection<Amelioration> Ameliorations { get; set; }
    }

    [Table("Amelioration")]
    public class Amelioration
    {
        [Key] public int AmeliorationId { get; set; }
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

    [Table("Organisation")]
    public class Organisation
    {
        [Key] public int OrganisationId { get; set; }
        public string OrganisationName { get; set; }
        public virtual OrganisationLevel Influence { get; set; }
    }

    [Table("Characteristic")]
    public class Characteristic
    {
        [Key] public int CharacteristicId { get; set; }
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

    [Table("Item")]
    public class Item
    {
        [Key] public int ItemId { get; set; }
        public string ItemName { get; set; }
        public virtual ItemAvailibility Rarity { get; set; }
        public int Cost { get; set; }
    }

    [Table("Weapon")]
    public class Weapon
    {
        [Key] public int WeaponId { get; set; }
        public string WeaponName { get; set; }
        public virtual WeaponClass Class { get; set; }
        public int Range { get; set; }
        public string Rof { get; set; }
        public int Damage { get; set; }
        public int Clip { get; set; }
        public string Special { get; set; }
        public int Weight { get; set; }
        public virtual ItemAvailibility Rarity { get; set; }
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

    [Table("Test")]
    public class Test
    {
        [Key] public int TestId { get; set; }
        public string TestName { get; set; }
    }

}