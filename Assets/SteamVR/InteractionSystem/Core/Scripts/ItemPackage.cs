//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: A package of items that can interact with the hands and be returned
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class ItemPackage : MonoBehaviour
	{
		public enum ItemPackageType { Unrestricted, OneHanded, TwoHanded }

		public new string name;
		public ItemPackageType packageType = ItemPackageType.Unrestricted;
        /// <summary>
        /// 跟随控制器的弓箭
        /// </summary>
		public GameObject itemPrefab; // object to be spawned on tracked controller
        /// <summary>
        /// 握持弓箭的手
        /// </summary>
		public GameObject otherHandItemPrefab; // object to be spawned in Other Hand
        /// <summary>
        /// 用于预览的弓箭
        /// </summary>
		public GameObject previewPrefab; // used to preview inputObject
        /// <summary>
        /// 虚拟弓箭
        /// </summary>
		public GameObject fadedPreviewPrefab; // used to preview insubstantial inputObject
	}
}
