using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace ApolionGames.JamOne.Combat{

public class Fighter : MonoBehaviour
{
        [SerializeField]
        private List<Weapon> inventoryWeapons=new List<Weapon>();
        private Statistics stats;
        private int currentWeaponIndex = 0;
        private Weapon currentlyEquippedWeapon;
        private float currTimeSinceLastAttack;

        // Start is called before the first frame update
        void Start()
        {
            stats = GetComponent<Statistics>();
            UpdateWeaponInventory();
            
        }
        void Update(){
            currTimeSinceLastAttack=Mathf.Max(0,currTimeSinceLastAttack-Time.deltaTime);
            
        }
        public void UpdateWeaponInventory()
        {
            inventoryWeapons=new List<Weapon>();
            foreach(Weapon w in GetComponentsInChildren<Weapon>()){
                if(w==null)
                    continue;
                inventoryWeapons.Add(w);
            }
            if(inventoryWeapons.Count>0){
                currentWeaponIndex=(currentWeaponIndex+1)%inventoryWeapons.Count;
                EquipCurrrentWeapon();
            }
        }

        public bool swing(List<CombatTarget> targets,CombatTarget WeaponUser)
        {
            if (currTimeSinceLastAttack > 0)
                return false;
            currTimeSinceLastAttack = stats.timeBetweenAttacks;
            EquipCurrrentWeapon();
            currentlyEquippedWeapon.ApplyAttack(transform, targets, WeaponUser);
            return true;
        }

        private void EquipCurrrentWeapon()
        {
            if(currentlyEquippedWeapon!=null)
                currentlyEquippedWeapon.TearDownUI();
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
            currentlyEquippedWeapon.SetUPUI();
        }

        public void nextWeapon(){
            currentWeaponIndex=(currentWeaponIndex+1)%inventoryWeapons.Count;
            EquipCurrrentWeapon();
        }

        public void swingSpecial(Statistics stats)
        {
            EquipCurrrentWeapon();
            currentlyEquippedWeapon.SpecialAttack();
        }

        public void swingSpecialTwo(Statistics stats)
        {
            EquipCurrrentWeapon();
            currentlyEquippedWeapon.SpecialAttackTwo();
        }
        public Weapon GetCurrentWeapon(){
            return currentlyEquippedWeapon;
        }
    }
 }
