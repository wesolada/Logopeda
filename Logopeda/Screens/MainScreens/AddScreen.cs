namespace Logopeda.Screens.MainScreens
{
    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using ORM;
    using ORM.Entities;
    using System.Collections.Generic;

    [Activity(Label = "@string/Add")]
    public class AddScreen : Activity
    {
        private int position;

        private Spinner groupSpinner;
        private Spinner subgroupSpinner;

        private TextView groupSpinnerTitle;
        private TextView subgroupSpinnerTitle;
        private TextView poemTitle;
        private TextView contentTitle;

        private EditText poemTitleText;
        private EditText contentText;

        private DBRepository repository;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddScreen);

            repository = new DBRepository();
            List<string> groupsList = repository.GetGroupNames();
            List<string> subgroupsList = repository.GetSubgroupNames();

            Spinner typeSpinner = FindViewById<Spinner>(Resource.Id.typeSpinner);
            groupSpinner = FindViewById<Spinner>(Resource.Id.groupSpinner);
            subgroupSpinner = FindViewById<Spinner>(Resource.Id.subgroupSpinner);

            groupSpinnerTitle = FindViewById<TextView>(Resource.Id.groupSpinner_Title);
            subgroupSpinnerTitle = FindViewById<TextView>(Resource.Id.subgroupSpinner_Title);
            poemTitle = FindViewById<TextView>(Resource.Id.poem_Title);
            contentTitle = FindViewById<TextView>(Resource.Id.content_Title);

            poemTitleText = FindViewById<EditText>(Resource.Id.poem_TitleEdit);
            contentText = FindViewById<EditText>(Resource.Id.content_Text);

            Button saveButton = FindViewById<Button>(Resource.Id.saveButton);
            saveButton.Click += SaveButton_Click;

            Button cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            cancelButton.Click += CancelButton_Click;
            
            typeSpinner.ItemSelected += TypeSpinner_ItemSelected;

            var typeAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.TypesArray, Android.Resource.Layout.SimpleSpinnerItem);
            typeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            typeSpinner.Adapter = typeAdapter;

            var groupAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);
            groupAdapter.AddAll(groupsList);
            groupSpinner.Adapter = groupAdapter;

            var subgroupAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);
            subgroupAdapter.AddAll(subgroupsList);
            subgroupSpinner.Adapter = subgroupAdapter;

        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            OnBackPressed();
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            int result = 0;

            switch (position)
            {
                case 0:
                    Words word = new Words();
                    word.GroupId = groupSpinner.SelectedItemPosition + 1;
                    word.SubGroupId = subgroupSpinner.SelectedItemPosition + 1;
                    word.Word = contentText.Text;

                    result = repository.Save(word);
                    break;

                case 1:
                    Sentences sentence = new Sentences();
                    sentence.Sentence = contentText.Text;

                    result = repository.Save(sentence);
                    break;

                case 2:
                    Poems poem = new Poems();
                    poem.Title = poemTitleText.Text;
                    poem.Poem = contentText.Text;

                    result = repository.Save(poem);
                    break;
            }

            string message = result == 1 ? "Zapisano" : "B³¹d zapisu!";
            
            Toast.MakeText(this, message, ToastLength.Long).Show();

            OnBackPressed();
        }

        private void TypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            position = e.Position;

            var wordState = position != 0 ? Android.Views.ViewStates.Gone : Android.Views.ViewStates.Visible;

            groupSpinner.Visibility = wordState;
            subgroupSpinner.Visibility = wordState;
            groupSpinnerTitle.Visibility = wordState;
            subgroupSpinnerTitle.Visibility = wordState;

            var poemState = position != 2 ? Android.Views.ViewStates.Gone : Android.Views.ViewStates.Visible;

            poemTitle.Visibility = poemState;
            poemTitleText.Visibility = poemState;

            switch(position)
            {
                case 0:
                    contentTitle.Text = GetString(Resource.String.WordContent);
                    contentText.SetHeight(100);
                    break;

                case 1:
                    contentTitle.Text = GetString(Resource.String.SentenceContent);
                    contentText.SetHeight(200);
                    break;

                case 2:
                    contentTitle.Text = GetString(Resource.String.PoemContent);
                    contentText.SetHeight(300);
                    break;
            }
        }
    }
}