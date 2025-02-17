﻿using System;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIEventComponent))]
    [FriendOf(typeof(UIEventComponent))]
    public static class UIEventComponentSystem
    {
        public static void Destroy(this UIEventComponent self)
        {
            self.UIEventHandlers.Clear();
            self.IsClicked = false;
            UIEventComponent.Instance = null;
        }
        public static void Awake(this UIEventComponent self)
        {
            UIEventComponent.Instance = self;
            self.UIEventHandlers.Clear();
            foreach (Type v in EventSystem.Instance.GetTypes(typeof (AUIEventAttribute)))
            {
                AUIEventAttribute attr = v.GetCustomAttributes(typeof (AUIEventAttribute), false)[0] as AUIEventAttribute;
                self.UIEventHandlers.Add(attr.WindowID, Activator.CreateInstance(v) as IAUIEventHandler);
            }
        }
        
        public static IAUIEventHandler GetUIEventHandler(this UIEventComponent self,WindowID windowID)
        {
            if (self.UIEventHandlers.TryGetValue(windowID, out IAUIEventHandler handler))
            {
                return handler;
            }
            Log.Error($"windowId : {windowID} is not have any uiEvent");
            return null;
        }

        public static void SetUIClicked(this UIEventComponent self, bool isClicked)
        {
            self.IsClicked = isClicked;
        }
        
    }
}