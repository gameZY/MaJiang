using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class Teacher_Manager_PanelManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CreatePanel", CreatePanel),
			new LuaMethod("downLoadFile", downLoadFile),
			new LuaMethod("New", _CreateTeacher_Manager_PanelManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Teacher.Manager.PanelManager", typeof(Teacher.Manager.PanelManager), regs, fields, typeof(View));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTeacher_Manager_PanelManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Teacher.Manager.PanelManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Teacher.Manager.PanelManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreatePanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Teacher.Manager.PanelManager obj = (Teacher.Manager.PanelManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.Manager.PanelManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.CreatePanel(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int downLoadFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Teacher.Manager.PanelManager obj = (Teacher.Manager.PanelManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.Manager.PanelManager");
		LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
		obj.downLoadFile(arg0,arg1,arg2);
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

