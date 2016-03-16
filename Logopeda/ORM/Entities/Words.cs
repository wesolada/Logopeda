namespace Logopeda.ORM.Entities
{
    using SQLite;

    [Table("Words")]
    public class Words
    {
        [PrimaryKey, Column("Word")]
        public string Word { get; set; }

        [Column("GroupId"), NotNull]
        public int GroupId { get; set; }

        [Column("SubGroupId"), NotNull]
        public int SubGroupId { get; set; }
    }
}