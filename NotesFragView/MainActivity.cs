using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;

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
            DatabaseService.DatabaseConnection = new DatabaseService();
            //DatabaseServices.DatabaseConnection.CreateDatabase();
            //DatabaseServices.DatabaseConnection.CreateTableWithData();

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
                    case Resource.Id.editToolBtn:
                        DatabaseService.DatabaseConnection.UpdateNote(DatabaseService.NotesList[PlayNoteFragment.StatPlayId].Id, PlayNoteFragment.StatEditText.Text);
                        DatabaseService.NotesList[PlayNoteFragment.StatPlayId].Description = PlayNoteFragment.StatEditText.Text;

                        //Very important, please never forget this line.
                        this.Recreate();
                        break;
                    case Resource.Id.deleteToolBtn:
                        DatabaseService.DatabaseConnection.DeleteNote(DatabaseService.NotesList[PlayNoteFragment.StatPlayId].Id);
                        DatabaseService.NotesList.RemoveAt(PlayNoteFragment.StatPlayId);

                        //Very important, please never forget this line.
                        this.Recreate();
                        break;
                    default:
                        break;
                }
            }

            return base.OnOptionsItemSelected(item);
        }

        //Add button on click.
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            var addActivity = new Intent(this, typeof(AddNoteActivity));
            StartActivity(addActivity);
        }
    }
}