using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Teacher;

/// <summary>
/// 影片播放器
/// </summary>
#if UNITY_STANDALONE_WIN
public class PCMoviePlayer:IMoviePlayer
{
    //影片文件名
    private string _fileName = null;
    //影片纹理
    private MovieTexture _mtex = null;
    //声音播放设备
    private AudioSource _audio = null;
    //材质球
    private Renderer _render = null;
    //WWW的类
    private WWW _www = null;
    //完成回调
    private MyAction _finishedCallBack;
    //是否正在播放
    private bool _isPlay = false;

    //播放的载体go
    private GameObject _filmGo;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="go"></param>
    public PCMoviePlayer()
    {
        _filmGo = InitFilmGo();
        _audio = _filmGo.GetComponent<AudioSource>();
        if(_audio == null)
        {
            _audio = _filmGo.AddComponent<AudioSource>();
        }
        _render = _filmGo.GetComponent<Renderer>();            
        _render.enabled = false;
        var script = _filmGo.GetComponent<PCMoviePlayerScript>();
        if(script == null)
        {
            script = _filmGo.AddComponent<PCMoviePlayerScript>();
        }
        script.SetPlayer(this);
        _render.sharedMaterial.shader = Shader.Find("Unlit/Transparent");
    }

    /// <summary>
    /// 文件需要放在StreammingAssets下,通过PathUtils来进行组合.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="finishedCallBack"></param>
    public void Play(string fileName, MyAction finishedCallBack)
    {
        if (!_isPlay)
        {
            _isPlay = true;
            _filmGo.SetActive(true);
            _fileName = fileName;
            _finishedCallBack = finishedCallBack;
            var script = _filmGo.GetComponent<PCMoviePlayerScript>();
            script.StartCoroutine(LoadMovie());
        }
        else
        {
            Debug.Log(string.Format("当前影片[{0}]正在播放,不能播放影片:[{1}]", _fileName, fileName));
        }
    }

    /// <summary>
    /// 停止播放
    /// </summary>
    public void Stop()
    {
        _isPlay = false;           
    }

    /// <summary>
    /// 加载影片
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadMovie()
    {
        string url = "file://" + Application.streamingAssetsPath + "/" + _fileName;
        Debug.Log("==movie====" + url);
        _www = new WWW(url);
        if (_www == null)
        {
            Finished();
            yield break;
        }

        while (!_www.isDone)
        {
            //如果停止播放,那么久直接关闭
            if (!_isPlay)
            {
                Debug.Log(string.Format("影片[{0}]加载时,被手动退出!", _fileName));
                Finished();
                yield break;
            }
            yield return null;
        }
            
        if (_isPlay && _www.size > 0 && string.IsNullOrEmpty(_www.error))
        {
            var movie = (MovieTexture)_www.movie;
            if (movie != null)
            {
                int num = 0;
                while (!movie.isReadyToPlay)
                {
                    num++;
                    yield return null;
                    if (num > 120)
                    {
                        Debug.Log(string.Format("影片[{0}]准备超时或者影片不存在,退出!",_fileName));
                        Finished();
                        yield break;
                    }
                    if (!_isPlay)
                    {
                        Debug.Log(string.Format("影片[{0}]准备时,被手动退出!", _fileName));
                        Finished();
                        yield break;
                    }
                }
                _mtex = movie;
                PlayEx();
                yield return null;
                //启动影片状态监测
                var script = _filmGo.GetComponent<PCMoviePlayerScript>();
                yield return script.StartCoroutine(CheckMovieState());
            }
        }
        else
        {
            Debug.Log(string.Format("影片[{0}]加载失败,退出!WWW.ERR:[{1}]", _fileName, _www.error));
            Finished();
        }
    }

    /// <summary>
    /// 检验影片的状态
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckMovieState()
    {
        while (_isPlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                     
            }
            if (!_mtex.isPlaying)
            {
                //如果当前影片播放完毕就退出
                break;                    
            }
            yield return null;
        }
        Finished();
    }

    //播放
    private void PlayEx()
    {
        if (_mtex != null)
        {
            _render.material.mainTexture = _mtex;
            _audio.clip = _mtex.audioClip;
            _mtex.Play();
            _audio.Play();
            _render.enabled = true;
        }
    }     

    //恢复
    private void Reset()
    {   
        //充值变量
        _isPlay = false;   

        //影片纹理 停止
        if (_mtex != null)
        {
            _mtex.Stop();
        }

        //声音 停止
        if (_audio != null)
        {
            _audio.Stop();
        }

        _render.enabled = false;
        _render.sharedMaterial.mainTexture = null;
        _audio.clip = null;
        _www = null;
        if (_mtex != null)
        {
            Resources.UnloadAsset(_mtex);
            _mtex = null;
        }

        Resources.UnloadUnusedAssets(); 
        _filmGo.SetActive(false);
    }

    //完成
    private void Finished()
    {
        Reset();
        if (_finishedCallBack != null)
            _finishedCallBack();
    }

    /// <summary>
    /// 初始化影片播放的载体Go
    /// </summary>
    /// <returns></returns>
    private GameObject InitFilmGo()
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Plane);
        go.name = "[MoviePlayerGo]";            
        go.AddComponent<AudioSource>();            
        go.transform.position = Vector3.zero;
        go.transform.eulerAngles = Vector3.zero;

        float curAspect =  (float)Screen.width / (float)Screen.height;
        go.transform.localScale = new Vector3(curAspect, 1, 1);

        var cameraGo = new GameObject("[MovieCamera]");
        cameraGo.transform.parent = go.transform;
        //10是,Plane的长度
        cameraGo.transform.localPosition = new Vector3(0, 10 * Mathf.Sin(Mathf.PI/3f), 0);
        cameraGo.transform.localEulerAngles = new Vector3(90,180,0);
        cameraGo.transform.localScale = Vector3.one;

        var cam = cameraGo.AddComponent<Camera>();
        cam.backgroundColor = Color.white;
        cam.depth = 20;
        cam.farClipPlane = 20;

        cameraGo.AddComponent<AudioListener>();

        GameObject.DontDestroyOnLoad(go);

        return go; 
    }
}
#endif