package md526c36693b98b14c638825c19047e2b11;


public class MyMoviesFragment
	extends md526c36693b98b14c638825c19047e2b11.BaseFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MyMovies.UI.Screens.Fragments.MyMoviesFragment, MyMovies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyMoviesFragment.class, __md_methods);
	}


	public MyMoviesFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyMoviesFragment.class)
			mono.android.TypeManager.Activate ("MyMovies.UI.Screens.Fragments.MyMoviesFragment, MyMovies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
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
