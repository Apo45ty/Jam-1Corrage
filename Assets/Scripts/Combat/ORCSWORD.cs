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
                
                
                Statistics statistics = WeaponUser.GetComponent<Statistics>();
                float damage = Mathf.Min((float)statistics.Strength*2,(float)int.MaxValue-1);
            

                target.GetComponent<Health>().doDamage(damage);
                target.AfterAttackCallback();
            }
        }

        public override float GetWeaponRange()
        {
            return 1;
        }

        public override void SetUPUI()
        {
            return;
        }

        public override void SpecialAttack()
        {
            throw new System.NotImplementedException();
        }

        public override void SpecialAttackTwo()
        {
            throw new System.NotImplementedException();
        }

        public override void TearDownUI()
        {
           return;
        }
    }
}
