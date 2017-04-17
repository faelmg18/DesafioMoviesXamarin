package md569e891254e4c129c968c6d8a3495b62c;


public class MyMoviesFragment_RecyclerAdapter_MyView
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MoviesApi.UI.Screens.Fragments.MyMoviesFragment+RecyclerAdapter+MyView, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyMoviesFragment_RecyclerAdapter_MyView.class, __md_methods);
	}


	public MyMoviesFragment_RecyclerAdapter_MyView (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == MyMoviesFragment_RecyclerAdapter_MyView.class)
			mono.android.TypeManager.Activate ("MoviesApi.UI.Screens.Fragments.MyMoviesFragment+RecyclerAdapter+MyView, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
