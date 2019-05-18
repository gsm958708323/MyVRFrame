using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRFrame
{
    public abstract class ItemBase : MonoBehaviour
    {
        protected Transform defaultGameObject;
        protected Vector3 defaultPos, defaultAngle, defaultScale;

        public void SetDefaultGo(Transform go)
        {
            defaultGameObject = go;
            Init();
        }

        public virtual void Init()
        {
            if (defaultGameObject == null)
                defaultGameObject = transform;
            defaultPos = defaultGameObject.localPosition;
            defaultAngle = defaultGameObject.localEulerAngles;
            defaultScale = defaultGameObject.localScale;
        }

        public virtual void Quit()
        {
            defaultGameObject.localPosition = defaultPos;
            defaultGameObject.localEulerAngles = defaultAngle;
            defaultGameObject.localScale = defaultScale;
        }
    }
}
