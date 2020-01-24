using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text ResponseText;

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

    public void SetDialog(string title, string message)
    {
        //unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        //{
            push.Call("ShowDialog", unityActivity, title, message);
        //}));
    }

    private void ResponseDialog(params string[] texts)
    {
        string text = "";
        for (int i = 0; i < texts.Length; i++)
            text += texts[i] + " / ";

        ResponseText.text = text;
    }
}
