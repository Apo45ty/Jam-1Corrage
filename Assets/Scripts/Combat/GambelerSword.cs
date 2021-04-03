using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{

    public class GambelerSword : Weapon
    {        
        void Start(){
            slotMachinePointAggegator = GetComponentInChildren<SlotMachinePointAggegator>();
        }
        [SerializeField] private float AttackSquarSize = 3;
        public float betSize;
        [SerializeField]
        private float betSizeIncrements=10;
        private SlotMachinePointAggegator slotMachinePointAggegator;
        public  float pointsScore;

        public override void ApplyAttack(Transform transform,List<CombatTarget> targets,CombatTarget WeaponUser)
        {
            if(targets==null||targets.Count<=0)
                return;
            pointsScore = 0;
            foreach(CombatTarget target in targets){
                if(target==WeaponUser)
                    continue;
                Statistics targetStats = target.GetComponent<Statistics>();
                pointsScore+=targetStats.computePointsToAttack();
            }
            bool isAttack = slotMachinePointAggegator.total>=pointsScore;
            if(isAttack){
                Debug.Log("Attacked");
                foreach(CombatTarget target in targets){
                    if(target==WeaponUser)
                        continue;
                    float damage = 10;
                    target.GetComponent<Health>().doDamage(damage);
                    target.AfterAttackCallback();
                }
            } else 
            {
                Debug.Log("Not Attacked");
                Health health = WeaponUser.GetComponent<Health>();
                float damage = health.currentHealth*betSize/100;
                health.doDamage(damage);
            }
        } 

        public override float GetWeaponRange()
        {
            return AttackSquarSize;
        }

        public override void SpecialAttack()
        {
             betSize=Mathf.Min(100,betSize+betSizeIncrements*Time.deltaTime);
        }

        public override void SpecialAttackTwo()
        {
            betSize=Mathf.Max(0,betSize-betSizeIncrements*Time.deltaTime);
        }
    }
}
