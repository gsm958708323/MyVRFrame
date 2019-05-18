using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRFrame;
using DG.Tweening;

public class SphereWindow : BasePanel
{
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private void OnTriggerStay(Collider other)
    {
        if (InputFactory.Instance.Create().GetButtonDown(ButtonType.Trigger, HandType.Any))
        {
            EventManager.Instance.BroadcastMsg(new MsgBase((ushort)SphereItemtMsg.SphereGameStart));
        }
    }
}
