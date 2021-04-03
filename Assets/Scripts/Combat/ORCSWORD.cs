using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{

    public class ORCSWORD : Weapon
    {
        public override void ApplyAttack(Transform transform, List<CombatTarget> targets, CombatTarget WeaponUser)
        {
            // Debug.Log("Attacked");
            foreach(CombatTarget target in targets){
                if(target==WeaponUser)
                    continue;
                float damage = 10;
                target.GetComponent<Health>().doDamage(damage);
                target.AfterAttackCallback();
            }
        }

        public override float GetWeaponRange()
        {
            return 1;
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
