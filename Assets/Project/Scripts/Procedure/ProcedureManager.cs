using System;
using System.Collections.Generic;
using UnityEngine;


namespace VRFrame
{
    public class ProcedureManager : MonoSingleton<ProcedureManager>
    {
        private ProcedureManager()
        {
            m_ProcedureDic = new Dictionary<ProcedureType, ProcedureBase>()
            {
                {ProcedureType.Choice,new ChoiceProcedure() },
                {ProcedureType.BowGame,new BowProcedure() },
                {ProcedureType.SphereGame,new SphereProcedure() }
            };
        }
        private Dictionary<ProcedureType, ProcedureBase> m_ProcedureDic;
        private ProcedureType m_CurrentType = ProcedureType.None;
        private ProcedureBase m_CurrentProduce;

        private void Update()
        {
            if (m_CurrentType != ProcedureType.None)
            {
                m_CurrentProduce.OnUpdate();
            }
        }

        public void ChangeProcedure(ProcedureType type)
        {
            if (!m_ProcedureDic.ContainsKey(type))
            {
                Debug.LogError("当前流程不存在：" + type);
                return;
            }
            if (type != ProcedureType.None && type != m_CurrentType)
            {
                ProcedureBase procedure = m_ProcedureDic[type];
                procedure.OnEnter();
                m_CurrentProduce = procedure;
                m_CurrentType = type;
                procedure.OnExit();
            }
        }
        public ProcedureBase GetCurrentProcedure()
        {
            return m_CurrentProduce;
        }
        public ProcedureType GetCurrentType()
        {
            return m_CurrentType;
        }
    }
}
