namespace DAL
    {
        using System;
        using System.Data.Entity;
        using System.Linq;

        public class FitnessDB : DbContext
        {
            public FitnessDB()
                : base("FitnessDB")
            {
            }

            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<Visit> Visits { get; set; }
            public virtual DbSet<Visitor> Visitors { get; set; }
        }
    }