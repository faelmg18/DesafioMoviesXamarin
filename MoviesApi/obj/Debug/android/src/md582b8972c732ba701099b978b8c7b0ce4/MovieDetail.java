package md582b8972c732ba701099b978b8c7b0ce4;


public class MovieDetail
	extends md582b8972c732ba701099b978b8c7b0ce4.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"";
		mono.android.Runtime.register ("MoviesApi.UI.Screens.Activities.MovieDetail, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MovieDetail.class, __md_methods);
	}


	public MovieDetail () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MovieDetail.class)
			mono.android.TypeManager.Activate ("MoviesApi.UI.Screens.Activities.MovieDetail, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);

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
