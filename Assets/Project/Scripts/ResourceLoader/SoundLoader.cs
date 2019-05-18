using UnityEngine;
using System.Collections;

namespace VRFrame
{
    public class SoundLoader : LoaderBase
    {
        public override AssetSource Run(string path)
        {
            AudioClip clip = Resources.Load<AudioClip>(path);
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            if (clip != null)
            {
                return new AssetSource { audioClip = clip };
            }
            else
            {
                Debug.LogError("音效加载错误：" + path);
                return null;
            }
        }
    }
}
