using System;
using LuaInterface;

public class Teacher_AppConstWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateTeacher_AppConst),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("DebugMode", get_DebugMode, null),
			new LuaField("ExampleMode", get_ExampleMode, null),
			new LuaField("UpdateMode", get_UpdateMode, null),
			new LuaField("AutoWrapMode", get_AutoWrapMode, null),
			new LuaField("TimerInterval", get_TimerInterval, null),
			new LuaField("GameFrameRate", get_GameFrameRate, null),
			new LuaField("UsePbc", get_UsePbc, null),
			new LuaField("UseLpeg", get_UseLpeg, null),
			new LuaField("UsePbLua", get_UsePbLua, null),
			new LuaField("UseCJson", get_UseCJson, null),
			new LuaField("UseSproto", get_UseSproto, null),
			new LuaField("LuaEncode", get_LuaEncode, null),
			new LuaField("AppName", get_AppName, null),
			new LuaField("AppPrefix", get_AppPrefix, null),
			new LuaField("ExtName", get_ExtName, null),
			new LuaField("AssetDirname", get_AssetDirname, null),
			new LuaField("WebUrl", get_WebUrl, null),
			new LuaField("LuaBundleMode", get_LuaBundleMode, set_LuaBundleMode),
			new LuaField("UserId", get_UserId, set_UserId),
			new LuaField("SocketPort", get_SocketPort, set_SocketPort),
			new LuaField("SocketAddress", get_SocketAddress, set_SocketAddress),
			new LuaField("LuaBasePath", get_LuaBasePath, null),
			new LuaField("LuaWrapPath", get_LuaWrapPath, null),
		};

		LuaScriptMgr.RegisterLib(L, "Teacher.AppConst", typeof(Teacher.AppConst), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTeacher_AppConst(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Teacher.AppConst obj = new Teacher.AppConst();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Teacher.AppConst.New");
		}

		return 0;
	}

	static Type classType = typeof(Teacher.AppConst);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DebugMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.DebugMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ExampleMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.ExampleMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UpdateMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.UpdateMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AutoWrapMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.AutoWrapMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TimerInterval(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.TimerInterval);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameFrameRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.GameFrameRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UsePbc(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.UsePbc);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseLpeg(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.UseLpeg);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UsePbLua(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.UsePbLua);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseCJson(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.UseCJson);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseSproto(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.UseSproto);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaEncode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.LuaEncode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.AppName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppPrefix(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.AppPrefix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ExtName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.ExtName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetDirname(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.AssetDirname);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WebUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.WebUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaBundleMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.LuaBundleMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserId(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.UserId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketPort(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.SocketPort);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketAddress(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.SocketAddress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaBasePath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.LuaBasePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaWrapPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Teacher.AppConst.LuaWrapPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaBundleMode(IntPtr L)
	{
		Teacher.AppConst.LuaBundleMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UserId(IntPtr L)
	{
		Teacher.AppConst.UserId = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketPort(IntPtr L)
	{
		Teacher.AppConst.SocketPort = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketAddress(IntPtr L)
	{
		Teacher.AppConst.SocketAddress = LuaScriptMgr.GetString(L, 3);
		return 0;
	}
}

