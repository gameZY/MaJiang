using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class Teacher_Manager_NetworkManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("OnInit", OnInit),
			new LuaMethod("Unload", Unload),
			new LuaMethod("CallMethod", CallMethod),
			new LuaMethod("AddEvent", AddEvent),
			new LuaMethod("SendConnect", SendConnect),
			new LuaMethod("SendMessage", SendMessage),
			new LuaMethod("New", _CreateTeacher_Manager_NetworkManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Teacher.Manager.NetworkManager", typeof(Teacher.Manager.NetworkManager), regs, fields, typeof(View));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTeacher_Manager_NetworkManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Teacher.Manager.NetworkManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Teacher.Manager.NetworkManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnInit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Teacher.Manager.NetworkManager obj = (Teacher.Manager.NetworkManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.Manager.NetworkManager");
		obj.OnInit();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Unload(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Teacher.Manager.NetworkManager obj = (Teacher.Manager.NetworkManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.Manager.NetworkManager");
		obj.Unload();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallMethod(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Teacher.Manager.NetworkManager obj = (Teacher.Manager.NetworkManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.Manager.NetworkManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		object[] o = obj.CallMethod(arg0,objs1);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		Teacher.ByteBuffer arg1 = (Teacher.ByteBuffer)LuaScriptMgr.GetNetObject(L, 2, typeof(Teacher.ByteBuffer));
		Teacher.Manager.NetworkManager.AddEvent(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendConnect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Teacher.Manager.NetworkManager obj = (Teacher.Manager.NetworkManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.Manager.NetworkManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.SendConnect(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Teacher.Manager.NetworkManager obj = (Teacher.Manager.NetworkManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.Manager.NetworkManager");
		Teacher.ByteBuffer arg0 = (Teacher.ByteBuffer)LuaScriptMgr.GetNetObject(L, 2, typeof(Teacher.ByteBuffer));
		obj.SendMessage(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

