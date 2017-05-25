package md59c5e420066c26a37e21ca5010b3ee4e3;


public class tabla_carrosWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("JRide.tabla_carrosWrapper, JRide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", tabla_carrosWrapper.class, __md_methods);
	}


	public tabla_carrosWrapper () throws java.lang.Throwable
	{
		super ();
		if (getClass () == tabla_carrosWrapper.class)
			mono.android.TypeManager.Activate ("JRide.tabla_carrosWrapper, JRide, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
