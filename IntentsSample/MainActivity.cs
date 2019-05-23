using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android;
using Android.Util;
using Android.Content.PM;
using Android.Runtime;

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

            buttonOpenBrowser.Click += OnButtonOpenBrowserClicked;
            buttonCall.Click += OnButtonCallClicked;
            buttonMapsStreet.Click += OnButtonMapsStreetClicked;
            buttonMapsCoordinates.Click += OnButtonMapsCoordinatesClicked;
            buttonMapsRoutes.Click += OnButtonMapsRoutesClicked;
            buttonContacts.Click += OnButtonContactsClicked;
        }

        private void OnButtonOpenBrowserClicked(object sender, EventArgs e)
        {
            Intent i = new Intent(Intent.ActionView, 
                                  Android.Net.Uri.Parse("http://www.facebook.com"));

            StartActivity(i);
        }

        private void OnButtonCallClicked(object sender, EventArgs e)
        {
            Permission p = CheckSelfPermission(Manifest.Permission.CallPhone);

            if(p.ToString().Equals(Permission.Denied.ToString()))
            {
                RequestPermissions(new string[] { Manifest.Permission.CallPhone }, 1);
            }
            else
            {
                CallPhone();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            switch (requestCode)
            {
                case 1: if (grantResults.Length > 0 && grantResults[0] == Permission.Granted) CallPhone(); break;
            }
        }

        private void CallPhone()
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
    }
}

