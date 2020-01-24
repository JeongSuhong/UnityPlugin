using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleManager : MonoBehaviour
{
public void OnClickToast()
    {
        NativeBridge.Instance.SetToast("토스트 메세지!");
    }
}
