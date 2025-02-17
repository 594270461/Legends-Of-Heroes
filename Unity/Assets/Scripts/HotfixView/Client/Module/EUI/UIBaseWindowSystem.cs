﻿using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIBaseWindow))]
    [FriendOf(typeof(UIBaseWindow))]
    public  static class UIBaseWindowSystem  
    {
        public static void Awake(this UIBaseWindow self)
        {
            self.WindowData = self.AddChild<WindowCoreData>();
            self.IsInStackQueue = false;
            
        }
        public static void Destroy(this UIBaseWindow self)
        {
            self.WindowData?.Dispose();
            self.WindowID = WindowID.WindowID_Invaild;
            self.IsInStackQueue = false;
            if (self.UIPrefabGameObject != null)
            {
                UnityEngine.Object.Destroy(self.UIPrefabGameObject);
                self.UIPrefabGameObject = null;
            }
        }
        public static void SetRoot(this UIBaseWindow self, Transform rootTransform)
        {
            if(self.uiTransform == null)
            {
                Log.Error($"uibaseWindows {self.WindowID} uiTransform is null!!!");
                return;
            }
            if(rootTransform == null)
            {
                Log.Error($"uibaseWindows {self.WindowID} rootTransform is null!!!");
                return;
            }
            self.uiTransform.SetParent(rootTransform, false);
            self.uiTransform.transform.localScale = Vector3.one;
            self.uiTransform.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        }
    }
}
