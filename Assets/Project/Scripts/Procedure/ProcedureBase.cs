using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRFrame
{
    /// <summary>
 /// 游戏流程
 /// </summary>
    public abstract class ProcedureBase
    {
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate() { }
    }
    public enum ProcedureType
    {
        None,

        Choice,

        SphereGame,

        BowGame
    }

}
