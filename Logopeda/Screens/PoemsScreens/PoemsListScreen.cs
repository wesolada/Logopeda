namespace Logopeda.Screens.PoemsScreens
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Widget;

    [Activity]
    public class PoemsListScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PoemsListScreen);

            string poem = Intent.GetStringExtra("Poem");

            Title = Intent.GetStringExtra("Title");

            TextView textView = FindViewById<TextView>(Resource.Id.PoemsList);

            textView.Text = poem;
        }       
    }
}