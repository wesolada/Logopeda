namespace Logopeda.ORM.Entities
{
    using SQLite;

    public class Groups
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Column("Description"), NotNull]
        public string Description { get; set; }
    }
}