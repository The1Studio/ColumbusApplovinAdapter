using System;
using UnityEngine;

public class ColumbusSdk
{

	public static String PLUGIN_VERSION = "1.0.0";

	private static AndroidJavaClass _androidSdk = null;

	/// <summary>
	/// Set GDPR Consent
	/// </summary>
	/// <param name="hasConsent">true has consent</param>
	public static void SetGDPRConsent(bool hasConsent)
	{
#if UNITY_ANDROID
		SetAndroidGDPR(hasConsent);
#endif
    }

	/// <summary>
	/// Set Debug Open
	/// </summary>
	/// <param name="debugOn">true open</param>
	public static void SetDebugOn(bool debugOn)
	{
#if UNITY_ANDROID
		SetAndroidDebugOn(debugOn);
#endif
	}

    private static void SetAndroidGDPR(bool hasConsent)
	{
		AndroidJavaClass androidSdk = GetAndroidSdk();
		if (androidSdk == null)
		{
            return;
		}
		androidSdk.CallStatic("setGDPRConsent", hasConsent);
	}

	private static void SetAndroidDebugOn(bool debugOn)
	{
        AndroidJavaClass androidSdk = GetAndroidSdk();
        if (androidSdk == null)
        {
            return;
        }
		androidSdk.CallStatic("setDebugOn", debugOn);
    }

	private static AndroidJavaClass GetAndroidSdk()
	{
#if UNITY_ANDROID && !UNITY_EDITOR
		if (_androidSdk == null)
		{
			_androidSdk = new AndroidJavaClass(
				"com.zeus.gmc.sdk.mobileads.columbus.unityplugin.AdGlobalSdkUnity");
		}
#endif
		if (_androidSdk == null)
		{
            Debug.LogWarning("Columbus Android Object not found!!!");
        }
		return _androidSdk;
    }

}

