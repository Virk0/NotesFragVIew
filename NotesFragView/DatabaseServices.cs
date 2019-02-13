using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace NotesFragView
{
    class DatabaseServices
    {
        public SQLiteConnection db;
        public static DatabaseServices DatabaseConnection { get; set; }
        public static List<Note> NotesList { get; set; }

        public DatabaseServices()
        {
            CreateDatabase();
            AddSomeDataToDataBase();
            NotesList = GetAllNotes().ToList();
        }

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydatabase6.db3");
            db = new SQLiteConnection(dbPath);
        }

        public void AddSomeDataToDataBase()
        {
            db.CreateTable<Note>();
            if (db.Table<Note>().Count() == 0)
            {
                var newNote = new Note
                {
                    NoteTitle = "Test1",
                    NoteContent = "Test2"
                };
                db.Insert(newNote);
                newNote.NoteTitle = "Test3";
                newNote.NoteContent = "Test4";
                db.Insert(newNote);
                newNote.NoteTitle = "TestTest";
                newNote.NoteContent = "TestTestTest";
                db.Insert(newNote);
            }
        }

        public void AddNote(string title, string description)
        {
            var newNote = new Note
            {
                NoteTitle = title,
                NoteContent = description
            };
            db.Insert(newNote);
        }

        public void UpdateNote(int id, string description)
        {
            var newNote = new Note
            {
                Id = id,
                NoteTitle = GetOneNote(id).NoteTitle,
                NoteContent = description
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
            throw new Exception("Current table is empty");
        }
    }
}