namespace darkHeresyModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class darkHeresyModel : DbContext
    {
        // Your context has been configured to use a 'darkHeresyModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'darkHeresyModel.darkHeresyModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'darkHeresyModel' 
        // connection string in the application configuration file.
        public darkHeresyModel()
            : base("name=darkHeresyModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class PersonalInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Description { get; set; }
        public Gender PersonalGender { get; set; }
    }

    public class Player
    {
        [Key]
        public int Id { get; set; }
        public PersonalInfo Info { get; set; }
    }

    public class PlayerClass
    {
        [Key]
        public string ClassName { get; set; }
        public ClassEvolution Grades { get; set; }
    }

    public class ClassEvolution
    {
        [Key]
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
        [Description("M")]
        MALE,
        [Description("F")]
        FEMALE,
        [Description("U")]
        UNDEFINED
    }

    public enum AmeliorationType
    {
        [Description("C")]
        C
    }

}