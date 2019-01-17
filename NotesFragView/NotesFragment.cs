using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace NotesFragView
{
    public class NotesFragment : ListFragment
    {
        int selectedPlayId;

        public NotesFragment()
        {
            // Being explicit about the requirement for a default constructor.
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemActivated1, NotesTest.Titles);

            if (savedInstanceState != null)
            {
                selectedPlayId = savedInstanceState.GetInt("current_play_id", 0);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_play_id", selectedPlayId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowPlayQuote(position);
        }

        void ShowPlayQuote(int playId)
        {
            var intent = new Intent(Activity, typeof(PlayQuoteActivity));
            intent.PutExtra("current_play_id", playId);
            StartActivity(intent);
        }
    }
}