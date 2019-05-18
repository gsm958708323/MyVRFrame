using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRFrame
{
    public class SequenceFrameLoader : LoaderBase
    {
        public override AssetSource Run(string path)
        {
            Texture2D[] texture2ds = Resources.LoadAll<Texture2D>(path);
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            if (texture2ds != null && texture2ds.Length > 0)
                return new AssetSource { frameImage = texture2ds };
            else
            {
                Debug.LogError("序列帧加载错误：" + path);
                return null;
            }


        }
    }

}
