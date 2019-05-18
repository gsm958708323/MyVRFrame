using UnityEngine;
using System.Collections;

namespace VRFrame
{
    public class ChoiceProcedure : ProcedureBase, IEventBase
    {
        //注册事件
        ushort[] msgids = new ushort[]
        {
               (ushort) UIEventMsg.ChoiceUI,
               (ushort) UIEventMsg.Confirm
        };
        public override void OnEnter()
        {
            EventManager.Instance.RegistMsg(msgids, this);

            PlayerController.Instance.GetTweenPath().DORewind();
            UIManager.Instance.PushPanel(PanelType.ChoiceUI);
            Debug.Log("播放选选择界面声音");
            Debug.Log("指引箭头隐藏");
        }


        public void ProcessEvent(MsgBase msg)
        {
            switch (msg.Id)
            {
                case (ushort)UIEventMsg.ChoiceUI:
                    {
                        Debug.Log("播放确认音效");
                        UIManager.Instance.PopPanel();
                        UIManager.Instance.PushPanel(PanelType.TipsUI);
                    }
                    break;
                case (ushort)UIEventMsg.Confirm:
                    {
                        ProcedureManager.Instance.ChangeProcedure(ProcedureType.SphereGame);
                        PlayerController.Instance.Move();
                    }
                    break;
            }

        }


    }
}

