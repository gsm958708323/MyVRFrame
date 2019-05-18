using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRFrame;

public class BowCtrl : ItemBase
{
    Transform bow;
    private void Start()
    {
        bow = transform.Find("BowPickup");
        SetDefaultGo(bow);
    }

    public override void Init()
    {
        base.Init();

        gameObject.SetActive(true);
    }

    public override void Quit()
    {
        base.Quit();

        gameObject.SetActive(false);
    }
}
