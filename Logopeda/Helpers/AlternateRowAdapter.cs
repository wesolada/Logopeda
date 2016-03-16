namespace Logopeda.Helpers
{
    using Android.App;
    using Android.Views;
    using Android.Widget;
    using Android.Graphics;

    public class AlternateRowAdapter : BaseAdapter<string>
    {
        string[] items;
        Activity context;

        public AlternateRowAdapter(Activity context, string[] items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override int Count
        {
            get
            {
                return items != null ? items.Length : 0;
            }
        }

        public override string this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;


            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            textView.Text = items[position];
            textView.Gravity = GravityFlags.Center;
            
            if (position % 2 == 1)
            {
                view.SetBackgroundColor(Color.Rgb(42, 50, 56));

            }
            else
            {
                view.SetBackgroundColor(Color.Rgb(21, 25, 28));
            }

            return view;
        }
    }
}