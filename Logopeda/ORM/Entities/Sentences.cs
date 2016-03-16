namespace Logopeda.ORM.Entities
{
    using SQLite;

    public class Sentences
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Column("Sentence"), NotNull]
        public string Sentence { get; set; }
    }
}