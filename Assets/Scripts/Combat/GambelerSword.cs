using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{

    public class GambelerSword : Weapon
    {        
        
        [SerializeField] private float AttackSquarSize = 3;
        public float betSize;
        [SerializeField]
        private float betSizeIncrements=10;
        private SlotMachinePointAggegator slotMachinePointAggegator;
        private WeaponUI weaponUI;
        public  float pointsScore;
        private int weaponDamage=10;
        private bool isAttack;
        private float damage;
        void Start(){
            slotMachinePointAggegator = GetComponentInChildren<SlotMachinePointAggegator>();
            weaponUI = GetComponentInChildren<WeaponUI>();
            weaponUI.gameObject.SetActive(false);
        }

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
            isAttack = slotMachinePointAggegator.total>=pointsScore;
            if(isAttack){  
                damage = (weaponDamage*WeaponUser.GetComponent<Statistics>().Strength+slotMachinePointAggegator.total)/100f;
                float randomDam=Random.Range(0,100/(WeaponUser.GetComponent<Health>().currentHealth)*(100/betSize)*100)/4;
                // Debug.Log("Attacked "+damage+" random"+randomDam+" all together"+(damage+randomDam)+" max "+(100/(WeaponUser.GetComponent<Health>().currentHealth)*(100/betSize)*100));
                damage+=randomDam;
                foreach(CombatTarget target in targets){
                    if(target==WeaponUser)
                        continue;
                    target.GetComponent<Health>().doDamage(damage);
                    target.AfterAttackCallback();
                }
            } else 
            {
                Debug.Log("Not Attacked");
                Health health = WeaponUser.GetComponent<Health>();
                damage = health.currentHealth*betSize/100;
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

        public override void SetUPUI()
        {
            weaponUI.gameObject.SetActive(true);
        }

        public override void TearDownUI()
        {
            weaponUI.gameObject.SetActive(false);
        }
    }
}
