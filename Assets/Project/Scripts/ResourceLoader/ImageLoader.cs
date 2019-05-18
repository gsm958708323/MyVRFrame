using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRFrame
{
    public class ImageLoader : LoaderBase
    {
        public override AssetSource Run(string path)
        {
            Texture2D texture2d = Resources.Load<Texture2D>(path);
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            if (texture2d != null)
                return new AssetSource { texture2D = texture2d };
            else
                return null;
        }
    }
}
