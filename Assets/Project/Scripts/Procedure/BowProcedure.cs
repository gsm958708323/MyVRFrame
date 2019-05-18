using UnityEngine;
using System.Collections;

namespace VRFrame
{
    public class BowProcedure : ProcedureBase
    {
        public override void OnEnter()
        {
            TweenPathManager.Instance.AddEvent(PlayerController.Instance.GetTweenPath(), 2, () =>
            {
                PlayerController.Instance.Pause();
                SceneManager.Instance.bowCtrl.Init();
            });
        }
    }
}