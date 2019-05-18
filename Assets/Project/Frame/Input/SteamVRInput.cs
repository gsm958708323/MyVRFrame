using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRFrame
{
    public class SteamVRInput : IInput
    {
        #region 按键事件
        /// <summary>
        /// 交互动作 菜单键
        /// </summary>
        private SteamVR_Action_Boolean m_InteractUI = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
        /// <summary>
        /// 瞬移 圆盘键
        /// </summary>
        private SteamVR_Action_Boolean m_Teleport = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");
        /// <summary>
        /// 扳机键触发
        /// </summary>
        private SteamVR_Action_Boolean m_GrabPinch = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
        /// <summary>
        /// 握持键触发
        /// </summary>
        private SteamVR_Action_Boolean m_GrabGrip = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
        #endregion
        #region 数值
        private SteamVR_Action_Vector2 m_Touch = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("Touch");
        private SteamVR_Action_Single m_Squeeze = SteamVR_Input.GetAction<SteamVR_Action_Single>("Squeeze");
        #endregion

        private Dictionary<ButtonType, SteamVR_Action_Boolean> m_ButtonDic;
        private Dictionary<HandType, SteamVR_Input_Sources> m_HandDic;

        public SteamVRInput()
        {
            m_ButtonDic = new Dictionary<ButtonType, SteamVR_Action_Boolean>()
        {
            {ButtonType.Grip,m_GrabGrip},
            {ButtonType.Menu,m_InteractUI },
            {ButtonType.Touch,m_Teleport },
            {ButtonType.Trigger,m_GrabPinch }
        };
            m_HandDic = new Dictionary<HandType, SteamVR_Input_Sources>()
        {
            {HandType.LeftHand , SteamVR_Input_Sources.LeftHand },
            {HandType.RightHand,SteamVR_Input_Sources.RightHand },
            {HandType.Any,SteamVR_Input_Sources.Any }
        };
        }

        public bool GetButton(ButtonType button, HandType hand)
        {
            return m_ButtonDic[button].GetState(m_HandDic[hand]);
        }

        public bool GetButtonDown(ButtonType button, HandType hand)
        {
            return m_ButtonDic[button].GetStateDown(m_HandDic[hand]);
        }

        public bool GetButtonUp(ButtonType button, HandType hand)
        {
            return m_ButtonDic[button].GetStateUp(m_HandDic[hand]);
        }

        public Vector2 GetTouchAxis(HandType hand)
        {
            return m_Touch.GetAxis(m_HandDic[hand]);
        }

        public float GetTriggerValue(HandType hand)
        {
            return m_Squeeze.GetAxis(m_HandDic[hand]);
        }

    }
}

