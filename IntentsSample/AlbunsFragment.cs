using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using System;

namespace IntentsSample
{
    public class AlbunsFragment : ListFragment
    {
        int selectedSongId;
        bool showingTwoFragments;        

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ListAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItemActivated1, Nightwish.albuns);            

            if (savedInstanceState != null)
            {
                selectedSongId = savedInstanceState.GetInt("current_song_id", 0);
            }

            var songsContainer = Activity.FindViewById(Resource.Id.songs_container);

            showingTwoFragments = songsContainer != null && songsContainer.Visibility == ViewStates.Visible;

            if (showingTwoFragments)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowPlayQuote(selectedSongId);
            }
        }            

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_song_id", selectedSongId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {            
            ShowPlayQuote(position);
        }

        void ShowPlayQuote(int songId)
        {            
            if (showingTwoFragments)
            {
                ListView.SetItemChecked(songId, true);
                SongsFragment songsFragment;

                try
                {
                    songsFragment = FragmentManager.FindFragment(Activity.FindViewById(Resource.Id.songs_container)) as SongsFragment;
                }
                catch(Exception e)
                {
                    songsFragment = null;
                    Log.Debug("Songs Fragment: ", e.Message);
                }                                

                if (songsFragment == null || songsFragment.songsId != songId)
                {                    
                    var quoteFrag = SongsFragment.NewInstance(songId);
                    
                    FragmentTransaction ft = Activity.SupportFragmentManager.BeginTransaction();
                    
                    ft.Replace(Resource.Id.songs_container, quoteFrag);
                    ft.AddToBackStack(null);
                    ft.SetTransition((int)Android.App.FragmentTransit.FragmentFade);
                    ft.Commit();                                 
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(SongsActivity));
                intent.PutExtra("current_song_id", songId);

                StartActivity(intent);
            }            
        }
    }
}