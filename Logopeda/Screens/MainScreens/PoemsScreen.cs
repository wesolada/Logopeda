namespace Logopeda.Screens.MainScreens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using Logopeda.ORM;
    using Logopeda.ORM.Entities;

    [Activity(Label = "@string/PoemsList")]
    public class PoemsScreen : Activity
    {
        IEnumerable<Poems> poems;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PoemsScreen);

            DBRepository repository = new DBRepository();
            poems = repository.GetPoems();

            CreateButtons(poems.Select(p => p.Title));
        }

        private void CreateButtons(IEnumerable<string> titles)
        {
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.MainLayout);

            foreach (string title in titles)
            {
                Button button = new Button(this);
                button.Text = title;
                button.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                button.Click += Button_Click;

                linearLayout.AddView(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PoemsScreens.PoemsListScreen));
            string poem = poems.First(p => p.Title == ((Button)sender).Text).Poem;
            intent.PutExtra("Poem", poem);
            intent.PutExtra("Title", ((Button)sender).Text);
            StartActivity(intent);
        }
    }
}