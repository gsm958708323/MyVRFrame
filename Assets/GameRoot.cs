using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using VRFrame;

public class GameRoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ProcedureManager.Instance.ChangeProcedure(ProcedureType.Choice);
    }
}
