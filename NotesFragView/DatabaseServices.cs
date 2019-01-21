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
    public class DatabaseService
    {
        SQLiteConnection db;

        public DatabaseService()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "notes.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Note>();
        }

        public void CreateDatabase()
        {
            db.CreateTable<Note>();
        }
        public void AddNote(Note note)
        {
            db.Insert(note);
        }

        public void UpdateNote(Note note)
        {
            db.Update(note);
        }
        public void AddTestingNotes()
        {
            db.CreateTable<Note>();
            if (db.Table<Note>().Count() == 0)
            {
                var newNotes = new Note();
                newNotes.NoteTitle = "NoteTest1";
                newNotes.NoteContent = "This is a note test. This test is to see if i can read the note content in the fragment";
                db.Insert(newNotes);
                newNotes.NoteTitle = "NoteTest2";
                newNotes.NoteContent = "this is another test to see if it doesn't read the same notecontent";
                db.Insert(newNotes);
                newNotes.NoteTitle = "123123";
                newNotes.NoteContent = "i'll be flossin," + "\n" + "i'll be flossin," + "\n" +"i'll be flossin";
                db.Insert(newNotes);
            }
        }
        public List<Note> GetAllNotes()
        {
            var table = db.Table<Note>();
            return table.ToList();
        }

        public void RemoveNote(Note note)
        {
            db.Delete(note);
        }
    }
}