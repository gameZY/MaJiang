using System;
using LuaInterface;

public class Teacher_LuaHelperWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetType", GetType),
			new LuaMethod("GetPanelManager", GetPanelManager),
			new LuaMethod("GetResManager", GetResManager),
			new LuaMethod("GetNetManager", GetNetManager),
			new LuaMethod("AddNetManager", AddNetManager),
			new LuaMethod("RemoveNetManager", RemoveNetManager),
			new LuaMethod("GetMusicManager", GetMusicManager),
			new LuaMethod("OnCallLuaFunc", OnCallLuaFunc),
			new LuaMethod("OnJsonCallFunc", OnJsonCallFunc),
			new LuaMethod("New", _CreateTeacher_LuaHelper),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaScriptMgr.RegisterLib(L, "Teacher.LuaHelper", regs);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTeacher_LuaHelper(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Teacher.LuaHelper class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Teacher.LuaHelper);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Type o = Teacher.LuaHelper.GetType(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPanelManager(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Teacher.Manager.PanelManager o = Teacher.LuaHelper.GetPanelManager();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetResManager(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Teacher.Manager.ResourceManager o = Teacher.LuaHelper.GetResManager();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNetManager(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Teacher.Manager.NetworkManager o = Teacher.LuaHelper.GetNetManager();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddNetManager(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Teacher.Manager.NetworkManager o = Teacher.LuaHelper.AddNetManager();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveNetManager(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Teacher.LuaHelper.RemoveNetManager();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMusicManager(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Teacher.Manager.MusicManager o = Teacher.LuaHelper.GetMusicManager();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnCallLuaFunc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaStringBuffer arg0 = LuaScriptMgr.GetStringBuffer(L, 1);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		Teacher.LuaHelper.OnCallLuaFunc(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnJsonCallFunc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		Teacher.LuaHelper.OnJsonCallFunc(arg0,arg1);
		return 0;
	}
}

