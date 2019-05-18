using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRFrame;


public class SpereMoveCtrl : ItemBase
{
    public int speed;
    private bool isStart = false;
    private Vector3 touchAxis;
    private Transform sphere;

    private void Start()
    {
        sphere = transform.Find("Sphere");
        SetDefaultGo(sphere);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            if (InputFactory.Instance.Create().GetButton(ButtonType.Touch, HandType.Any))
            {
                touchAxis = InputFactory.Instance.Create().GetTouchAxis(HandType.Any);
                sphere.transform.Translate(new Vector3(touchAxis.x, 0, touchAxis.y) * Time.deltaTime * speed, Space.Self);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.Instance.BroadcastMsgDealy(new MsgBase((ushort)SphereItemtMsg.SphereGameSuccess),2);
        }
    }

    public override void Init()
    {
        base.Init();

        isStart = true;
        gameObject.SetActive(true);
    }

    public override void Quit()
    {
        base.Quit();

        isStart = false;
        gameObject.SetActive(false);
    }
}
