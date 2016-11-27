using System;
using UnityEngine;
using LuaInterface;

public class DoTweenManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("InitDoTween", InitDoTween),
			new LuaMethod("DoMove", DoMove),
			new LuaMethod("DoLocalMove", DoLocalMove),
			new LuaMethod("DoLocalRotate", DoLocalRotate),
			new LuaMethod("DoScale", DoScale),
			new LuaMethod("DoFade", DoFade),
			new LuaMethod("DoValue", DoValue),
			new LuaMethod("New", _CreateDoTweenManager),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
		};

		LuaScriptMgr.RegisterLib(L, "DoTweenManager", typeof(DoTweenManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDoTweenManager(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			DoTweenManager obj = new DoTweenManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: DoTweenManager.New");
		}

		return 0;
	}

	static Type classType = typeof(DoTweenManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, DoTweenManager.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		DoTweenManager.self = (DoTweenManager)LuaScriptMgr.GetNetObject(L, 3, typeof(DoTweenManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitDoTween(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DoTweenManager obj = (DoTweenManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "DoTweenManager");
		obj.InitDoTween();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoMove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		DoTweenManager obj = (DoTweenManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "DoTweenManager");
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		LuaFunction arg3 = LuaScriptMgr.GetLuaFunction(L, 5);
		obj.DoMove(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoLocalMove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 7);
		DoTweenManager obj = (DoTweenManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "DoTweenManager");
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		LuaFunction arg3 = LuaScriptMgr.GetLuaFunction(L, 5);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 6);
		int arg5 = (int)LuaScriptMgr.GetNumber(L, 7);
		obj.DoLocalMove(arg0,arg1,arg2,arg3,arg4,arg5);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoLocalRotate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 7);
		DoTweenManager obj = (DoTweenManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "DoTweenManager");
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		LuaFunction arg3 = LuaScriptMgr.GetLuaFunction(L, 5);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 6);
		int arg5 = (int)LuaScriptMgr.GetNumber(L, 7);
		obj.DoLocalRotate(arg0,arg1,arg2,arg3,arg4,arg5);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoScale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		DoTweenManager obj = (DoTweenManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "DoTweenManager");
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		LuaFunction arg3 = LuaScriptMgr.GetLuaFunction(L, 5);
		obj.DoScale(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoFade(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		DoTweenManager obj = (DoTweenManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "DoTweenManager");
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		LuaFunction arg3 = LuaScriptMgr.GetLuaFunction(L, 5);
		obj.DoFade(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		DoTweenManager obj = (DoTweenManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "DoTweenManager");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		LuaFunction arg3 = LuaScriptMgr.GetLuaFunction(L, 5);
		obj.DoValue(arg0,arg1,arg2,arg3);
		return 0;
	}
}

