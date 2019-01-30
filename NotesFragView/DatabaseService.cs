using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;


namespace NotesFragView
{
    class DatabaseService
    {
        public SQLiteConnection db;
        public static DatabaseService DatabaseConnection { get; set; }
        public static List<Note> NotesList { get; set; }

        public DatabaseService()
        {
            CreateDatabase();
            CreateTableWithData();
            NotesList = GetAllNotes().ToList();
        }

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "notes12.db3");
            db = new SQLiteConnection(dbPath);
        }

        public void CreateTableWithData()
        {
            db.CreateTable<Note>();
            if (db.Table<Note>().Count() == 0)
            {
                var newNote = new Note
                {
                    Title = "Test1",
                    Description = "Test1"
                };
                db.Insert(newNote);
                newNote.Title = "Test2";
                newNote.Description = "TestDesc2";
                db.Insert(newNote);
                newNote.Title = "Test3";
                newNote.Description = "adasdasd";
                db.Insert(newNote);
            }
        }

        public void AddNote(string title, string description)
        {
            var newNote = new Note
            {
                Title = title,
                Description = description
            };
            db.Insert(newNote);
        }

        public void UpdateNote(int id, string description)
        {
            var newNote = new Note
            {
                Id = id,
                Title = GetOneNote(id).Title,
                Description = description
            };
            db.Update(newNote);
        }

        public TableQuery<Note> GetAllNotes()
        {
            var table = db.Table<Note>();
            return table;
        }

        public void DeleteNote(int id)
        {
            var noteToDelete = new Note();
            noteToDelete.Id = id;
            db.Delete(noteToDelete);
        }

        public Note GetOneNote(int id)
        {
            var table = GetAllNotes();
            foreach (var item in table)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new Exception("Table is empty");
        }
    }
}