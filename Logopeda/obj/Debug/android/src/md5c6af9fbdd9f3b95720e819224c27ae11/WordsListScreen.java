package md5c6af9fbdd9f3b95720e819224c27ae11;


public class WordsListScreen
	extends android.app.ListActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Logopeda.Screens.WordsScreens.WordsListScreen, Logopeda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", WordsListScreen.class, __md_methods);
	}


	public WordsListScreen () throws java.lang.Throwable
	{
		super ();
		if (getClass () == WordsListScreen.class)
			mono.android.TypeManager.Activate ("Logopeda.Screens.WordsScreens.WordsListScreen, Logopeda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
