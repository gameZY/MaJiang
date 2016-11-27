using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


/// <summary>
/// 影片播放器
/// </summary>
public class MoblieMoviePlayer : IMoviePlayer
{
    /// <summary>
    /// 在这里这个媒体文件必须放在StreammingAssets目录下
    /// 这样通过手持类,就能够直接通过名字播放了
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="finishedCallBack"></param>
    public void Play(string fileName, MyAction finishedCallBack)
    {
#if !UNITY_STANDALONE_WIN    
        Handheld.PlayFullScreenMovie(fileName, Color.black, FullScreenMovieControlMode.CancelOnInput);
#endif
        if (finishedCallBack!=null)
            finishedCallBack();
    }


    public void Stop()
    {
        //这个其实没有用            
    }
}

