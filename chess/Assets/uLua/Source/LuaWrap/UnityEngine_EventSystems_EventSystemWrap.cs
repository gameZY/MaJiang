using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class UnityEngine_EventSystems_EventSystemWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("UpdateModules", UpdateModules),
			new LuaMethod("SetSelectedGameObject", SetSelectedGameObject),
			new LuaMethod("RaycastAll", RaycastAll),
			new LuaMethod("IsPointerOverGameObject", IsPointerOverGameObject),
			new LuaMethod("ToString", ToString),
			new LuaMethod("New", _CreateUnityEngine_EventSystems_EventSystem),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__tostring", Lua_ToString),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("current", get_current, set_current),
			new LuaField("sendNavigationEvents", get_sendNavigationEvents, set_sendNavigationEvents),
			new LuaField("pixelDragThreshold", get_pixelDragThreshold, set_pixelDragThreshold),
			new LuaField("currentInputModule", get_currentInputModule, null),
			new LuaField("firstSelectedGameObject", get_firstSelectedGameObject, set_firstSelectedGameObject),
			new LuaField("currentSelectedGameObject", get_currentSelectedGameObject, null),
			new LuaField("alreadySelecting", get_alreadySelecting, null),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.EventSystems.EventSystem", typeof(UnityEngine.EventSystems.EventSystem), regs, fields, typeof(UnityEngine.EventSystems.UIBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_EventSystems_EventSystem(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UnityEngine.EventSystems.EventSystem class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UnityEngine.EventSystems.EventSystem);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UnityEngine.EventSystems.EventSystem.current);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sendNavigationEvents(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sendNavigationEvents");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sendNavigationEvents on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.sendNavigationEvents);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelDragThreshold(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelDragThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelDragThreshold on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.pixelDragThreshold);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentInputModule(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name currentInputModule");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index currentInputModule on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.currentInputModule);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_firstSelectedGameObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name firstSelectedGameObject");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index firstSelectedGameObject on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.firstSelectedGameObject);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentSelectedGameObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name currentSelectedGameObject");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index currentSelectedGameObject on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.currentSelectedGameObject);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_alreadySelecting(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alreadySelecting");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alreadySelecting on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.alreadySelecting);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_current(IntPtr L)
	{
		UnityEngine.EventSystems.EventSystem.current = (UnityEngine.EventSystems.EventSystem)LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.EventSystems.EventSystem));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sendNavigationEvents(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sendNavigationEvents");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sendNavigationEvents on a nil value");
			}
		}

		obj.sendNavigationEvents = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelDragThreshold(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelDragThreshold");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelDragThreshold on a nil value");
			}
		}

		obj.pixelDragThreshold = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_firstSelectedGameObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name firstSelectedGameObject");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index firstSelectedGameObject on a nil value");
			}
		}

		obj.firstSelectedGameObject = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = LuaScriptMgr.GetLuaObject(L, 1);

		if (obj != null)
		{
			LuaScriptMgr.Push(L, obj.ToString());
		}
		else
		{
			LuaScriptMgr.Push(L, "Table: UnityEngine.EventSystems.EventSystem");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateModules(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.EventSystems.EventSystem");
		obj.UpdateModules();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSelectedGameObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.EventSystems.EventSystem");
			GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
			obj.SetSelectedGameObject(arg0);
			return 0;
		}
		else if (count == 3)
		{
			UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.EventSystems.EventSystem");
			GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
			UnityEngine.EventSystems.BaseEventData arg1 = (UnityEngine.EventSystems.BaseEventData)LuaScriptMgr.GetNetObject(L, 3, typeof(UnityEngine.EventSystems.BaseEventData));
			obj.SetSelectedGameObject(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.EventSystems.EventSystem.SetSelectedGameObject");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RaycastAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.EventSystems.EventSystem");
		UnityEngine.EventSystems.PointerEventData arg0 = (UnityEngine.EventSystems.PointerEventData)LuaScriptMgr.GetNetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
		List<UnityEngine.EventSystems.RaycastResult> arg1 = (List<UnityEngine.EventSystems.RaycastResult>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<UnityEngine.EventSystems.RaycastResult>));
		obj.RaycastAll(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsPointerOverGameObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.EventSystems.EventSystem");
			bool o = obj.IsPointerOverGameObject();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.EventSystems.EventSystem");
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool o = obj.IsPointerOverGameObject(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.EventSystems.EventSystem.IsPointerOverGameObject");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UnityEngine.EventSystems.EventSystem obj = (UnityEngine.EventSystems.EventSystem)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UnityEngine.EventSystems.EventSystem");
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
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

