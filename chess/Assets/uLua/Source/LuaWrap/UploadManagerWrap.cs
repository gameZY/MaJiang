using System;
using System.Collections;
using LuaInterface;

public class UploadManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Init", Init),
			new LuaMethod("Update", Update),
			new LuaMethod("copyLuaPathToPersistent", copyLuaPathToPersistent),
			new LuaMethod("InitResDown", InitResDown),
			new LuaMethod("downLoadFile", downLoadFile),
			new LuaMethod("New", _CreateUploadManager),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
		};

		LuaScriptMgr.RegisterLib(L, "UploadManager", typeof(UploadManager), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUploadManager(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UploadManager obj = new UploadManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UploadManager.New");
		}

		return 0;
	}

	static Type classType = typeof(UploadManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, UploadManager.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		UploadManager.self = (UploadManager)LuaScriptMgr.GetNetObject(L, 3, typeof(UploadManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UploadManager obj = (UploadManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "UploadManager");
		obj.Init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UploadManager obj = (UploadManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "UploadManager");
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int copyLuaPathToPersistent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UploadManager obj = (UploadManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "UploadManager");
		IEnumerator o = obj.copyLuaPathToPersistent();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitResDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UploadManager obj = (UploadManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "UploadManager");
		obj.InitResDown();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int downLoadFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UploadManager obj = (UploadManager)LuaScriptMgr.GetNetObjectSelf(L, 1, "UploadManager");
		LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
		obj.downLoadFile(arg0,arg1,arg2);
		return 0;
	}
}

