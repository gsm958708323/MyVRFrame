using UnityEngine;
using System.Collections;

namespace VRFrame
{
    public enum ChoiceType
    {
        Panel1,
        Panel2
    }
    public class SourcePath 
    {
        public class UIAnimImagePath
        {       
            private const string root = "UI/Texture";
            public const string Panel1 = root + "/Middle/bg";
            public const string Panel2 = root + "/Newbie/bg";
        }
    }
}
