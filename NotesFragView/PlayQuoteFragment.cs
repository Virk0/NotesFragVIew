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
    //public class PlayQuoteFragment : Fragment
    //{
    //    public int PlayId => Arguments.GetInt("current_play_id", 0);
    //    DatabaseService dbService;

    //    public override void OnCreate(Bundle savedInstanceState)
    //    {
    //        base.OnCreate(savedInstanceState);
    //        dbService = new DatabaseService();
    //    }

    //    public static PlayQuoteFragment NewInstance(int playId)
    //    {
    //        var bundle = new Bundle();
    //        bundle.PutInt("current_play_id", playId);
    //        return new PlayQuoteFragment { Arguments = bundle };
    //    }

    //    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    //    {
    //        if (container == null)
    //        {
    //            return null;
    //        }

    //        var textView = new TextView(Activity);
    //        var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
    //        textView.SetPadding(padding, padding, padding, padding);
    //        textView.TextSize = 24;
    //        textView.Text = dbService.GetAllNotes().ElementAt(PlayId).NoteContent;

    //        var scroller = new ScrollView(Activity);
    //        scroller.AddView(textView);

    //        return scroller;
    //    }
    //}
    public class PlayQuoteFragment : Fragment
    {
        public int PlayId => Arguments.GetInt("current_play_id", 0);
        DatabaseService dbService;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            dbService = new DatabaseService();
        }

        public static PlayQuoteFragment NewInstance(int playId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_play_id", playId);
            return new PlayQuoteFragment { Arguments = bundle };
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            var textView = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            textView.SetPadding(padding, padding, padding, padding);
            textView.TextSize = 24;
<<<<<<< HEAD
            textView.Text = Shakespeare.Dialogue[PlayId];
=======
            textView.Text = dbService.GetAllNotes().ElementAt(PlayId).NoteContent;
>>>>>>> master

            var scroller = new ScrollView(Activity);
            scroller.AddView(textView);

            return scroller;
        }
    }
}