package md5ffe4a324ad9e577c2ef516b0bd9a738b;


public class StartSnapHelper
	extends android.support.v7.widget.LinearSnapHelper
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_attachToRecyclerView:(Landroid/support/v7/widget/RecyclerView;)V:GetAttachToRecyclerView_Landroid_support_v7_widget_RecyclerView_Handler\n" +
			"n_calculateDistanceToFinalSnap:(Landroid/support/v7/widget/RecyclerView$LayoutManager;Landroid/view/View;)[I:GetCalculateDistanceToFinalSnap_Landroid_support_v7_widget_RecyclerView_LayoutManager_Landroid_view_View_Handler\n" +
			"n_findSnapView:(Landroid/support/v7/widget/RecyclerView$LayoutManager;)Landroid/view/View;:GetFindSnapView_Landroid_support_v7_widget_RecyclerView_LayoutManager_Handler\n" +
			"";
		mono.android.Runtime.register ("MoviesApi.UI.Components.StartSnapHelper, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", StartSnapHelper.class, __md_methods);
	}


	public StartSnapHelper () throws java.lang.Throwable
	{
		super ();
		if (getClass () == StartSnapHelper.class)
			mono.android.TypeManager.Activate ("MoviesApi.UI.Components.StartSnapHelper, MoviesApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void attachToRecyclerView (android.support.v7.widget.RecyclerView p0)
	{
		n_attachToRecyclerView (p0);
	}

	private native void n_attachToRecyclerView (android.support.v7.widget.RecyclerView p0);


	public int[] calculateDistanceToFinalSnap (android.support.v7.widget.RecyclerView.LayoutManager p0, android.view.View p1)
	{
		return n_calculateDistanceToFinalSnap (p0, p1);
	}

	private native int[] n_calculateDistanceToFinalSnap (android.support.v7.widget.RecyclerView.LayoutManager p0, android.view.View p1);


	public android.view.View findSnapView (android.support.v7.widget.RecyclerView.LayoutManager p0)
	{
		return n_findSnapView (p0);
	}

	private native android.view.View n_findSnapView (android.support.v7.widget.RecyclerView.LayoutManager p0);

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
