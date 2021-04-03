using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ApolionGames.JamOne.Combat{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void ApplyAttack(Transform transform, List<CombatTarget> targets,CombatTarget WeaponUser);
        public abstract void SpecialAttack();
        public abstract void SpecialAttackTwo();
        public abstract float GetWeaponRange();
    }
}
