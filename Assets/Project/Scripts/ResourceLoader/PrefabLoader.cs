using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRFrame
{
    public class PrefabLoader : LoaderBase
    {
        private Dictionary<string, GameObject> prefabDic = new Dictionary<string, GameObject>();
        private Transform uiRoot = null;
        public override AssetSource Run(string path)
        {
            if (prefabDic.ContainsKey(path))
            {
                return new AssetSource { gameObject = prefabDic[path] };
            }
            else
            {
                GameObject prefab = Resources.Load<GameObject>(path);
                if (prefab != null)
                {
                    if (uiRoot == null) uiRoot = GameObject.FindGameObjectWithTag("UIRoot").transform;
                    GameObject o = GameObject.Instantiate(prefab);
                    o.name = prefab.name;
                    o.transform.SetParent(uiRoot.transform);
                    o.transform.localPosition = prefab.transform.localPosition;
                    o.transform.localEulerAngles = prefab.transform.localEulerAngles;
                    o.transform.localScale = prefab.transform.localScale;
                    prefabDic.Add(path, o);
                    return new AssetSource { gameObject = o };
                }
                else
                {
                    Debug.LogError("实例化错误：" + path);
                    return null;
                }
            }
        }
    }

}
