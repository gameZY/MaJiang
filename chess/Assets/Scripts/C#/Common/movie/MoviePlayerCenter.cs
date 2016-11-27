using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


/// <summary>
/// 影片播放器中心
/// </summary>
public static class MoviePlayerCenter
{
    //播放器
    private static IMoviePlayer _player;

    static MoviePlayerCenter()
    {
#if UNITY_STANDALONE_WIN
        _player = new PCMoviePlayer();
#else
        _player = new MoblieMoviePlayer();
#endif
    }

    public static void Play(string name,MyAction onFinishedCallBack)
    {
        _player.Play(name, () =>
        {
            Debug.LogError("播放完毕:"+name);
            if (onFinishedCallBack != null)
                onFinishedCallBack();
        });
    }
}