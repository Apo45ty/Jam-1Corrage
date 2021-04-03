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
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
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
        }

        public bool swing(List<CombatTarget> targets,CombatTarget WeaponUser)
        {
            if(currTimeSinceLastAttack>0)
                return false;
            currTimeSinceLastAttack = stats.timeBetweenAttacks;
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
            currentlyEquippedWeapon.ApplyAttack(transform,targets,WeaponUser);
            return true;
        }   

        public void nextWeapon(){
            currentWeaponIndex=(currentWeaponIndex+1)%inventoryWeapons.Count;
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
        }

        public void swingSpecial(Statistics stats)
        {
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
            currentlyEquippedWeapon.SpecialAttack();
        }

        public void swingSpecialTwo(Statistics stats)
        {
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
            currentlyEquippedWeapon.SpecialAttackTwo();
        }
        public Weapon GetCurrentWeapon(){
            return currentlyEquippedWeapon;
        }
    }
 }
