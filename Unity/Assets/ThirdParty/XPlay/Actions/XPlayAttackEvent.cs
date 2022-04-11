/****************************************************
    Author:		Flamesky
    Mail:		flamesky@live.com
    Date:		2022/3/3 15:45:9
    Function:	Nothing
*****************************************************/
using UnityEngine;

namespace XPlay.Runtime
{
    public class XPlayAttackEvent : XPlayAction<XPlayAttackEventData>
    {
        public override void OnEnter(uint currentFrame)
        {
            base.OnEnter(currentFrame);
            Debug.LogError($"����ս���¼���{this.BindingData.attackInfo} ֡����{currentFrame}");
        }
    }
}