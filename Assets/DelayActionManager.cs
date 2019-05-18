using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace VRFrame
{
    public class DelayActionManager : MonoSingleton<DelayActionManager>
    {
        private class DelayAction
        {
            public Action<MsgBase> m_Callback;
            public MsgBase m_Msg;
            public float m_Delay = 0;
            public DelayAction(Action<MsgBase> action, float delay, MsgBase msg)
            {
                m_Callback = action;
                m_Delay = delay;
                m_Msg = msg;
            }
        }

        private DelayActionManager() { }
        private List<DelayAction> delayList = new List<DelayAction>();

        public void AddDelayAction(Action<MsgBase> action, float delayTime, MsgBase msg)
        {
            if (action == null)
            {
                Debug.LogError("延迟方法为Null，请检查：" + action);
                return;
            }
            delayList.Add(new DelayAction(action, delayTime, msg));
        }

        public void RemoveDelayAction(Action<MsgBase> action, float delayTime, MsgBase msg)
        {
            if (delayList.Count == 0)
                return;
            DelayAction delay = new DelayAction(action, delayTime, msg);
            if (delayList.Contains(delay))
            {
                delayList.Remove(delay);
            }
        }
        private void Update()
        {
            for (int i = 0; i < delayList.Count; i++)
            {
                if (delayList[i].m_Callback != null)
                {
                    delayList[i].m_Delay -= Time.deltaTime;
                    if (delayList[i].m_Delay <= 0)
                    {
                        delayList[i].m_Callback(delayList[i].m_Msg);
                        delayList.Remove(delayList[i]);
                    }
                }
            }
        }

    }
}