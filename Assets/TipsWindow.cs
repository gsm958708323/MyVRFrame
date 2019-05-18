using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using VRFrame;

public class TipsWindow : BasePanel
{
    private float m_Scale;
    public override void Awake()
    {
        base.Awake();
        m_Scale = transform.localScale.x;
    }
    public override void OnEnter()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(m_Scale, 0.3f);
    }

    public override void OnExit()
    {
        transform.DOScale(0, 0.3f).OnComplete(() =>
         {
             gameObject.SetActive(false);
         });
    }

    private void OnTriggerStay(Collider other)
    {
        if (InputFactory.Instance.Create().GetButtonDown(ButtonType.Trigger, HandType.Any))
        {
            EventManager.Instance.BroadcastMsg(new MsgBase((ushort)UIEventMsg.Confirm));
        }
    }
}
