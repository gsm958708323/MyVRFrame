using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace VRFrame
{
    public abstract class LoaderBase : ILoader
    {
        public virtual void Exit()
        {
        }

        public virtual AssetSource Run(string path)
        {
            return new AssetSource();
        }
    }
    public interface ILoader
    {
        AssetSource Run(string path);
        void Exit();
    }
}
