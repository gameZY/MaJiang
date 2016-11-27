using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using LuaInterface;
using Umeng;
using UnityEngine;

public class SDKManager
{
    public delegate void SDKFinish(string data);
    public SDKFinish loginfinish;
    public LuaFunction payfinish;
    public LuaFunction photoFinish;

    public static SDKManager self = new SDKManager();

    //第三放登录回调
    public void SDKLoginCallback(string data)
    {
        Debug.Log("==========login call back data====" + data);
        loginfinish(data);
    }

    //第三方支付回调
    public void SDKPayCallback(string data)
    {
        Debug.Log("==========pay call back data====" + data);
        payfinish.Call(data);
    }

    //第三方登录
    public void SDKLogin(SDKFinish logincallback)
    {
        loginfinish = logincallback;
        AndroidJavaClass LoginModule = new AndroidJavaClass("com.jiayi.teacher.LoginModule");
        AndroidJavaObject obj = LoginModule.GetStatic<AndroidJavaObject>("_login");
        obj.Call("doSdkLogin");
    }

    //第三方支付
    public void SDKPay(LuaFunction paycallback)
    {
        if (Application.isEditor)
        {
            paycallback.Call(" ");
        }
        else
        {
            payfinish = paycallback;
            AndroidJavaClass PayModule = new AndroidJavaClass("com.jiayi.teacher.PayModule");
            AndroidJavaObject obj = PayModule.GetStatic<AndroidJavaObject>("_pay");
            obj.Call("doSdkPay");
        }
    }

    //友盟登录
    public void SDKUmengConnect(string appkey,string channelID)
    {
        GA.StartWithAppKeyAndChannelId("56602c08e0f55acc8700218a", "Platform360");
    }

    //友盟登录统计
    public void SDKUmengLogin(string platformid)
    {
        GA.ProfileSignIn(platformid, "Platform360");
    }

    //友盟支付统计
    public void SDKUmengPay()
    {
        GA.Pay(1, GA.PaySource.支付宝, "女性模型", 1, 1);
    }

    //播放视频
    public void PlayMovie(string name)
    {
        MoviePlayerCenter.Play(name, null);
    }

    public void TakePhoto(string name, LuaFunction callback)
    {
        Debug.Log("======take photo lua function======");
        photoFinish = callback;
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("TakePhoto", name,Application.persistentDataPath);
    }
}