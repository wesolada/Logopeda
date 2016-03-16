namespace Logopeda.Screens.WordsScreens
{
    using Android.App;
    using Android.OS;
    using Logopeda.ORM;
    using Android.Widget;
    using System.Linq;
    using Helpers;

    [Activity(Label = "@string/WordsList")]
    public class WordsListScreen : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string param = Intent.GetStringExtra("Parameter");
            string title = Intent.GetStringExtra("Title");

            if(!string.IsNullOrEmpty(title))
            {
                Title = title;
            }

            string[] result = CallDB(param);

            ListView.FastScrollEnabled = true;

            ListAdapter = new AlternateRowAdapter(this, result);
        }

        private string[] CallDB(string parameter)
        {
            switch(parameter)
            {
                case "ALL":
                    return GetAllWords();

                case "SZ":
                case "RZ":
                case "CZ":
                case "SZCZ":
                case "D¯":
                case "DZ":
                    return GetGroup(parameter);

                case "Sentences":
                    return GetAllSentences();
            }
            
            return null;
        }

        private string[] GetAllWords()
        {
            DBRepository repository = new DBRepository();
            return repository.GetAllWords().ToArray();
        }

        private string[] GetGroup(string parameter)
        {
            DBRepository repository = new DBRepository();
            return repository.GetGroup(parameter).ToArray();
        }

        private string[] GetAllSentences()
        {
            DBRepository repository = new DBRepository();
            return repository.GetAllSentences().ToArray();
        }
    }
}