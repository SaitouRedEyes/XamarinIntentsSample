using Android.App;
using Android.OS;
using Android.Util;
using AndroidX.Fragment.App;

namespace IntentsSample
{
    [Activity(Label = "AlbunsActivity")]
    public class SongsActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                Finish();
            }            

            var songId = Intent.Extras.GetInt("current_song_id", 0);

            var detailsFrag = SongsFragment.NewInstance(songId);
            SupportFragmentManager.BeginTransaction()
                            .Add(Android.Resource.Id.Content, detailsFrag)
                            .Commit();
        }
    }
}