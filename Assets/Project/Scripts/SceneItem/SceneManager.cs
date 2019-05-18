using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRFrame
{
    public class SceneManager : MonoSingleton<SceneManager>
    {
        public SpereMoveCtrl spereCtrl;
        public BowCtrl bowCtrl;

        private void Start()
        {
            spereCtrl.gameObject.SetActive(false);
            bowCtrl.gameObject.SetActive(false);
        }

        public void InitAll()
        {
            spereCtrl.Init();
            bowCtrl.Init();
        }
        public void ResetAll()
        {
            spereCtrl.Quit();
            bowCtrl.Quit();
        }

        /*
         * 存储位置信息  主动
         * 恢复位置信息  主动
         * 启动游戏  主动
         * 关闭游戏  主动
         * 
         * 游戏初始化  存储数据
         * 游戏退出  位置恢复
         */
    }
}
