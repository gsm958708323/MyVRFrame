using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRFrame;

public class Test : MonoBehaviour
{
    SteamVRInput input = new SteamVRInput();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (input.GetButton(ButtonType.Trigger, HandType.Any))
        //{
        //    Debug.Log("扳机按下：" + input.GetTriggerValue(HandType.Any));
        //}
        //if (input.GetButton(ButtonType.Touch, HandType.Any))
        //{
        //    Debug.Log("圆盘键按下：" + input.GetTouchAxis(HandType.Any));
        //}
        //if (input.GetButtonDown(ButtonType.Menu, HandType.Any))
        //{
        //    Debug.Log("菜单键按下");
        //}
        //if (input.GetButtonDown(ButtonType.Grip, HandType.Any))
        //{
        //    Debug.Log("握持键按下");
        //}

        //if (InputFactory.Instance.Create().GetButtonDown(ButtonType.Trigger, HandType.Any))
        //{
        //    Debug.Log("扳机按下：" + InputFactory.Instance.Create().GetTriggerValue(HandType.Any));

        //    EventManager.Instance.BroadcastMsg(new MsgBase((ushort)UIEvent.MSG_RAY_HIT));
        //}
    }
}


