/*    
 * Copyright (c) 2015.10 , 蒙占志 (Zhanzhi Meng) topameng@gmail.com
 * Use, modification and distribution are subject to the "MIT License"
 * (bezip = false)在search path 中查找读取lua文件。
 * (bezip = true)可以从外部设置过来bundel文件中读取lua文件。
*/

using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using Teacher;

public class LuaFileUtils
{
    public static LuaFileUtils Instance
    {
        get
        {
            if (instance == null)
            {
                Instance = new LuaFileUtils();
            }

            return instance;
        }

        protected set
        {
            instance = value;
        }
    }

    public bool beZip = false;    
    protected List<string> searchPaths = new List<string>();      
    protected Dictionary<string, AssetBundle> zipMap = new Dictionary<string, AssetBundle>();
    AssetBundle LuaBundle = null;
    protected static LuaFileUtils instance = null;

    public LuaFileUtils()
    {
        instance = this;    
    }

    public virtual void Dispose()
    {
        if (instance != null)
        {
            instance = null;
            searchPaths.Clear();

            foreach (KeyValuePair<string, AssetBundle> iter in zipMap)
            {
                iter.Value.Unload(true);
            }

            zipMap.Clear();
        }
    }
    public AssetBundle GetLuaAb()
    {
        return LuaBundle;
    }
    public void UnloadAb()
    {
        if (LuaBundle != null)
        LuaBundle.Unload(false);
        LuaBundle = null;
    }
    public void AddSearchPath(string path, bool front = false)
    {
        if (path.Length > 0 && path[path.Length - 1] != '/')
        {
            path += "/";
        }        

        if (front)
        {
            searchPaths.Insert(0, path);
        }
        else
        {
            searchPaths.Add(path);
        }
    }

    public void RemoveSearchPath(string path)
    {
        if (path.Length > 0 && path[path.Length - 1] != '/')
        {
            path += "/";
        }

        int index = searchPaths.IndexOf(path);

        if (index >= 0)
        {
            searchPaths.RemoveAt(index);
        }
    }
    public void SetLuaBundle(AssetBundle ab)
    {
        LuaBundle = ab;
    }
    public void AddSearchBundle(string name, AssetBundle bundle)
    {
        zipMap[name] = bundle;
        Debugger.Log("Add Lua bundle: " + name);
    }    

    public string GetFullPathFileName(string fileName)
    {
        if (fileName == string.Empty)
        {
            return string.Empty;
        }

        if (Path.IsPathRooted(fileName))
        {
            return fileName;
        }

        string fullPath = null;

        for (int i = 0; i < searchPaths.Count; i++)
        {
            fullPath = Path.Combine(searchPaths[i], fileName);

            if (File.Exists(fullPath))
            {                    
                return fullPath;
            }            
        }
        
        return null;
    }

    public virtual byte[] ReadFile(string fileName)
    {
        if (AppConst.LuaBundleMode)
        {
            Debug.Log("=============start Load=====" + fileName + "========================");
            string strFileName = "";
            int nPos = fileName.LastIndexOf("/");
            if (nPos == -1)
                strFileName = fileName;
            else
                strFileName = fileName.Substring(nPos + 1, fileName.Length - nPos - 1 );

            nPos = strFileName.LastIndexOf(".");
            if (nPos != -1)
                strFileName = strFileName.Substring(0, nPos );

            byte[] bytebuffer = null;
            if (LuaBundle != null)
            {
                TextAsset luaCode = LuaBundle.LoadAsset<TextAsset>(strFileName);
                if (luaCode != null)
                {
                    bytebuffer = luaCode.bytes;

                    Resources.UnloadAsset(luaCode);
                }
                else
                {
                    Debug.Log("Load " + fileName + " Fail, " + fileName + "no exit");
                }
                return bytebuffer;
            }
            Debug.Log("Load " + fileName + " Fail, " + fileName + "no exit");
            return null;
        }
        else {
            Debug.Log("=============start Load=====" + fileName + "========================");
            string path = GetFullPathFileName(fileName);
            Debug.Log("=======path========" + path);
            byte[] str = null;

            if (File.Exists(path))
            {
                str = File.ReadAllBytes(path);
            }
            else
                Debug.Log("Load " + fileName + " Fail, " + fileName + "no exit");

            return str; 
        }
    }

    byte[] ReadZipFile(string fileName)
    {
        AssetBundle zipFile = null;
        byte[] buffer = null;
        string zipName = "Lua";
        int pos = fileName.LastIndexOf('/');

        if (pos > 0)
        {
            zipName = fileName.Substring(0, pos);
            zipName = zipName.Replace('/', '_');
            zipName = string.Format("Lua_{0}", zipName);            
            fileName = fileName.Substring(pos + 1);
        }

        zipMap.TryGetValue(zipName.ToLower(), out zipFile);        

        if (zipFile != null)
        {
#if UNITY_5
            string[] names = zipFile.GetAllAssetNames();
            for (int i = 0; i < names.Length; i++) {
                if (names[i].EndsWith(fileName.ToLower() + ".bytes")) {
                    fileName = names[i];
                    break;
                }
            }
            TextAsset luaCode = zipFile.LoadAsset<TextAsset>(fileName);
#else
            TextAsset luaCode = zipFile.Load(fileName, typeof(TextAsset)) as TextAsset;
#endif            

            if (luaCode != null)
            {
                buffer = luaCode.bytes;
                Resources.UnloadAsset(luaCode);
            }
        }

        return buffer;
    }

    public static string GetOSDir()
    {
#if UNITY_STANDALONE
        return "Win";
#elif UNITY_ANDROID
        return "Android";
#elif UNITY_IPHONE
        return "IOS";
#else
        return "";
#endif
    }
}
