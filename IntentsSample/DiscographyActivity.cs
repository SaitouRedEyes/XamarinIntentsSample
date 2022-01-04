using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Fragment.App;

namespace IntentsSample
{
    [Activity(Label = "DiscographyActivity", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class DiscographyActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.albuns_layout);            
        }        
    }
}