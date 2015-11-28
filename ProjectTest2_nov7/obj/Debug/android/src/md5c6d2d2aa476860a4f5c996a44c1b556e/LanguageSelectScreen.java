package md5c6d2d2aa476860a4f5c996a44c1b556e;


public class LanguageSelectScreen
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ProjectTest2_nov7.Screens.LanguageSelectScreen, ProjectTest2_nov7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LanguageSelectScreen.class, __md_methods);
	}


	public LanguageSelectScreen () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LanguageSelectScreen.class)
			mono.android.TypeManager.Activate ("ProjectTest2_nov7.Screens.LanguageSelectScreen, ProjectTest2_nov7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
