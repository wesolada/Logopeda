namespace Logopeda.Screens.MainScreens
{
    using System;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Widget;

    [Activity(Label = "@string/WordsTypes")]
    public class WordsScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.WordsScreen);

            Button szButton = FindViewById<Button>(Resource.Id.SZ);
            Button rzButton = FindViewById<Button>(Resource.Id.RZ);
            Button czButton = FindViewById<Button>(Resource.Id.CZ);
            Button szczButton = FindViewById<Button>(Resource.Id.SZCZ);
            Button d¿Button = FindViewById<Button>(Resource.Id.D¯);
            Button dzButton = FindViewById<Button>(Resource.Id.DZ);
            Button sButton = FindViewById<Button>(Resource.Id.S);
            Button rButton = FindViewById<Button>(Resource.Id.R);
            Button allButton = FindViewById<Button>(Resource.Id.ALL);

            szButton.Click += SzButton_Click;
            rzButton.Click += RzButton_Click;
            czButton.Click += CzButton_Click;
            szczButton.Click += SzczButton_Click;
            d¿Button.Click += D¿Button_Click;
            dzButton.Click += DzButton_Click;
            sButton.Click += SButton_Click;
            rButton.Click += RButton_Click;
            allButton.Click += AllButton_Click;
        }

        private void Run(string parameter)
        {
            Intent intent = new Intent(this, typeof(WordsScreens.WordsListScreen));
            intent.PutExtra("Parameter", parameter);
            StartActivity(intent);
        }

        private void SzButton_Click(object sender, EventArgs e)
        {
            Run("SZ");
        }

        private void RzButton_Click(object sender, EventArgs e)
        {
            Run("RZ");
        }
        private void CzButton_Click(object sender, EventArgs e)
        {
            Run("CZ");
        }

        private void SzczButton_Click(object sender, EventArgs e)
        {
            Run("SZCZ");
        }

        private void D¿Button_Click(object sender, EventArgs e)
        {
            Run("D¯");
        }

        private void DzButton_Click(object sender, EventArgs e)
        {
            Run("DZ");
        }

        private void SButton_Click(object sender, EventArgs e)
        {
            Run("S");
        }

        private void RButton_Click(object sender, EventArgs e)
        {
            Run("R");
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            Run("ALL");
        }
    }
}