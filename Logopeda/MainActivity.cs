namespace Logopeda
{
    using System;
    using Android.App;
    using Android.Content;
    using Android.Widget;
    using Android.OS;
    using Helpers;

    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FileAccessHelper.InitLocalDB();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button wordsButton = FindViewById<Button>(Resource.Id.Words);
            Button poemsButton = FindViewById<Button>(Resource.Id.Poems);
            Button sentencesButton = FindViewById<Button>(Resource.Id.Sentences);
            Button addButton = FindViewById<Button>(Resource.Id.Add);

            wordsButton.Click += WordsButton_Click;
            poemsButton.Click += PoemsButton_Click;
            sentencesButton.Click += SentencesButton_Click;
            addButton.Click += AddButton_Click;
        }

        private void WordsButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Screens.MainScreens.WordsScreen));
            StartActivity(intent);
        }

        private void PoemsButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Screens.MainScreens.PoemsScreen));
            StartActivity(intent);
        }

        private void SentencesButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Screens.WordsScreens.WordsListScreen));
            intent.PutExtra("Parameter", "Sentences");
            intent.PutExtra("Title", GetString(Resource.String.SentencesList));
            StartActivity(intent);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Screens.MainScreens.AddScreen));
            StartActivity(intent);
        }
    }
}