using System;
using System.Collections.Generic;
using System.Text;

public delegate void MyAction();

/// <summary>
/// 播放接口
/// </summary>
public interface IMoviePlayer
{
    void Play(string fileName,MyAction finishedCallBack);
    void Stop();
}
