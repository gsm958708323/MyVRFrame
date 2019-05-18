using UnityEngine;
using System.Collections;
using Valve.VR;

namespace VRFrame
{
    public class SphereProcedure : ProcedureBase, IEventBase
    {
        ushort[] msgIds = new ushort[]
        {
           (ushort) SphereItemtMsg.SphereGameStart,
           (ushort)SphereItemtMsg.SphereGameSuccess
        };
        public override void OnEnter()
        {
            EventManager.Instance.RegistMsg(msgIds, this);
            Debug.Log("DarkSmokeProcedure  Enter !");
            SteamVR_Fade.Start(Color.black, 0);
            SteamVR_Fade.Start(Color.clear, 1f);

            TweenPathManager.Instance.AddEvent(PlayerController.Instance.GetTweenPath(), 1, MoveNextItem);
        }

        void MoveNextItem()
        {
            PlayerController.Instance.Pause();
            UIManager.Instance.PushPanel(PanelType.SpehreUI);
        }

        public void ProcessEvent(MsgBase msg)
        {
            switch (msg.Id)
            {
                case (ushort)SphereItemtMsg.SphereGameStart:
                    {
                        UIManager.Instance.PopPanel();
                        SceneManager.Instance.spereCtrl.Init();
                    }
                    break;
                case (ushort)SphereItemtMsg.SphereGameSuccess:
                    {
                        //退出游戏，打开成功UI，切换流程,人物移动
                        SceneManager.Instance.spereCtrl.Quit();
                        UIManager.Instance.PushPanel(PanelType.SpehreSuccessUI);
                    }
                    break;
            }
        }
    }
}