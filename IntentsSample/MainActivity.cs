using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace IntentsSample
{
    [Activity(Label = "IntentsSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button buttonOpenBrowser = FindViewById<Button>(Resource.Id.button_open_browser);
            Button buttonCall = FindViewById<Button>(Resource.Id.button_call);
            Button buttonMapsStreet = FindViewById<Button>(Resource.Id.button_maps_street);
            Button buttonMapsCoordinates = FindViewById<Button>(Resource.Id.button_maps_coordinates);
            Button buttonMapsRoutes = FindViewById<Button>(Resource.Id.button_maps_routes);
            Button buttonContacts = FindViewById<Button>(Resource.Id.button_contacts);
            Button buttonAudio = FindViewById<Button>(Resource.Id.button_audio);

            buttonOpenBrowser.Click += OnButtonOpenBrowserClicked;
            buttonCall.Click += OnButtonCallClicked;
            buttonMapsStreet.Click += OnButtonMapsStreetClicked;
            buttonMapsCoordinates.Click += OnButtonMapsCoordinatesClicked;
            buttonMapsRoutes.Click += OnButtonMapsRoutesClicked;
            buttonContacts.Click += OnButtonContactsClicked;
            buttonAudio.Click += OnButtonAudioClicked;
        }

        private void OnButtonOpenBrowserClicked(object sender, EventArgs e)
        {
            Intent i = new Intent(Intent.ActionView, 
                                  Android.Net.Uri.Parse("http://www.facebook.com"));

            StartActivity(i);
        }

        private void OnButtonCallClicked(object sender, EventArgs e)
        {
            Intent i = new Intent(Intent.ActionCall, 
                                  Android.Net.Uri.Parse("tel:34781265"));
            StartActivity(i);
        }

        private void OnButtonMapsStreetClicked(object sender, EventArgs e)
        {
            Intent i = new Intent(Intent.ActionView, 
                                  Android.Net.Uri.Parse("geo:0,0?q=Rua+Uruguai,Rio+de+Janeiro"));
            StartActivity(i); //Precisa ter o google maps instalado no celular
        }

        private void OnButtonMapsCoordinatesClicked(object sender, EventArgs e)
        {
            Intent i = new Intent(Intent.ActionView, 
                                  Android.Net.Uri.Parse("geo:-22.911667, -43.230278"));
            StartActivity(i); //Precisa ter o google maps instalado no celular
        }

        private void OnButtonMapsRoutesClicked(object sender, EventArgs e)
        {
            string source = "-22.911667, -43.230278";
            string destination = "-25.443195, -49.280977";
            string url = "https://www.google.com.br/maps/dir/" + source + "/" + destination + "/";

            Intent i = new Intent(Intent.ActionView, Android.Net.Uri.Parse(url));
            StartActivity(i);
        }

        private void OnButtonContactsClicked(object sender, EventArgs e)
        {
            Intent i = new Intent(Intent.ActionPick, 
                                  Android.Net.Uri.Parse("content://com.android.contacts/contacts/"));
            StartActivity(i);
        }

        private void OnButtonAudioClicked(object sender, EventArgs e)
        {
            Intent i = new Intent(Intent.ActionView, 
                Android.Net.Uri.Parse("http://www.servidor.com.br/musica.mp3"));
            Intent.SetType("audio/a*");
            StartActivity(i);
        }
    }
}

