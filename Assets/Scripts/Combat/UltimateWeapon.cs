using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{

    public class UltimateWeapon : Weapon
    {
        public override void ApplyAttack(Transform transform, List<CombatTarget> targets, CombatTarget WeaponUser)
        {
            foreach(CombatTarget target in targets){
                if(target==WeaponUser)
                    continue;
                float damage = 100;
                target.GetComponent<Health>().doDamage(damage);
                target.AfterAttackCallback();
            }
        }

        public override float GetWeaponRange()
        {
            return 3;
        }

        public override void SpecialAttack()
        {
            throw new System.NotImplementedException();
        }

        public override void SpecialAttackTwo()
        {
            throw new System.NotImplementedException();
        }

      
    }
}
