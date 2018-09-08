//////////////////////////////////////////
//	Create by Leonard Marineau-Quintal  //
//		www.leoquintgames.com			//
//////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hit
{
    public interface IHittable
    {
        void OnHit(HitData data);
    }

    public struct HitData
    {
        Hitter hitter;
        HitType type;
        float strength;
    }

    public enum Hitter
    {
        None,
        Player,
        AlliedCharacter,
        EnnemyCharacter,
        NeutralCharacter,
        Environment
    }

    public enum HitType
    {
        Normal, 
        Blunt,
        Piercing,
        Explosif,
        Fire
    }
}