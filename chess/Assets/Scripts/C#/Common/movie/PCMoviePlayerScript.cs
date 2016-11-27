using UnityEngine;
using System.Collections;

/// <summary>
/// PC影片播放器
/// </summary>
public class PCMoviePlayerScript : MonoBehaviour
{

    private IMoviePlayer _player;
	    
    public void SetPlayer(IMoviePlayer player)
    {
        _player = player; 
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        _player.Stop(); 
    }
}

