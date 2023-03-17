using System.Collections;
using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class RoomManagerComponent : Entity, IAwake, IDestroy
    {
        public int RoomIdNum { get; set; }

        /// <summary>
        /// �����ĳ�˫���ֵ䣬һ���淨һ���ֵ�洢���䣬��ǰ����ֻ����һ���淨
        /// </summary>
        public Dictionary<long, Room> Rooms = new Dictionary<long, Room>();

    }
}