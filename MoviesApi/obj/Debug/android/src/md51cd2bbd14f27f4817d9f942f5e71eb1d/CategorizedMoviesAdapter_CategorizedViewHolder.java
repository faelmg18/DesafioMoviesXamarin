package md51cd2bbd14f27f4817d9f942f5e71eb1d;


public class CategorizedMoviesAdapter_CategorizedViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MoviesApi.Adapter.CategorizedMoviesAdapter+CategorizedViewHolder, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CategorizedMoviesAdapter_CategorizedViewHolder.class, __md_methods);
	}


	public CategorizedMoviesAdapter_CategorizedViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CategorizedMoviesAdapter_CategorizedViewHolder.class)
			mono.android.TypeManager.Activate ("MoviesApi.Adapter.CategorizedMoviesAdapter+CategorizedViewHolder, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
