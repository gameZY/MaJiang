using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class Teacher_LuaBehaviourWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AddClick1", AddClick1),
			new LuaMethod("AddClick", AddClick),
			new LuaMethod("SetName", SetName),
			new LuaMethod("SetColor", SetColor),
			new LuaMethod("SetLabelColor", SetLabelColor),
			new LuaMethod("Call", Call),
			new LuaMethod("ClearClick", ClearClick),
			new LuaMethod("New", _CreateTeacher_LuaBehaviour),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Teacher.LuaBehaviour", typeof(Teacher.LuaBehaviour), regs, fields, typeof(View));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTeacher_LuaBehaviour(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Teacher.LuaBehaviour class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Teacher.LuaBehaviour);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick1(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Teacher.LuaBehaviour obj = (Teacher.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.LuaBehaviour");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.AddClick1(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Teacher.LuaBehaviour obj = (Teacher.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.LuaBehaviour");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.AddClick(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Teacher.LuaBehaviour obj = (Teacher.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.LuaBehaviour");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.SetName(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetColor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Teacher.LuaBehaviour obj = (Teacher.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.LuaBehaviour");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		Color arg1 = LuaScriptMgr.GetColor(L, 3);
		obj.SetColor(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLabelColor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Teacher.LuaBehaviour obj = (Teacher.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.LuaBehaviour");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		Color arg1 = LuaScriptMgr.GetColor(L, 3);
		obj.SetLabelColor(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Call(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Teacher.LuaBehaviour obj = (Teacher.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.LuaBehaviour");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		object[] o = obj.Call(arg0,objs1);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Teacher.LuaBehaviour obj = (Teacher.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Teacher.LuaBehaviour");
		obj.ClearClick();
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

