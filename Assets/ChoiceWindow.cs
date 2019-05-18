using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VRFrame;
using DG.Tweening;

/// <summary>
/// 处理UI动画
/// </summary>
public class ChoiceWindow : BasePanel
{
    public override void OnEnter()
    {
        gameObject.SetActive(true);
        transform.DOScale(0.01f, 0.5f);
    }

    public override void OnExit()
    {
        transform.DOScale(0, 0.5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
