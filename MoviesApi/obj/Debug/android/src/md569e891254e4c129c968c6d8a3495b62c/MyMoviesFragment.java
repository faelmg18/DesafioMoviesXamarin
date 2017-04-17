package md569e891254e4c129c968c6d8a3495b62c;


public class MyMoviesFragment
	extends md569e891254e4c129c968c6d8a3495b62c.BaseFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MoviesApi.UI.Screens.Fragments.MyMoviesFragment, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyMoviesFragment.class, __md_methods);
	}


	public MyMoviesFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyMoviesFragment.class)
			mono.android.TypeManager.Activate ("MoviesApi.UI.Screens.Fragments.MyMoviesFragment, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
