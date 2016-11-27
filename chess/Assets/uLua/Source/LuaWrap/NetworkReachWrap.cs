using System;
using LuaInterface;

public class NetworkReachWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("getNetState", getNetState),
			new LuaMethod("New", _CreateNetworkReach),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
		};

		LuaScriptMgr.RegisterLib(L, "NetworkReach", typeof(NetworkReach), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNetworkReach(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			NetworkReach obj = new NetworkReach();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NetworkReach.New");
		}

		return 0;
	}

	static Type classType = typeof(NetworkReach);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, NetworkReach.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		NetworkReach.self = (NetworkReach)LuaScriptMgr.GetNetObject(L, 3, typeof(NetworkReach));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getNetState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NetworkReach obj = (NetworkReach)LuaScriptMgr.GetNetObjectSelf(L, 1, "NetworkReach");
		int o = obj.getNetState();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

