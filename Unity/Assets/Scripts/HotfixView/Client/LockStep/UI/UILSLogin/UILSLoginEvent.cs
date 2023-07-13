﻿using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.UILSLogin)]
    public class UILSLoginEvent: AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            // ResourcesComponent resourcesComponent = uiComponent.Root().GetComponent<ResourcesComponent>();
            // await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(UIType.UILSLogin));
            GameObject bundleGameObject = ResComponent.Instance.LoadAsset<GameObject>($"UILSLogin");
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.UILSLogin, gameObject);
            ui.AddComponent<UILSLoginComponent>();
            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}