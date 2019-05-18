using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace VRFrame
{
    /// <summary>
    /// 控制动画播放和按钮事件处理
    /// </summary>
    public class PanelCtrl : MonoBehaviour
    {
        /// <summary>
        /// 动画
        /// </summary>
        public RawImage bgAnim;
        [Range(1, 60)]
        public float speed;
        public ChoiceType choiceType;
        public Transform title;

        private Texture2D[] bgArr;
        private int bgIndex;
        private bool isPlay = false;
        private float timer = 0;

        private void Start()
        {
            title = transform.Find("Title");
            GetBgAnim();
        }

        private void Update()
        {
            if (isPlay)
            {
                timer += Time.deltaTime;
                if (timer >= 1 - (speed / 60))
                {
                    timer = 0;
                    bgAnim.texture = bgArr[++bgIndex % bgArr.Length];
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            title.DOLocalMoveY(-150f, 0.5f);
            transform.DOScale(1.1f, 0.5f);
        }
        private void OnTriggerExit(Collider other)
        {
            title.DOLocalMoveY(-80, 0.5f);
            transform.DOScale(1f, 0.5f);
        }
        private void OnTriggerStay(Collider other)
        {
            if (InputFactory.Instance.Create().GetButtonDown(ButtonType.Trigger, HandType.Any))
            {
                MsgBase msg = new MsgBase((ushort)UIEventMsg.ChoiceUI);
                EventManager.Instance.BroadcastMsg(msg);
            }
        }

        #region  GetBgAnim 获取背景 
        private void GetBgAnim()
        {
            string path = string.Empty;
            switch (choiceType)
            {
                case ChoiceType.Panel1:
                    path = SourcePath.UIAnimImagePath.Panel1;
                    break;
                case ChoiceType.Panel2:
                    path = SourcePath.UIAnimImagePath.Panel2;
                    break;
            }
            if (!string.IsNullOrEmpty(path))
            {
                AssetSource asset = ResourceLoader.Instance.LoadAsset(SourceType.SequenceFrame, path);
                if (asset == null)
                {
                    Debug.LogError("序列帧加载失败！");
                    return;
                }

                bgArr = asset.frameImage;
                isPlay = true;
            }
        }
        #endregion
    }
}
