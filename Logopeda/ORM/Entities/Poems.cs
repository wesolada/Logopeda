namespace Logopeda.ORM.Entities
{
    using SQLite;

    [Table("Poems")]
    public class Poems
    {
        [PrimaryKey, Column("Title")]
        public string Title { get; set; }

        [Column("Poem"), NotNull]
        public string Poem { get; set; }
    }
}