using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum CreatureState
    {
        Idle,
        Moving,
        Skill,
        Dead,
        Jump
    }

    public enum MoveDir
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    public enum Scene
    {
        Unknown,
        Lobby,
        Game,
        End
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }
    public struct QuestInfo
    {
        public string Qname;
        public string Qtext;
        public string Tag;
        public int Targetnum;
        public int currentnum;
        public bool completed;
        public int reward;
    }
}
