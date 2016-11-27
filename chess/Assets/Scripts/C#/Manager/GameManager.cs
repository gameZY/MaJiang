using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System.Reflection;
using System.IO;
using Junfine.Debuger;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Umeng;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Teacher.Manager {
    public class GameManager : LuaBehaviour {
        public LuaScriptMgr uluaMgr;

        /// <summary>
        /// 初始化游戏管理器
        /// </summary>
        void Awake() {
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        void Init() {
            DontDestroyOnLoad(gameObject);  //防止销毁自己
            
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Application.targetFrameRate = AppConst.GameFrameRate;
            
            InitFinished();
        }

        IEnumerator LoadLuaAB()
        {
            ResourceManager.BaseDownloadingURL = Util.GetAssetBundlePath();
            var _request = ResourceManager.Initialize(Util.GetMainfestPathName());
            if (_request != null)
                yield return StartCoroutine(_request);
            AssetBundleAssetOperation request = ResourceManager.LoadAssetAsync("lua", "lua", typeof(AssetBundle));
            if (request == null) yield break;
            yield return StartCoroutine(request);

            // Get the asset.
            AssetBundle LuaAB = request.GetAssetBundle();
            LuaFileUtils.Instance.SetLuaBundle(LuaAB);
            StartGameManager();
        }

        public void StartLoadAB()
        {
            StartCoroutine(LoadLuaAB());
        }

        void InitFinished()
        {
            if (Application.isEditor)
            {
                StartLoadAB();
            }
            else
            {
                UploadManager.self.Init();
                StartCoroutine(UploadManager.self.copyLuaPathToPersistent());
            }
        }

        public void StartGameManager()
        {
            LuaManager.Start();
            LuaManager.DoFile("Logic/GameManager");
            initialize = true;

            CallMethod("OnInitOK");
        }


        void Update() {
            if (LuaManager != null && initialize) {
                LuaManager.Update();
                CallMethod("Update");
            }

            UploadManager.self.Update();
        }

        void LateUpdate() {
            if (LuaManager != null && initialize) {
                LuaManager.LateUpate();
            }
        }

        void FixedUpdate() {
            if (LuaManager != null && initialize) {
                LuaManager.FixedUpdate();
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        void OnDestroy() {
            if (NetManager != null) {
                NetManager.Unload();
            }
            if (LuaManager != null) {
                LuaManager.Destroy();
                LuaManager = null;
            }
            Debug.Log("~GameManager was destroyed");
        }
    }
}