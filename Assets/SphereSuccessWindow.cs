using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRFrame;

public class SphereSuccessWindow : BasePanel
{
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private void OnTriggerStay(Collider other)
    {
        if (InputFactory.Instance.Create().GetButtonDown(ButtonType.Trigger, HandType.Any))
        {
            ProcedureManager.Instance.ChangeProcedure(ProcedureType.BowGame);
            PlayerController.Instance.Move();
        }
    }
}
