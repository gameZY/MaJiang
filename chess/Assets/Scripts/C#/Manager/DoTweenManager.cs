using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using LuaInterface;

public class DoTweenManager
{
    public static DoTweenManager self = new DoTweenManager();

    public void InitDoTween()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
    }

    public void DoMove(Transform tran, Vector3 to, float duration, LuaFunction onFinished)
    {
        Tweener tweener = tran.DOMove(to, duration).OnComplete(delegate()
        {
            if (onFinished != null)
            {
                onFinished.Call(tran);
            }
        });
        tweener.SetEase(Ease.Linear);
    }

    public void DoLocalMove(Transform tran, Vector3 to, float duration,LuaFunction onFinished=null,float delay=0.0f,int loop=1)
    {
        Tweener tweener = tran.DOLocalMove(to, duration).OnComplete(delegate()
        {
            if (onFinished != null)
            {
                onFinished.Call(tran);
            }
        });
        tweener.SetDelay(delay);
        tweener.SetLoops(loop);
        tweener.SetEase(Ease.Linear);
    }

    public void DoLocalRotate(Transform tran, Vector3 to, float duration,LuaFunction onFinished=null,float delay=0.0f,int loop=1)
    {
        Tweener tweener = tran.DOLocalRotate(to,duration).OnComplete(delegate()
        {
            if (onFinished != null)
            {
                onFinished.Call(tran);
            }
        });
        tweener.SetDelay(delay);
        tweener.SetLoops(loop);
        tweener.SetEase(Ease.Linear);
    }

    public void DoScale(Transform tran, Vector3 to, float duration, LuaFunction onFinished)
    {
        Tweener tweener = tran.DOScale(to, duration).OnComplete(delegate()
        {
            if (onFinished != null)
            {
                onFinished.Call(tran);
            }
        });
        tweener.SetEase(Ease.Linear);
    }

    public void DoFade(Transform tran, float value,float duration,LuaFunction onFinished)
    {
        Image image = tran.GetComponent<Image>();
        image.material.DOFade(value, duration).OnComplete(delegate()
        {
            if (onFinished != null)
            {
                onFinished.Call(tran);
            }
        });
    }

    public void DoValue(float startValue, float endValue, float duration, LuaFunction onUpdateValue)
    {
        DG.Tweening.Core.DOSetter<float> func = (value) =>
        {
            onUpdateValue.Call(value);
        };
        Tweener tweener = DOTween.To(func, startValue, endValue, duration);
        tweener.SetEase(Ease.Linear);
    }
}
