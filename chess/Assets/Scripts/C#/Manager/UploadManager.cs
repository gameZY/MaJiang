using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using LuaInterface;
using Teacher;
using Teacher.Manager;
using LuaInterface;

public class UploadManager
{
    public static UploadManager self = new UploadManager();

    List<string> downloadFiles = new List<string>();
    string strState = "";
    bool indown = false;
    bool iszip = false;
    int zip_current_count = 0;
    int zip_file_count = 0;

    GameObject checkUpdate = null;
    Image progress_bar = null;
    Text state_text = null;

    public void Init()
    {
        checkUpdate = GameObject.Find("updatepanel");
        progress_bar = checkUpdate.transform.Find("Progress_bar").gameObject.GetComponent<Image>();
        state_text = checkUpdate.transform.Find("Update_txt").gameObject.GetComponent<Text>();
    }

    public void Update()
    {
        if (checkUpdate != null)
        {
            ResmgrNative.Instance.Update();
            if (indown)
            {
                float x = (float)ResmgrNative.Instance.taskState.downloadcount / ResmgrNative.Instance.taskState.taskcount;
                progress_bar.fillAmount = x;
                int progress = (int)(x * 100);
                strState = "正在更新:" + progress.ToString() + "%";
            }
            if (iszip)
            {
                float x = (float)zip_current_count / zip_file_count;
                progress_bar.fillAmount = x;
                int progress = (int)(x * 100);
                strState = "正在解压:" + progress.ToString() + "%";
            }
            state_text.text = strState;
        }
    }

    void OnInitFinish(System.Exception err)
    {
        if (err == null)
        {
            ResmgrNative.Instance.taskState.Clear();
            strState = "检查资源完成";
            List<string> wantdownGroup = new List<string>();
            wantdownGroup.Add("lua");
            wantdownGroup.Add("android_assetbundles");
            var downlist = ResmgrNative.Instance.GetNeedDownloadRes(wantdownGroup);
            foreach (var d in downlist)
            {
                d.Download(null);
            }
            ResmgrNative.Instance.WaitForTaskFinish(DownLoadFinish);
            indown = true;
            strState = "更新资源....";
        }
        else
        {
            strState = null;
        }
    }

    void DownLoadFinish()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().StartLoadAB();
    }

    public IEnumerator copyLuaPathToPersistent()
    {
        strState = "正在解压...";

        string resDir = Util.GetCopyResPath();
        string targetDir = Util.GetCopyTargetPath();

        if (!Directory.Exists(targetDir))
        {
            Directory.CreateDirectory(targetDir);
        }

        string resABPath = null;
        string dataABPath = null;
        if (!Application.isEditor)
        {
            resABPath = resDir + "android_assetbundles/";
            dataABPath = targetDir + "android_assetbundles/";
        }

        string infile = resDir + "allver.ver.txt";
        string outfile = targetDir + "allver.ver.txt";
        WWW www = null;
        if (!File.Exists(outfile))
        {
            www = new WWW(Util.addWWWLuaPath(infile));
            yield return www;
            if (www.isDone)
            {
                File.WriteAllBytes(outfile, www.bytes);
            }
        }

        string abinfile = null;
        string aboutfile = null;
        if (!Application.isEditor)
        {
            abinfile = resDir + "android_assetbundles.ver.txt";
            aboutfile = targetDir + "android_assetbundles.ver.txt";
        }

        if (!File.Exists(aboutfile))
        {
            www = new WWW(Util.addWWWLuaPath(abinfile));
            yield return www;
            if (www.isDone)
            {
                File.WriteAllBytes(aboutfile, www.bytes);
            }
        }
        string[] abfiles = File.ReadAllLines(aboutfile);
        zip_file_count += int.Parse(abfiles[0].Split(':')[2]);

        iszip = true;
        for (int i = 1; i < abfiles.Length; i++)
        {
            string file = abfiles[i];
            string[] fs = file.Split('|');
            abinfile = resABPath + fs[0];
            aboutfile = dataABPath + fs[0];

            Debug.Log("正在解包文件:>" + abinfile);

            string dir = Path.GetDirectoryName(aboutfile);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (File.Exists(aboutfile))
            {
                zip_current_count++;
                continue;
            }

            www = new WWW(Util.addWWWLuaPath(abinfile));
            yield return www;

            if (www.isDone)
            {
                File.WriteAllBytes(aboutfile, www.bytes);
                zip_current_count++;
            }
            yield return 0;
            yield return new WaitForEndOfFrame();
        }

        strState = "解包完成";
        iszip = false;

        //InitResDown();
        DownLoadFinish();
    }

    public void InitResDown()
    {
        List<string> wantdownGroup = new List<string>();
        string platform = "android";
        wantdownGroup.Add("lua");
        wantdownGroup.Add("android_assetbundles");
        ResmgrNative.Instance.BeginInit("http://www.cdzhuoqing.com:8090/" + "upload/" + platform + "/", OnInitFinish, wantdownGroup);
    }

    public void downLoadFile(LuaInterface.LuaTable evParams, LuaFunction UpdateProgress, LuaFunction DownLoadFinish)
    {
        ThreadManager manager = AppFacade.Instance.GetManager<ThreadManager>(ManagerName.Thread);
        manager.DownloadFile(evParams, UpdateProgress, DownLoadFinish);
    }
}