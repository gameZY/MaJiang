
//  Created by ZhuCong on 1/1/14.
//  Copyright 2014 Umeng.com . All rights reserved.


using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Umeng
{

    public class Analytics
    {


        //iOS Android Universal API


        // 
        /// <summary>
        /// 开始友盟统计 默认发送策略为启动时发送
        /// </summary>
        /// <param name="appKey">友盟appKey</param>
        /// <param name="channelId">渠道名称</param>
        public static void StartWithAppKeyAndChannelId(string appKey, string channelId)
        {
#if UNITY_EDITOR
        Debug.LogWarning("友盟统计在iOS/Android 真机上才会向友盟后台服务器发送事件 请在真机上测试");

#elif UNITY_IPHONE

        CreateUmengManger();
	
        StartWithAppKeyAndReportPolicyAndChannelId(appKey, ReportPolicy.BATCH, channelId);
        
#elif UNITY_ANDROID


            UMGameAgentInit();
            _AppKey = appKey;
            _ChannelId = channelId;

            CreateUmengManger();
            EnableActivityDurationTrack(false);

#endif
        }


        /// <summary>
        /// 设置是否打印sdk的信息,默认不开启
        /// </summary>
        /// <param name="value">设置为true,Umeng SDK 会输出日志信息,记得release产品时要设置回false.</param>
        /// 
        public static void SetLogEnabled(bool value)
        {
#if UNITY_EDITOR
        Debug.Log("SetLogEnabled");  
#elif UNITY_IPHONE
        _SetLogEnabled(value);
#elif UNITY_ANDROID
            Agent.CallStatic("setDebugMode", value);
#endif
        }

        //使用前，请先到友盟App管理后台的设置->编辑自定义事件 中添加相应的事件ID，然后在工程中传入相应的事件ID
        //eventId、attributes中key和value都不能使用空格和特殊字符，且长度不能超过255个字符（否则将截取前255个字符）
        //id， ts， du是保留字段，不能作为eventId及key的名称


        /// <summary>
        /// 基本事件
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件Id</param>
        public static void Event(string eventId)
        {
#if UNITY_EDITOR
        Debug.Log("Event");  
#elif UNITY_IPHONE
        _Event(eventId);
#elif UNITY_ANDROID
            Agent.CallStatic("onEvent", Context, eventId);
#endif
        }
        //不同的标签会分别进行统计，方便同一事件的不同标签的对比,为nil或空字符串时后台会生成和eventId同名的标签.


        /// <summary>
        /// 基本事件
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件Id</param>
        /// <param name="label">分类标签</param>

        public static void Event(string eventId, string label)
        {
#if UNITY_EDITOR 
        Debug.Log("Event");  
#elif UNITY_IPHONE
        _EventWithLabel(eventId, label);
#elif UNITY_ANDROID
            Agent.CallStatic("onEvent", Context, eventId, label);
#endif
        }


        /// <summary>
        /// 属性事件
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件Id</param>
        /// <param name="attributes"> 属性中的Key-Vaule Pair不能超过10个</param>
        public static void Event(string eventId, Dictionary<string, string> attributes)
        {
#if UNITY_EDITOR
        	Debug.Log("Event");        
#elif UNITY_IPHONE
			_EventWithAttributes(eventId, DictionaryToJson(attributes));
#elif UNITY_ANDROID
            Agent.CallStatic("onEvent", Context, eventId, ToJavaHashMap(attributes));
#endif

        }
        /// <summary>
        /// 时长统计事件
        /// 与EventEnd要配对使用
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件Id</param>
        public static void EventBegin(string eventId)
        {
#if UNITY_EDITOR
        Debug.Log("BeginEvent");  
#elif UNITY_IPHONE
        _BeginEventWithLabel(eventId, "");
#elif UNITY_ANDROID
            Agent.CallStatic("onEventBegin", Context, eventId);
#endif
        }

        /// <summary>
        /// 时长统计事件
        /// 与EventBegin要配对使用
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件</param>
        public static void EventEnd(string eventId)
        {
#if UNITY_EDITOR
        Debug.Log("EndEvent");  
#elif UNITY_IPHONE
        _EndEventWithLabel(eventId, "");
#elif UNITY_ANDROID
            Agent.CallStatic("onEventEnd", Context, eventId);
#endif
        }


        /// <summary>
        /// 时长统计事件
        /// 与EventEnd要配对使用
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件Id</param>
        /// <param name="label">分类标签</param>
        public static void EventBegin(string eventId, string label)
        {
#if UNITY_EDITOR
        Debug.Log("BeginEvent");  
#elif UNITY_IPHONE
        _BeginEventWithLabel(eventId, label);
#elif UNITY_ANDROID
            Agent.CallStatic("onEventBegin", Context, eventId, label);
#endif
        }

        /// <summary>
        /// 时长统计事件
        /// 与EventBegin要配对使用
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件</param>
        /// <param name="label">分类标签</param>
        public static void EventEnd(string eventId, string label)
        {
#if UNITY_EDITOR
        Debug.Log("EndEvent");  
#elif UNITY_IPHONE
        _EndEventWithLabel(eventId, label);
#elif UNITY_ANDROID
            Agent.CallStatic("onEventEnd", Context, eventId, label);
#endif
        }


        /// <summary>
        /// 时长统计事件
        /// 与EventEndWithPrimarykey要配对使用 并传递相同的eventId 和 primaryKey
        /// 
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="attributes"></param>
        /// 
        public static void EventBeginWithPrimarykeyAndAttributes(string eventId, string primaryKey, Dictionary<string, string> attributes)
        {
#if UNITY_EDITOR
            Debug.Log("EventBeginWithPrimarykeyAndAttributes");
#elif UNITY_IPHONE
            _BeginEventWithPrimarykeyAndAttributes(eventId, primaryKey, DictionaryToJson(attributes));
#elif UNITY_ANDROID
            Agent.CallStatic("onKVEventBegin", Context, eventId, ToJavaHashMap(attributes), primaryKey);
#endif
        }

        /// <summary>
        /// 时长统计事件
        /// 与EventBeginWithPrimarykeyAndAttributes要配对使用 并传递相同的eventId 和 primaryKey
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件</param>
        /// <param name="primaryKey">主键</param>
        public static void EventEndWithPrimarykey(string eventId, string primaryKey)
        {
#if UNITY_EDITOR
            Debug.Log("EventEndWithPrimarykey");
#elif UNITY_IPHONE
            _EndEventWithPrimarykey(eventId, primaryKey);
#elif UNITY_ANDROID
            Agent.CallStatic("onKVEventEnd", Context, eventId, primaryKey);
#endif
        }


        /// <summary>
        /// 时长统计事件
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件</param>
        /// <param name="milliseconds">时长 单位是毫秒</param>
        public static void EventDuration(string eventId, int milliseconds)
        {
#if UNITY_EDITOR 
        Debug.Log("EventDuration");  
#elif UNITY_IPHONE
			_EventWithDuration(eventId, milliseconds);
#elif UNITY_ANDROID
            Agent.CallStatic("onEventDuration", Context, eventId, (long)milliseconds);
#endif
        }

        /// <summary>
        /// 时长统计事件
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件</param>
        /// <param name="label">分类标签</param>
        /// <param name="milliseconds">时长 单位是毫秒</param>
        /// 
        public static void EventDuration(string eventId, string label, int milliseconds)
        {
#if UNITY_EDITOR
        Debug.Log("EventDuration");  
#elif UNITY_IPHONE
        _EventWithDuration(eventId, milliseconds);
#elif UNITY_ANDROID
            Agent.CallStatic("onEventDuration", Context, eventId, label, (long)milliseconds);
#endif
        }

        /// <summary>
        /// 时长统计事件
        /// </summary>
        /// <param name="eventId">友盟后台设定的事件</param>
        /// <param name="attributes"> 属性中的Key-Vaule Pair不能超过10个</param>
        /// <param name="milliseconds">时长 单位是毫秒</param>
        /// 
        public static void EventDuration(string eventId, Dictionary<string, string> attributes, int milliseconds)
        {
#if UNITY_EDITOR 
        Debug.Log("EventDuration");
#elif UNITY_IPHONE
            _EventWithAttributesAndDuration(eventId, DictionaryToJson(attributes), milliseconds);
#elif UNITY_ANDROID
            Agent.CallStatic("onEventDuration", Context, eventId, ToJavaHashMap(attributes), (long)milliseconds);
#endif
        }

        /// <summary>
        /// 页面时长统计,记录某个页面被打开多长时间
        /// 与PageEnd配对使用
        /// </summary>
        /// <param name="pageName">被统计view名称</param>

        public static void PageBegin(string pageName)
        {
#if UNITY_EDITOR
		    Debug.Log("PageBegin");
#elif UNITY_IPHONE
            _BeginLogPageView(pageName);
#elif UNITY_ANDROID
            Agent.CallStatic("onPageStart", pageName);
#endif
        }

        /// <summary>
        /// 页面时长统计,记录某个页面被打开多长时间
        /// 与PageBegin配对使用
        /// </summary>
        /// <param name="pageName">被统计view名称</param>
        /// 
        public static void PageEnd(string pageName)
        {
#if UNITY_EDITOR
		    Debug.Log("PageEnd"); 
#elif UNITY_IPHONE
            _EndLogPageView(pageName);
#elif UNITY_ANDROID
            Agent.CallStatic("onPageEnd", pageName);
#endif
        }

		/// <summary>
		/// 自定义事件 — 计算事件数
		/// </summary>
		public static void Event(string eventId, Dictionary<string, string> attributes, int value)
		{
			try
			{
				if (attributes == null)
					attributes = new System.Collections.Generic.Dictionary<string, string>();
				if (attributes.ContainsKey("__ct__"))
				{
					attributes["__ct__"] = value.ToString();
					Event(eventId, attributes);
				}
				else
				{
					attributes.Add("__ct__", value.ToString());
					Event(eventId, attributes);
					attributes.Remove("__ct__");
				}

			}
			catch (Exception)
			{
			}
		}

        /// <summary>
        /// 检查并更新服务器端配置的在线参数
        /// </summary>
        public static void UpdateOnlineConfig()
        {
#if UNITY_EDITOR 
            Debug.Log("UpdateOnlineConfig");  
#elif UNITY_IPHONE
            _UpdateOnlineConfig();
#elif UNITY_ANDROID
            Agent.CallStatic("updateOnlineConfig", Context, _AppKey, _ChannelId);
#endif
        }


        /// <summary>
        /// 获取缓存的在线参数
        /// </summary>
        /// <param name="key">在线参数的Key 请在友盟后台设置</param>
        /// <returns>Key对应的在线参数值</returns>

        public static string GetConfigParamForKey(string key)
        {
#if UNITY_EDITOR
            //Unity Editor 模式下 返回null 请在iOS/Anroid真机上测试
            Debug.Log("GetConfigParamForKey return null");
            return null;
#elif UNITY_IPHONE
            return _GetConfigParamsForKey(key);
#elif UNITY_ANDROID
            return Agent.CallStatic<string>("getConfigParams", Context, key);
#else 
        return null;
#endif
        }



		public static string GetDeviceInfo()
		{
#if UNITY_EDITOR
			//Unity Editor 模式下 返回null 请在iOS/Anroid真机上测试
			Debug.Log("GetDeviceInfo return null");
			return null;
#elif UNITY_IPHONE
			return _GetDeviceID();
#elif UNITY_ANDROID
			var util = new AndroidJavaClass("com.umeng.analytics.UnityUtil");
			var info = util.CallStatic<string>("getDeviceInfo", Context);
			return info;
#endif

		}

		//设置是否对日志信息进行加密, 默认false(不加密).
		//value 设置为true, SDK会将日志信息做加密处理
		
		public static void  SetLogEncryptEnabled(bool value)
		{
			#if UNITY_EDITO
			Debug.Log("SetLogEncryptEnabled");
			#elif UNITY_IPHONE
			_SetEncryptEnabled(value);
			#elif UNITY_ANDROID
			AnalyticsConfig.CallStatic("enableEncrypt", value);
			#endif


		}
		
		
		public static void SetLatency(int value)
		{
			#if UNITY_EDITO
			Debug.Log("SetLatency");
			#elif UNITY_IPHONE
			_SetLatency(value);
			#elif UNITY_ANDROID
			AnalyticsConfig.CallStatic("setLatencyWindow", (long)value);
			#endif

		}
		


        //Android Only

#if  UNITY_ANDROID



        //设置Session时长
        public static void SetContinueSessionMillis(long milliseconds)
        {
#if UNITY_EDITOR
            Debug.Log("setContinueSessionMillis"); 
#else
            Agent.CallStatic("setSessionContinueMillis", milliseconds);
#endif
        }
		[Obsolete("Flush")]
        //清空缓存
        public static void Flush()
        {
#if UNITY_EDITOR
            Debug.Log("flush"); 
#else
            Agent.CallStatic("flush", Context);
#endif
        }
		[Obsolete("SetEnableLocation已弃用")]
        //启用位置信息
        public static void SetEnableLocation(bool reportLocation)
        {
#if UNITY_EDITOR
            Debug.Log("setEnableLocation:"+ reportLocation); 
#else
            Agent.CallStatic("setAutoLocation", reportLocation);
#endif
        }


        //启用页面统计
        public static void EnableActivityDurationTrack(bool isTraceActivity)
        {
#if UNITY_EDITOR
            Debug.Log("enableActivityDurationTrack:"+isTraceActivity); 
#else
            Agent.CallStatic("openActivityDurationTrack", isTraceActivity);
#endif

        }


		
		

		

#endif



        //iOS Only
#if UNITY_IPHONE

    /*
    BATCH(启动发送)为默认发送策略

    关于发送策略的调整，请参见关于发送策略及发送策略变更的说明
    http://blog.umeng.com/index.php/2012/12/0601/
    SEND_INTERVAL 为按最小间隔发送,默认为10秒,取值范围为10 到 86400(一天)， 如果不在这个区间的话，会按10设置。
    SEND_ON_EXIT 为退出或进入后台时发送,这种发送策略在App运行过程中不发送，对开发者和用户的影响最小。
    不过这种发送策略只在iOS > 4.0时才会生效, iOS < 4.0 会被自动调整为BATCH。
    */

    public enum ReportPolicy
    {

        BATCH = 1,//启动发送
        SENDDAILY = 4, //每日发送
        
        SEND_INTERVAL = 6,   //按最小间隔发送
        SEND_ON_EXIT = 7 //退出或进入后台时发送 
               
    }


    /// <summary>
    /// 开启友盟统计
    /// </summary>
    /// <param name="appkey">友盟appKey</param>
    /// <param name="policy">发送策略</param>
    /// <param name="channelId">渠道名称</param>
    /// 
    public static void StartWithAppKeyAndReportPolicyAndChannelId(string appkey, ReportPolicy policy, string channelId)
    {
#if UNITY_EDITOR
        Debug.LogWarning("友盟统计在iOS/Androi 真机上才会向友盟后台服务器发送事件 请在真机上测试");
#else

        _StartWithAppKeyAndReportPolicyAndChannelId(appkey, (int)policy, channelId);
        _AppKey = appkey;
        _ChannelId = channelId;
#endif
    }


    /// <summary>
    /// 当reportPolicy 为 SEND_INTERVAL 时设定log发送间隔
    /// </summary>
    /// <param name="seconds">单位为秒,最小为10,最大为86400(一天).</param>

    public static void SetLogSendInterval(int seconds)
    {
#if UNITY_EDITOR 
        Debug.Log("SetLogSendInterval"); 
#else
		_SetLogSendInterval((double)seconds);
#endif
    }


    /// <summary>           
    /// 手动设置app版本号 此API不再建议使用 因为启动时会自动读取Unity的PlayerSettings.bundleVersion(CFBundleVersion)作为版本 
    /// </summary>
    /// <param name="value">版本号</param>
    [Obsolete("此API不再建议使用 因为启动时会自动读取Unity的PlayerSettings.bundleVersion(CFBundleVersion)作为版本")]
    public static void SetAppVersion(string value)
    {
#if UNITY_EDITOR
        Debug.Log("SetAppVersion"); 
#else
        _SetAppVersion(value);
#endif
    }




    /// <summary>
    ///  开启CrashReport收集, 默认是开启状态.
    /// </summary>
    /// <param name="value">设置成false,就可以关闭友盟CrashReport收集</param>
    public static void SetCrashReportEnabled(bool value)
    {
#if UNITY_EDITOR 
        Debug.Log("SetCrashReportEnabled");
#else
        //由于Unity在iOS平台使用AOT模式编译 你得到的CrashReport函数名将不是完全一致
        _SetCrashReportEnabled(value);

        
        //Anddroid 平台Crash Report 总是是开启的 无需调用SetCrashReportEnabled
        //Anddroid 平台Crash Report 仅限于Java层的崩溃日志
#endif
    }

    /// <summary>
    ///  自定义检查更新的弹出框
    /// </summary>
    public static void CheckUpdateAndCancelButtonTitleAndOtherButtonTitles(string title, string cancelBtnTitle, string otherBtnTitle)
    {
#if UNITY_EDITOR 
        Debug.Log("CheckUpdateAndCancelButtonTitleAndOtherButtonTitles"); 
#else
        _CheckUpdateAndCancelButtonTitleAndOtherButtonTitles(title, cancelBtnTitle, otherBtnTitle);
#endif

    }


    /// <summary>
    /// 页面时长统计,记录某个view被打开多长时间,与调用PageBegin,PageEnd计时等价
    /// </summary>
    /// <param name="pageName">被统计view名称</param>
    /// <param name="seconds">时长单位为秒</param>
    /// 
    public static void LogPageViewWithSeconds(string pageName, int seconds)
    {
#if UNITY_EDITOR
        Debug.Log("LogPageViewWithSeconds"); 
#else
        _LogPageViewWithSeconds(pageName, seconds);
#endif
    }



    /// <summary>
    /// 判断设备是否越狱，判断方法根据 apt和Cydia.app的path来判断
    /// </summary>
    /// <returns>是否越狱</returns>
    public static bool IsJailBroken()
    {
#if UNITY_EDITOR
        //always return false in UNITY_EDITOR mode
        Debug.Log("IsJailBroken always return false in UNITY_EDITOR mode");
        return false;
#else
        return _IsJailBroken();
#endif
    }

    /// <summary>
    /// 判断你的App是否被破解
    /// </summary>
    /// <returns>是否破解</returns>
    public static bool IsPirated()
    {
#if UNITY_EDITOR
        //always return false in UNITY_EDITOR mode
        Debug.Log("IsPirated always return false in UNITY_EDITOR mode");
        return false;
#else
        return _IsPirated();
#endif
    }

    
        /// <summary>
        /// 检测更新 请在友盟后台设置新版本
        /// </summary>
        public static void CheckUpdate()
        {
#if UNITY_EDITOR
            Debug.Log("CheckUpdate");

#elif UNITY_IPHONE
            _CheckUpdate();
            
#endif
        }

		//设置是否开启background模式, 默认true.
  		//value 为YES,SDK会确保在app进入后台的短暂时间保存日志信息的完整性，对于已支持background模式和一般app不会有影响.
        //如果该模式影响某些App在切换到后台的功能，也可将该值设置为false.
 		
		public static void SetBackgroundTaskEnabled(bool value)
		{
#if UNITY_EDITOR
			Debug.Log("SetBackgroundTaskEnabled");
#elif UNITY_IPHONE
			_SetBackgroundTaskEnabled (value);
#endif
		}

		public static string GetAdURL()
		{
			return _GetAdURL ();
		}

#endif



		





        #region Wrapper

        static private string _AppKey=null;
        static private string _ChannelId=null;
        static public string AppKey
        {
            get
            {
                return _AppKey;
            }
        }
        static public string ChannelId
        {
            get
            {
                return _ChannelId;
            }
        }

        static private void CreateUmengManger()
        {
            GameObject go = new GameObject();
            go.AddComponent<UmengManager>();
            go.name = "UmengManager";
        }

#if UNITY_ANDROID

        public static void onResume()
        {
#if UNITY_EDITOR

#else
            Agent.CallStatic("onResume", Context);
#endif
        }

        public static void onResume(string appkey, string channelId)
        {
#if UNITY_EDITOR
 
#else
            Agent.CallStatic("onResume", Context, appkey, channelId);
#endif
        }

        public static void onPause()
        {
#if UNITY_EDITOR

#else
            Agent.CallStatic("onPause", Context);
#endif
        }

        public static void onKillProcess()
        {
#if UNITY_EDITOR

#else
            Agent.CallStatic("onKillProcess", Context);

#endif
        }
		static AndroidJavaClass AnalyticsConfig = null;
        
        //lazy initialize singleton
        static class SingletonHolder
        {
            public static AndroidJavaClass instance_mobclick;
            public static AndroidJavaObject instance_context;

            static SingletonHolder()
            {
                //instance_mobclick will be null if you run in editor mode
                //try it on real android device
                instance_mobclick = new AndroidJavaClass("com.umeng.analytics.game.UMGameAgent");
				AnalyticsConfig = new AndroidJavaClass("com.umeng.analytics.AnalyticsConfig");
                

                //cls_UnityPlayer and instance_context will be null if you run in editor mode
                //try it on real android device
                using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    instance_context = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                }
            }
        }
        private static AndroidJavaObject ToJavaHashMap(Dictionary<string, string> dic)
        {
            var hashMap = new AndroidJavaObject("java.util.HashMap");
            var putMethod = AndroidJNIHelper.GetMethodID(hashMap.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
            var arguments = new object[2];
            foreach (var entry in dic)
            {
                using (var key = new AndroidJavaObject("java.lang.String", entry.Key))
                {
                    using (var val = new AndroidJavaObject("java.lang.String", entry.Value))
                    {
                        arguments[0] = key;
                        arguments[1] = val;
                        AndroidJNI.CallObjectMethod(hashMap.GetRawObject(), putMethod, AndroidJNIHelper.CreateJNIArgArray(arguments));
                    }
                } // end using
            } // end foreach

            return hashMap;
        }

        protected static AndroidJavaClass Agent
        {
            get
            {
                //instance_mobclick will be null if you run in editor mode
                //try it on real android device
                return SingletonHolder.instance_mobclick;
            }
        }

        static AndroidJavaClass _UpdateAgent;

        protected static AndroidJavaClass UpdateAgent
        {

            get
            {
                if (_UpdateAgent == null)
                    _UpdateAgent = new AndroidJavaClass("com.umeng.update.UmengUpdateAgent");
                return _UpdateAgent;


            }
        }

        protected static AndroidJavaObject Context
        {
            get
            {
                //instance_mobclick will be null if you run in editor mode
                //try it on real android device
                return SingletonHolder.instance_context;
            }
        }

        public static void UMGameAgentInit()
        {
            Agent.CallStatic("initUnity", Context);
        }

        public void Dispose()
        {
            Agent.Dispose();
            Context.Dispose();
        }


#endif


#if	UNITY_IPHONE



        public struct AppUpdateInfo
        {
            public bool canUpdate;
            public string version;
            public string current_version;
            public string path;
            public string update_log;

        };
        public delegate void CheckUpdateDelegate(AppUpdateInfo appUpdateInfo);
        private static CheckUpdateDelegate checkUpdate;

        [AOT.MonoPInvokeCallback(typeof(Analytics.CheckUpdateDelegate))]
        private static void _checkUpdateDelegate(Analytics.AppUpdateInfo info)
        {
            checkUpdate(info);
        }

        public static void CheckUpdateWithCallBack(CheckUpdateDelegate checkUpdateCallBack)
        {
            checkUpdate = checkUpdateCallBack;
            _CheckUpdateWithDelegate(_checkUpdateDelegate);
        }


        static string DictionaryToJson(Dictionary<string, string> dict)
        {

            var builder = new StringBuilder("{");
            foreach (KeyValuePair<string, string> kv in dict)
            {
                builder.AppendFormat("\"{0}\":\"{1}\",", kv.Key, kv.Value);
            }
            builder[builder.Length - 1] = '}';
            return builder.ToString();


        }



    [DllImport("__Internal")]
    private static extern void _SetAppVersion(string value);

    [DllImport("__Internal")]
    private static extern string _GetAgentVersion();

    [DllImport("__Internal")]
    private static extern void _SetLogEnabled(bool value);

    [DllImport("__Internal")]
    private static extern void _SetCrashReportEnabled(bool value);

    [DllImport("__Internal")]
    private static extern void _StartWithAppKey(string appkey);

    [DllImport("__Internal")]
    private static extern void _StartWithAppKeyAndReportPolicyAndChannelId(string appkey, int policy, string channelId);

    [DllImport("__Internal")]
    private static extern void _SetLogSendInterval(double interval);

    [DllImport("__Internal")]
    private static extern void _Event(string eventId);

    [DllImport("__Internal")]
    private static extern void _EventWithDuration(string eventId, int duration);

    [DllImport("__Internal")]
    private static extern void _EventWithLabelAndDuration(string eventId, string Label, int duration);

    [DllImport("__Internal")]
    private static extern void _EventWithAttributesAndDuration(string eventId, string jsonString, int duration);

    [DllImport("__Internal")]
    private static extern void _EventWithLabel(string eventId, string label);

    [DllImport("__Internal")]
    private static extern void _EventWithAccumulation(string eventId, int accumulation);

    [DllImport("__Internal")]
    private static extern void _EventWithLabelAndAccumulation(string eventId, string label, int accumulation);

    [DllImport("__Internal")]
    private static extern void _EventWithAttributes(string eventId, string jsonstring);

    [DllImport("__Internal")]
    private static extern void _BeginEventWithLabel(string eventId, string label);

    [DllImport("__Internal")]
    private static extern void _EndEventWithLabel(string eventId, string label);

    [DllImport("__Internal")]
    private static extern void _BeginEventWithPrimarykeyAndAttributes(string eventId, string primaryKey, string jsonstring);

    [DllImport("__Internal")]
    private static extern void _EndEventWithPrimarykey(string eventId, string primaryKey);

    [DllImport("__Internal")]
    private static extern void _CheckUpdate();

	[DllImport("__Internal")]
	private static extern void _CheckUpdateWithDelegate(CheckUpdateDelegate checkUpdateDelegate);

    [DllImport("__Internal")]
    private static extern void _CheckUpdateAndCancelButtonTitleAndOtherButtonTitles(string title, string cancelBtnTitle, string otherBtnTitle);

    [DllImport("__Internal")]
    private static extern void _UpdateOnlineConfig();

    [DllImport("__Internal")]
    private static extern string _GetConfigParamsForKey(string key);

    [DllImport("__Internal")]
    private static extern string _GetConfigParams();

    [DllImport("__Internal")]
    private static extern void _LogPageViewWithSeconds(string pageName, int seconds);

    [DllImport("__Internal")]
    private static extern void _BeginLogPageView(string pageName);

    [DllImport("__Internal")]
    private static extern void _EndLogPageView(string pageName);

    [DllImport("__Internal")]
    private static extern bool _IsJailBroken();
	
    [DllImport("__Internal")]
    private static extern bool _IsPirated();
	

	[DllImport("__Internal")]
	private static extern string _GetDeviceID();

	[DllImport("__Internal")]
	private static extern  void _SetBackgroundTaskEnabled(bool value);	
		
	[DllImport("__Internal")]
	private static extern  void _SetEncryptEnabled(bool value);
		
	[DllImport("__Internal")]
	private static extern  void _SetLatency(int value);
				
	[DllImport("__Internal")]
	private static extern  string _GetAdURL();
		




#endif
        #endregion
    }
}
