using SQLite;


namespace NotesFragView
{
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
    }
}