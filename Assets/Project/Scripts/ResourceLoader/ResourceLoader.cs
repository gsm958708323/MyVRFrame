using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRFrame
{
    public enum SourceType
    {
        SequenceFrame,//序列帧
        Prefab,//预制件
        Image,//图片
        Sound//声音
    }
    /// <summary>
    /// 不同数据类型
    /// </summary>
    public class AssetSource
    {
        public AudioClip audioClip;
        public Texture2D texture2D;
        public Texture2D[] frameImage;
        public GameObject gameObject;
        public byte[] data;
    }
    public class ResourceLoader : MonoSingleton<ResourceLoader>
    {
        private Dictionary<SourceType, ILoader> loaderManager = new Dictionary<SourceType, ILoader>();

        private ResourceLoader()
        {
            loaderManager.Add(SourceType.Image, new ImageLoader());
            loaderManager.Add(SourceType.Prefab, new PrefabLoader());
            loaderManager.Add(SourceType.SequenceFrame, new SequenceFrameLoader());
            loaderManager.Add(SourceType.Sound, new SoundLoader());
        }

        public AssetSource LoadAsset(SourceType type, string path)
        {
            if (loaderManager.Count > 0 || loaderManager.ContainsKey(type))
            {
                return loaderManager[type].Run(path);
            }
            return null;
        }
    }

}
