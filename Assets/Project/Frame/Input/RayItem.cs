using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRFrame;
/// <summary>
/// 根据射线与物体交互
/// </summary>
public class RayItem : MonoBehaviour
{
    public HandType hand;
    public float distacne = 2;
    public Material material;
    public float width = 0.01f;
    private LineRenderer line;
    private bool isShowLine = true;
    private bool isHit;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward * 2);
        if (Physics.Raycast(ray, out RaycastHit hit, distacne))
        {
            HitInfo info = new HitInfo();
            info.Hand = hand;
            info.Hit = hit.collider.gameObject;
            MsgBase msg = new MsgBase((ushort)UIEvent.MSG_RAY_HIT, info);
            EventManager.Instance.BroadcastMsg(msg);
            isHit = true;
        }
        else
        {
            if (isHit)
            {
                isHit = false;
                //发送空的消息,告诉物体已经丢失
                EventManager.Instance.BroadcastMsg(new MsgBase((ushort)UIEvent.MSG_RAY_HIT, new HitInfo()));
            }
        }

        if (line == null)
            CreateLine();
        else
        {
            if (isShowLine)
            {
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position + transform.forward * distacne);
            }
            else
            {
                DestroyLine();
            }
        }
    }

    void CreateLine()
    {
        line = new GameObject("LineRender").AddComponent<LineRenderer>();
        line.transform.SetParent(transform);
        line.material = material;
        line.startWidth = width;
        line.endWidth = width;
    }
    void DestroyLine()
    {
        if (line != null)
            Destroy(line.gameObject);
    }
}
/// <summary>
/// 碰撞信息
/// </summary>
public class HitInfo
{
    public GameObject Hit { get; set; }
    public HandType Hand { get; set; }
}
