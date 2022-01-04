using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;

//Precisa instalar o package AndroidX.Fragment.App 1.2.5.3
namespace IntentsSample
{
    public class SongsFragment : AndroidX.Fragment.App.Fragment
    {
        public int songsId => Arguments.GetInt("current_song_id", 0);

        public static SongsFragment NewInstance(int songId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_song_id", songId);
            return new SongsFragment { Arguments = bundle };
        }        

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null) return null;
            

            var textView = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            textView.SetPadding(padding, padding, padding, padding);
            textView.TextSize = 24;
            textView.Text = Nightwish.bestSongs[songsId];

            var scroller = new ScrollView(Activity);
            scroller.AddView(textView);

            return scroller;
        }
    }
}