using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleManager : MonoBehaviour
{
public void OnClickToast()
    {
        NativeBridge.Instance.SetToast("토스트 메세지!");
    }

    public void OnClickDialog()
    {
        NativeBridge.Instance.SetDialog("유니티 확인창", "확인하시겠습니까?");
    }
}
