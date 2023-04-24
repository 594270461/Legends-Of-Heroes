using System.Collections;
using System.Collections.Generic;
using ET.EventType;

namespace ET
{
    public static class BattleHelper 
    {
        /// <summary>
        /// ���н���
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="hitType"></param>
        /// <param name="bullet"></param>
        public static void HitSettle(Unit from, Unit to, EHitFromType hitType = EHitFromType.Skill_Normal, Unit bullet = null)
        {
            switch (hitType)
            {
                case EHitFromType.Skill_Normal:
                {
                    int dmg = from.GetComponent<NumericComponent>().GetAsInt(NumericType.Attack);
                    int finalHp = to.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) - dmg;
                    if (finalHp <= 0)
                    {
                        //�������¼�֪ͨ
                    }
                    Log.Info($"hit settle, from:{from?.Id}, to:{to?.Id}, value:{dmg}");
                    //���н��������¼�֪ͨ������һϵ���߼�/���֣�ƮѪ��Ѫ�����������������¼��ȣ���ǰ��������¸��´�С��
                    EventSystem.Instance.Publish(from.DomainScene(), new HitResult(){hitResultType = EHitResultType.Damage, value = dmg});
                    break;
                }
                case EHitFromType.Skill_Bullet:
                {
                    int dmg = from.GetComponent<NumericComponent>().GetAsInt(NumericType.Attack);
                    int finalHp = to.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp) - dmg;
                    if (finalHp <= 0)
                    {
                        //�������¼�֪ͨ
                    }
                    Log.Info($"hit settle, from:{from?.Id}, to:{to?.Id}, value:{dmg}");
                    EventSystem.Instance.Publish(from.DomainScene(), new HitResult(){hitResultType = EHitResultType.Damage, value = dmg});
                    break;
                }
                    
            }
        }
    }
}
