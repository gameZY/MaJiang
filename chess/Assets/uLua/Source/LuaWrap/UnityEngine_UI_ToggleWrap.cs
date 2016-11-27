using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UnityEngine_UI_ToggleWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Rebuild", Rebuild),
			new LuaMethod("OnPointerClick", OnPointerClick),
			new LuaMethod("OnSubmit", OnSubmit),
			new LuaMethod("New", _CreateUnityEngine_UI_Toggle),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("toggleTransition", get_toggleTransition, set_toggleTransition),
			new LuaField("graphic", get_graphic, set_graphic),
			new LuaField("onValueChanged", get_onValueChanged, set_onValueChanged),
			new LuaField("group", get_group, set_group),
			new LuaField("isOn", get_isOn, set_isOn),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.UI.Toggle", typeof(UnityEngine.UI.Toggle), regs, fields, typeof(UnityEngine.UI.Selectable));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_Toggle(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UnityEngine.UI.Toggle class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UnityEngine.UI.Toggle);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_toggleTransition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name toggleTransition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index toggleTransition on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.toggleTransition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name graphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index graphic on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.graphic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onValueChanged(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onValueChanged");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onValueChanged on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.onValueChanged);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.group);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isOn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOn");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOn on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isOn);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_toggleTransition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name toggleTransition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index toggleTransition on a nil value");
			}
		}

		obj.toggleTransition = (UnityEngine.UI.Toggle.ToggleTransition)LuaScriptMgr.GetNetObject(L, 3, typeof(UnityEngine.UI.Toggle.ToggleTransition));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_graphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name graphic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index graphic on a nil value");
			}
		}

		obj.graphic = (UnityEngine.UI.Graphic)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.UI.Graphic));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onValueChanged(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onValueChanged");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onValueChanged on a nil value");
			}
		}

		obj.onValueChanged = (UnityEngine.UI.Toggle.ToggleEvent)LuaScriptMgr.GetNetObject(L, 3, typeof(UnityEngine.UI.Toggle.ToggleEvent));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name group");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index group on a nil value");
			}
		}

		obj.group = (UnityEngine.UI.ToggleGroup)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.UI.ToggleGroup));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isOn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOn");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOn on a nil value");
			}
		}

		obj.isOn = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Rebuild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.UI.Toggle");
		UnityEngine.UI.CanvasUpdate arg0 = (UnityEngine.UI.CanvasUpdate)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.UI.CanvasUpdate));
		obj.Rebuild(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.UI.Toggle");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		obj.OnPointerClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnSubmit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.UI.Toggle obj = (UnityEngine.UI.Toggle)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.UI.Toggle");
		UnityEngine.EventSystems.BaseEventData arg0 = (UnityEngine.EventSystems.BaseEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));
		obj.OnSubmit(arg0);
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

