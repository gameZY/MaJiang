using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Teacher {
    public class LuaBehaviour : View {
        private string data = null;
        private List<LuaFunction> buttons = new List<LuaFunction>();
        protected static bool initialize = false;

        protected void Awake() {
            CallMethod("Awake", gameObject);
        }

        protected void Start() {
            if (LuaManager != null && initialize) {
                LuaState l = LuaManager.lua;
                l[name + ".transform"] = transform;
                l[name + ".gameObject"] = gameObject;
            }
            CallMethod("Start");
        }

        void Update()
        {
            CallMethod("Update");
        }

        void OnEnable()
        {
            CallMethod("OnEnable");
        }

        void OnDisable()
        {
            CallMethod("OnDisable");
        }

        protected void OnClick() {
            CallMethod("OnClick");
        }

        protected void OnClickEvent(GameObject go) {
            CallMethod("OnClick", go);
        }

        /// <summary>
        /// 添加单击事件
        /// </summary>
        public void AddClick1(GameObject go, LuaFunction luafunc) {
            if (go == null) return;
            //buttons.Add(luafunc);
            go.GetComponent<Button>().onClick.RemoveAllListeners();
            go.GetComponent<Button>().onClick.AddListener(
                delegate()
                {
                    luafunc.Call(go);
                }
            );
        }

        public void AddClick(GameObject go, LuaFunction luafunc)
        {
            EventTriggerListener.Get(go).onClick = (_go) =>
            {
                luafunc.Call(_go);
            };
        }

        public void SetName(GameObject go,string name)
        {
            go.name = name;
        }

        public void SetColor(GameObject go,Color color)
        {
            if (go == null) return;
            Image img = go.GetComponent<Image>();
            if (img != null)
            {
                img.color = color;
            }
        }

        public void SetLabelColor(GameObject go,Color color)
        {
            if (go == null) return;
            Text img = go.GetComponent<Text>();
            if (img != null)
            {
                img.color = color;
            }
        }

        public object[] Call(string func, params object[] args)
        {
            return CallMethod(func, args);
        }

        /// <summary>
        /// 清除单击事件
        /// </summary>
        public void ClearClick() {
            for (int i = 0; i < buttons.Count; i++) {
                if (buttons[i] != null) {
                    buttons[i].Dispose();
                    buttons[i] = null;
                }
            }
        }

        /// <summary>
        /// 执行Lua方法
        /// </summary>
        protected object[] CallMethod(string func, params object[] args) {
            if (!initialize) return null;
            return Util.CallMethod(name, func, args);
        }

        //-----------------------------------------------------------------
        protected void OnDestroy() {
            ClearClick();
            LuaManager = null;
            Util.ClearMemory();
            Debug.Log("~" + name + " was destroy!");
            CallMethod("OnDestroy");
        }
    }
}