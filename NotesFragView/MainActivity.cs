using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace NotesFragView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        public Bundle _savedInstanceState { get; set; }
        public static MainActivity _mainActivity { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            _mainActivity = this;
            AppCenter.Start("b925ac40-664b-4f6f-b9ac-a509a90134d3", typeof(Analytics), typeof(Crashes));
            AppCenter.Start("b925ac40-664b-4f6f-b9ac-a509a90134d3", typeof(Distribute));
            DatabaseServices.DatabaseConnection = new DatabaseServices();
            //DatabaseServices.DatabaseConnection.CreateDatabase();
            //DatabaseServices.DatabaseConnection.AddSomeDataToDataBase();

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            _mainActivity = this;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (true)
            {
                switch (id)
                {
                    case Resource.Id.SaveBtn:
                        try
                        {
                            DatabaseServices.DatabaseConnection.UpdateNote(DatabaseServices.NotesList[PlayNoteFragment.StatPlayId].Id, PlayNoteFragment.StatEditText.Text);
                            DatabaseServices.NotesList[PlayNoteFragment.StatPlayId].NoteContent = PlayNoteFragment.StatEditText.Text;
                        }
                        catch (Exception)
                        {
                        }
                        this.Recreate();
                        break;
                    case Resource.Id.deleteToolBtn:
                        try
                        {
                            DatabaseServices.DatabaseConnection.DeleteNote(DatabaseServices.NotesList[PlayNoteFragment.StatPlayId].Id);
                            DatabaseServices.NotesList.RemoveAt(PlayNoteFragment.StatPlayId);
                        }
                        catch (Exception)
                        {
                        }
                        this.Recreate();
                        break;
                    default:
                        break;
                }
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            var addActivity = new Intent(this, typeof(AddNoteActivity));
            StartActivity(addActivity);
        }
    }
}

