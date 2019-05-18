using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRFrame;

public class PlayerController : MonoSingleton<PlayerController>
{
    public Transform leftRay, rightRay;
    public DOTweenPath dotweenPath;

    private Hand leftHand, rightHand;
    private bool isMove;

    private void Update()
    {
        //CheckHand();
        CheckPath();
    }

    public DOTweenPath GetTweenPath()
    {
        if (dotweenPath != null)
            return dotweenPath;
        return null;
    }

    public void Pause()
    {
        isMove = false;
    }

    public void Move()
    {
        isMove = true;
    }

    private void CheckPath()
    {
        if (isMove)
        {
            dotweenPath.DOPlay();
        }
        else
        {
            dotweenPath.DOPause();
        }
    }

    private void CheckHand()
    {
        if (leftRay != null)
        {
            leftHand = GetHand(HandType.LeftHand);
            rightHand = GetHand(HandType.RightHand);
            leftRay.gameObject.SetActive(leftHand.isActive);
            rightRay.gameObject.SetActive(rightHand.isActive);
        }
    }

    public Hand GetHand(HandType type)
    {
        Hand hand = null;
        switch (type)
        {
            case HandType.LeftHand:
                hand = Player.instance.leftHand;
                break;
            case HandType.RightHand:
                hand = Player.instance.rightHand;
                break;
        }
        return hand;
    }
}
