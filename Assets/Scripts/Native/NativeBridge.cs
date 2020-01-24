using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeBridge : MonoBehaviour
{
    private static NativeBridge instance;
    public static NativeBridge Instance
    {
        get
        {
            if (instance == null)
                instance = new NativeBridge();

            return instance;
        }
    }

    private AndroidJavaObject unityActivity;

    private AndroidJavaObject push;


    private void Awake()
    {
        instance = this;

        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass pushJC = new AndroidJavaClass("com.example.roarman.pushmanager.PushController");
        push = pushJC.CallStatic<AndroidJavaObject>("Instance");
    }

    public void SetToast(string message)
    {
        unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            push.Call("ShowToast", unityActivity, message);
        }));
    }
}
