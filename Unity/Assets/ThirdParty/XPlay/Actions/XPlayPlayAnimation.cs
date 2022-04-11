/****************************************************
    Author:		Flamesky
    Mail:		flamesky@live.com
    Date:		2022/3/3 15:45:9
    Function:	Nothing
*****************************************************/
using UnityEngine;
using Animancer;

namespace XPlay.Runtime
{
    public class XPlayPlayAnimation : XPlayAction<XPlayPlayAnimationData>
    {
        public override void OnEnter(uint currentFrame)
        {
            base.OnEnter(currentFrame);
            Debug.LogError($"���Ŷ�����{this.BindingData.animName} ֡����{currentFrame}");
            //�˴����ò��Ŷ�������ǰֱ����Animacer�����Ŷ���
            string path = $"Assets/{PathDefine.TestAnimationPath}{this.BindingData.animName}.anim";
#if UNITY_EDITOR
            AnimationClip clip = XPlayUtility.LoadAnimationClip(path);
            Debug.Log($"load anim , path {path}, clip: {clip?.name}");
            AnimancerComponent anim = GameObject.Find("Jinx")?.GetComponent<AnimancerComponent>();
            anim?.Stop(clip);
            var state = anim?.Play(clip, 0, FadeMode.NormalizedSpeed);
            if (state != null)
            {
                state.Speed = BindingData.speed;
                state.NormalizedTime = BindingData.normalizedTime;
                state.NormalizedEndTime = BindingData.normalizedEndTime <= BindingData.normalizedTime ? 1 : BindingData.normalizedEndTime;
                // state.Events.endEvent = OnPlayAnimEnd;
            }
#endif
        }

        /*private void OnPlayAnimEnd()
        {

        }*/

        public override void OnUpdate(uint currentFrame, uint previousFrame)
        {
            
        }

        public override void OnExit()
        {
            base.OnExit();

        }
    }
}