using System;
namespace Logopeda.ORM.Entities
{
    using SQLite;

    public class Subgroups
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Column("Description"), NotNull]
        public string Description { get; set; }
    }
}