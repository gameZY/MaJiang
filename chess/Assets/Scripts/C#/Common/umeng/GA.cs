
//  Created by ZhuCong on 1/1/14.
//  Copyright 2014 Umeng.com . All rights reserved.



using System;
using UnityEngine;
using System.Runtime.InteropServices;


namespace Umeng
{
    
    /// <summary>
    /// 友盟游戏统计
    /// </summary>
    public class GA : Analytics
    {

        public enum Gender
        {
            Unknown = 0,
            Male = 1,
            Female = 2
        }

		/// <summary>
		/// 设置玩家等级
		/// </summary>
		/// <param name="level">玩家等级</param>
		public static void SetUserLevel(int level)
		{

			#if UNITY_EDITOR
			Debug.Log("SetUserLevel");
			#elif UNITY_IPHONE
			_SetUserLevel(level);
			#elif UNITY_ANDROID
			Agent.CallStatic("setPlayerLevel", level);
			#endif
			
		}



        /// <summary>
        /// 设置玩家等级
        /// </summary>
        /// <param name="level">玩家等级</param>
		[Obsolete("SetUserLevel(string level) 已弃用, 请使用 SetUserLevel(int level)")] 
		public static void SetUserLevel(string level)
        {
			Debug.Log("SetUserLevel(string level) 已弃用, 请使用 SetUserLevel(int level)");

        }


        /// <summary>
        /// 设置玩家属性
        /// </summary>
        /// <param name="userId">玩家Id</param>
        /// <param name="gender">性别</param>
        /// <param name="age">年龄</param>
        /// <param name="platform">来源</param>
		[System.Obsolete("SetUserInfo已弃用, 请使用ProfileSignIn")]
        public static void SetUserInfo(string userId, Gender gender, int age, string platform)
        {
#if UNITY_EDITOR
            Debug.Log("SetUserInfo");
#elif UNITY_IPHONE
            _SetUserInfo(userId, (int)gender, age, platform);
#elif UNITY_ANDROID
            Agent.CallStatic("setPlayerInfo",userId, age,  (int)gender, platform);
#endif


        }





        
        /// <summary>
        /// 玩家进入关卡
        /// </summary>
        /// <param name="level">关卡</param>
        public static void StartLevel(string level)
        {

#if UNITY_EDITOR
            Debug.Log("StartLevel");
#elif UNITY_IPHONE
            _StartLevel(level);
#elif UNITY_ANDROID
            Agent.CallStatic("startLevel",level);
#endif
        }

        /// <summary>
        /// 玩家通过关卡
        /// </summary>
        /// <param name="level">如果level设置为null 则为当前关卡</param>

        public static void FinishLevel(string level)
        {

#if UNITY_EDITOR
            Debug.Log("FinishLevel");
#elif UNITY_IPHONE
            _FinishLevel(level);
#elif UNITY_ANDROID
            Agent.CallStatic("finishLevel",level);
#endif
        }

        /// <summary>
        /// 玩家未通过关卡
        /// </summary>
        /// <param name="level">如果level设置为null 则为当前关卡</param>
        public static void FailLevel(string level)
        {

#if UNITY_EDITOR
            Debug.Log("FailLevel");
#elif UNITY_IPHONE
            _FailLevel(level);
#elif UNITY_ANDROID
            Agent.CallStatic("failLevel",level);
#endif
        }




        /// <summary>
        /// Source9 到Source 20 请在友盟后台网站设置 对应的定义
        /// </summary>
        public enum PaySource
        {
            AppStore = 1,
            支付宝 = 2,
            网银 = 3,
            财付通 = 4,
            移动 = 5,
            联通 = 6,
            电信 = 7,
            Paypal = 8,
            Source9,
            Source10,
            Source11,
            Source12,
            Source13,
            Source14,
            Source15,
            Source16,
            Source17,
            Source18,
            Source19,
            Source20,

        }
        /// <summary>
        /// 游戏中真实消费（充值）的时候调用此方法
        /// </summary>
        /// <param name="cash">本次消费金额</param>
		/// <param name="source">来源</param>
        /// <param name="coin">本次消费等值的虚拟币</param>
        public static void Pay(double cash, PaySource source, double coin)
        {

#if UNITY_EDITOR
            Debug.Log("Pay");
#elif UNITY_IPHONE
            _PayCashForCoin(cash,(int)source,coin);
#elif UNITY_ANDROID
            Agent.CallStatic("pay",cash , coin, (int)source);
#endif
        }

		/// <summary>
		/// 游戏中真实消费（充值）的时候调用此方法
		/// </summary>
		/// <param name="cash">本次消费金额</param>
		/// <param name="source">来源:AppStore = 1,支付宝 = 2,网银 = 3,财付通 = 4,移动 = 5,联通 = 6,电信 = 7,Paypal = 8,
		/// 9~100对应渠道请到友盟后台设置本次消费的途径，网银，支付宝 等</param>
		/// <param name="coin">本次消费等值的虚拟币</param>
		public static void Pay(double cash, int source, double coin)
		{
				if (source < 1 || source > 100) {
						throw new System.ArgumentException ();
				}
				#if UNITY_EDITOR
				Debug.Log("Pay");
				#elif UNITY_IPHONE
				_PayCashForCoin(cash,source,coin);
				#elif UNITY_ANDROID
				Agent.CallStatic("pay",cash , coin, source);
				#endif
		}

        /// <summary>
        /// 玩家支付货币购买道具
        /// </summary>
        /// <param name="cash">真实货币数量</param>
        /// <param name="source">支付渠道</param>
        /// <param name="item">道具名称</param>
        /// <param name="amount">道具数量</param>
        /// <param name="price">道具单价</param>
        public static void Pay(double cash, PaySource source, string item, int amount, double price)
        {

#if UNITY_EDITOR
            Debug.Log("Pay");
#elif UNITY_IPHONE
            _PayCashForItem(cash,(int)source,item,amount,price);
#elif UNITY_ANDROID
            Agent.CallStatic("pay",cash, item, amount, price, (int)source);
#endif
        }


        /// <summary>
        /// 玩家使用虚拟币购买道具
        /// </summary>
        /// <param name="item">道具名称</param>
        /// <param name="amount">道具数量</param>
        /// <param name="price">道具单价</param>

        public static void Buy(string item, int amount, double price)
        {

#if UNITY_EDITOR
            Debug.Log("Buy");
#elif UNITY_IPHONE
            _Buy(item,amount,price);
#elif UNITY_ANDROID
            Agent.CallStatic("buy", item, amount, price);
#endif
        }


        /// <summary>
        /// 玩家使用虚拟币购买道具
        /// </summary>
        /// <param name="item">道具名称</param>
        /// <param name="amount">道具数量</param>
        /// <param name="price">道具单价</param>
        public static void Use(string item, int amount, double price)
        {

#if UNITY_EDITOR
            Debug.Log("Use");
#elif UNITY_IPHONE
            _Use(item, amount, price);
#elif UNITY_ANDROID
            Agent.CallStatic("use", item, amount, price);
#endif
        }


        /// <summary>
        /// Source4 到Source 10 请在友盟后台网站设置 对应的定义
        /// </summary>
        public enum BonusSource
        {
            
            玩家赠送 = 1,
			Source2 =2,
			Source3 =3,
			Source4,
            Source5,
            Source6,
            Source7,
            Source8,
            Source9,
            Source10,

        }
        /// <summary>
        /// 玩家获虚拟币奖励
        /// </summary>
        /// <param name="coin">虚拟币数量</param>
        /// <param name="source">奖励方式</param>
        public static void Bonus(double coin, BonusSource source)
        {

#if UNITY_EDITOR
            Debug.Log("Bonus");
#elif UNITY_IPHONE
            _BonusCoin(coin, (int)source);
#elif UNITY_ANDROID
            Agent.CallStatic("bonus", coin, (int)source);
#endif
        }


        /// <summary>
        /// 玩家获道具奖励
        /// </summary>
        /// <param name="item">道具名称</param>
        /// <param name="amount">道具数量</param>
        /// <param name="price">道具单价</param>
        /// <param name="source">奖励方式</param>
        ///         

        public static void Bonus(string item, int amount, double price, BonusSource source)
        {

#if UNITY_EDITOR
            Debug.Log("Bonus");
#elif UNITY_IPHONE
			_BonusItem(item, amount, price, (int)source);
#elif UNITY_ANDROID
            Agent.CallStatic("bonus", item, amount, price, (int)source);
#endif
        }

		//使用sign-In函数后，如果结束该userId的统计，需要调用ProfileSignOff函数
		public static  void ProfileSignIn(string userId)
		{
			#if UNITY_EDITOR
			Debug.Log("ProfileSignIn");
			#elif UNITY_IPHONE
			_ProfileSignInWithPUID(userId);
			#elif UNITY_ANDROID
			Agent.CallStatic("onProfileSignIn", userId);
			#endif


		}

		//使用sign-In函数后，如果结束该userId的统计，需要调用ProfileSignOfff函数
 		//provider : 不能以下划线"_"开头，使用大写字母和数字标识; 如果是上市公司，建议使用股票代码。

		public static  void ProfileSignIn(string userId,string provider)
		{
			#if UNITY_EDITOR
			Debug.Log("ProfileSignIn");
			#elif UNITY_IPHONE
			_ProfileSignInWithPUIDAndProvider(userId,provider);
			#elif UNITY_ANDROID
			Agent.CallStatic("onProfileSignIn", provider,userId);
			#endif


		}
		
		//该结束该userId的统计
		public static  void ProfileSignOff()
		{
			#if UNITY_EDITOR
			Debug.Log("ProfileSignOff");
			#elif UNITY_IPHONE
			_ProfileSignOff();
			#elif UNITY_ANDROID
			Agent.CallStatic("onProfileSignOff");
			#endif


		
		}


#if	UNITY_IPHONE

        [DllImport("__Internal")]
        private static extern void _SetUserLevel(int level);

        [DllImport("__Internal")]
        private static extern void _SetUserInfo(string userId, int gender, int age, string platform);

        [DllImport("__Internal")]
        private static extern void _StartLevel(string level);

        [DllImport("__Internal")]
        private static extern void _FinishLevel(string level);

        [DllImport("__Internal")]
        private static extern void _FailLevel(string level);

        [DllImport("__Internal")]
        private static extern void _PayCashForCoin(double cash, int source, double coin);

        [DllImport("__Internal")]
        private static extern void _PayCashForItem(double cash, int source, string item, int amount, double price);

        [DllImport("__Internal")]
        private static extern void _Buy(string item, int amount, double price);

        [DllImport("__Internal")]
        private static extern void _Use(string item, int amount, double price);

        [DllImport("__Internal")]
        private static extern void _BonusCoin(double coin, int source);

		[DllImport("__Internal")]
        private static extern void _BonusItem(string item, int amount, double price, int source);

		[DllImport("__Internal")]
		private static extern void _ProfileSignInWithPUID (string puid);

		[DllImport("__Internal")]
		private static extern void _ProfileSignInWithPUIDAndProvider(string puid,string provider);

		[DllImport("__Internal")]
		private static extern void _ProfileSignOff();



#endif




    }
}
