using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.Events;

namespace VRFrame
{
    public class TweenPathManager:Singleton<TweenPathManager>
    {
        private TweenPathManager() { }
        public class TweenPathEvent
        {
            public Dictionary<int, PathEventData> pathEventData = new Dictionary<int, PathEventData>();
        }

        public class PathEventData
        {
            public event UnityAction pathEvent = null;
            public void Action()
            {
                if (pathEvent != null) pathEvent();
                pathEvent = null;
            }
        }

        private Dictionary<DOTweenPath, int> currentStep = new Dictionary<DOTweenPath, int>();
        private Dictionary<DOTweenPath, TweenPathEvent> tweenPathEventHandle = new Dictionary<DOTweenPath, TweenPathEvent>();
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="doTweenPath">doTweenPath 路径</param>
        /// <param name="index">目标位置</param>
        /// <param name="action">回调函数</param>
        public void AddEvent(DOTweenPath doTweenPath, int index, UnityAction action)
        {
            if (!tweenPathEventHandle.ContainsKey(doTweenPath))
            {
                doTweenPath.tween.OnWaypointChange((pointIndex) =>
                {
                    CheckPoint(doTweenPath, pointIndex);
                });
                tweenPathEventHandle.Add(doTweenPath, new TweenPathEvent());
            }
            if (!tweenPathEventHandle[doTweenPath].pathEventData.ContainsKey(index))
            {
                tweenPathEventHandle[doTweenPath].pathEventData[index] = new PathEventData();
            }
            tweenPathEventHandle[doTweenPath].pathEventData[index].pathEvent += action;
        }
        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="doTweenPath">doTweenPath 路径</param>
        /// <param name="index">目标位置</param>
        public void RemoveEvent(DOTweenPath doTweenPath, int index)
        {
            if (index >= 0 && index < doTweenPath.wps.Count)
            {
                if (tweenPathEventHandle.ContainsKey(doTweenPath))
                {
                    tweenPathEventHandle[doTweenPath].pathEventData[index] = new PathEventData();
                }
            }
        }
        /// <summary>
        /// 移除路径
        /// </summary>
        /// <param name="tweenPath">doTweenPath 路径</param>
        public void RemovePath(DOTweenPath tweenPath)
        {
            if (tweenPathEventHandle.ContainsKey(tweenPath))
            {
                tweenPath.tween.OnWaypointChange(null);
                tweenPathEventHandle.Remove(tweenPath);
                if (currentStep.ContainsKey(tweenPath)) currentStep.Remove(tweenPath);
            }
        }
        /// <summary>
        /// 检测目标点事件if
        /// </summary>
        /// <param name="tweenPath"></param>
        /// <param name="index"></param>
        private void CheckPoint(DOTweenPath tweenPath, int index)
        {
            if (tweenPathEventHandle.ContainsKey(tweenPath))
            {
                currentStep[tweenPath] = index;

                Dictionary<int, PathEventData> e = tweenPathEventHandle[tweenPath].pathEventData;
                if (e.ContainsKey(index))
                {
                    e[index].Action();
                }
            }
        }

        public int GetCurrentStep(DOTweenPath path)
        {
            if (currentStep.ContainsKey(path)) return currentStep[path];
            return 0;
        }
    }
}
