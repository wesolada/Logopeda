package md5ecb8e281a481b714af792226d5ab4936;


public class PoemsScreen
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Logopeda.Screens.MainScreens.PoemsScreen, Logopeda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PoemsScreen.class, __md_methods);
	}


	public PoemsScreen () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PoemsScreen.class)
			mono.android.TypeManager.Activate ("Logopeda.Screens.MainScreens.PoemsScreen, Logopeda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
