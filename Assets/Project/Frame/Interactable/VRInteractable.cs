//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//namespace VRFrame
//{
//    public class VRInteractable : MonoBehaviour
//    {
//        //public Button button;
//        private bool isEnter = false;
//        private void Awake()
//        {
////            ushort[] msgids = new ushort[]
////{
////                (ushort)UIEvent.MSG_RAY_HIT
////};
////            EventManager.Instance.RegistMsg(msgids, this);

//            //Button button = GetComponent<Button>();
//            //button.onClick.AddListener(() =>
//            //{
//            //    Debug.LogWarning("button click ！");
//            //}
//            //);
//        }

//        public override void ProcessEvent(MsgBase msg)
//        {
//            switch (msg.Id)
//            {
//                case (ushort)UIEvent.MSG_RAY_HIT:
//                    HitInfo info = (HitInfo)msg.Data;
//                    //Debug.Log(info.Hit.name);
//                    if (info.Hit == this.gameObject && info != null && info.Hit != null)
//                    {//射线进入
//                        OnHitUpdate(info);
//                        if (!isEnter)
//                        {
//                            isEnter = true;
//                            OnHitEnter(info);
//                        }
//                    }
//                    else//射线离开
//                    {
//                        if (isEnter)
//                        {
//                            isEnter = false;
//                            OnHitExit(info);
//                        }
//                    }
//                    break;
//            }
//        }

//        private void OnHitExit(HitInfo info)
//        {
//            Debug.Log("射线退出！");
//            //button.OnDeselect(data);
//        }

//        private void OnHitEnter(HitInfo info)
//        {
//            Debug.Log("射线进入！");
//            //button.OnSelect(new BaseEventData(new EventSystem()));
//            //button.OnSelect(data);
//        }

//        BaseEventData data;
//        private void OnHitUpdate(HitInfo info)
//        {
//            if (InputFactory.Instance.Create().GetButtonDown(ButtonType.Trigger, HandType.Any))
//            {
//                //button = info.Hit.GetComponent<Button>();
//                //button.onClick?.Invoke();
//                //data = new BaseEventData(EventSystem.current)
//                //{
//                //    selectedObject = gameObject
//                //};
//            }
//        }
//    }
//}
