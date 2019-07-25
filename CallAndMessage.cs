using UnityEngine;
using System.Collections;

public class CallAndMessage : MonoBehaviour
{


    public void Call(object number)
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity 3d.player.UnityPlayer");
        AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent");
        AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");
        intent.Call<AndroidJavaObject>("setAction", Intent.GetStatic<AndroidJavaObject>("ACTION_CALL"));
        intent.Call<AndroidJavaObject>("setData", Uri.CallStatic<AndroidJavaObject>("parse", "tel:"+number.ToString()));
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("startActivity", intent);
    }
    public void Message(object number)
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaClass Intent = new AndroidJavaClass("android.content.Intent");
        AndroidJavaClass Uri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", Intent.GetStatic<AndroidJavaObject>("ACTION_SENDTO"), Uri.CallStatic<AndroidJavaObject>("parse", "smsto:" + number.ToString()));
        intent.Call<AndroidJavaObject>("putExtra", "sms_body", "");
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("startActivity", intent);
    }

}
