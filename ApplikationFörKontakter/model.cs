using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace MigrationsDemo
{
    public class BlogContext : DbContext
    {
        public DbSet<person> person { get; set; }
    }
    public class person
    {
        [Key]
        public int nyckel { get; set; }
        public string namn { get; set; }
        public string gatuadress { get; set; }
        public string postnummer { get; set; }
        public string postort { get; set; }
        public string telefon { get; set; }
        public string epost { get; set; }
        public string födelsedag { get; set; }

        public override string ToString()
        {
            return namn;
        }
    }
}