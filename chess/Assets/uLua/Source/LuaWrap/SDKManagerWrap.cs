using System;
using LuaInterface;

public class SDKManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SDKLoginCallback", SDKLoginCallback),
			new LuaMethod("SDKPayCallback", SDKPayCallback),
			new LuaMethod("SDKLogin", SDKLogin),
			new LuaMethod("SDKPay", SDKPay),
			new LuaMethod("SDKUmengConnect", SDKUmengConnect),
			new LuaMethod("SDKUmengLogin", SDKUmengLogin),
			new LuaMethod("SDKUmengPay", SDKUmengPay),
			new LuaMethod("PlayMovie", PlayMovie),
			new LuaMethod("TakePhoto", TakePhoto),
			new LuaMethod("New", _CreateSDKManager),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("loginfinish", get_loginfinish, set_loginfinish),
			new LuaField("payfinish", get_payfinish, set_payfinish),
			new LuaField("photoFinish", get_photoFinish, set_photoFinish),
			new LuaField("self", get_self, set_self),
		};

		LuaScriptMgr.RegisterLib(L, "SDKManager", typeof(SDKManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSDKManager(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SDKManager obj = new SDKManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SDKManager.New");
		}

		return 0;
	}

	static Type classType = typeof(SDKManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loginfinish(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SDKManager obj = (SDKManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loginfinish");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loginfinish on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.loginfinish);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_payfinish(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SDKManager obj = (SDKManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name payfinish");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index payfinish on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.payfinish);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_photoFinish(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SDKManager obj = (SDKManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name photoFinish");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index photoFinish on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.photoFinish);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, SDKManager.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_loginfinish(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SDKManager obj = (SDKManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loginfinish");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loginfinish on a nil value");
			}
		}

		LuaTypes funcType = LuaDLL.lua_type(L, 3);

		if (funcType != LuaTypes.LUA_TFUNCTION)
		{
			obj.loginfinish = (SDKManager.SDKFinish)LuaScriptMgr.GetNetObject(L, 3, typeof(SDKManager.SDKFinish));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			obj.loginfinish = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_payfinish(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SDKManager obj = (SDKManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name payfinish");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index payfinish on a nil value");
			}
		}

		obj.payfinish = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_photoFinish(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SDKManager obj = (SDKManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name photoFinish");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index photoFinish on a nil value");
			}
		}

		obj.photoFinish = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		SDKManager.self = (SDKManager)LuaScriptMgr.GetNetObject(L, 3, typeof(SDKManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SDKLoginCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.SDKLoginCallback(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SDKPayCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.SDKPayCallback(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SDKLogin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		SDKManager.SDKFinish arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (SDKManager.SDKFinish)LuaScriptMgr.GetNetObject(L, 2, typeof(SDKManager.SDKFinish));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			arg0 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		obj.SDKLogin(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SDKPay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 2);
		obj.SDKPay(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SDKUmengConnect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.SDKUmengConnect(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SDKUmengLogin(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.SDKUmengLogin(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SDKUmengPay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		obj.SDKUmengPay();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayMovie(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.PlayMovie(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TakePhoto(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		SDKManager obj = (SDKManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "SDKManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.TakePhoto(arg0,arg1);
		return 0;
	}
}

