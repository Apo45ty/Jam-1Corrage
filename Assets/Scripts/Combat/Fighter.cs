using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace ApolionGames.JamOne.Combat{

public class Fighter : MonoBehaviour
{
        [SerializeField]
        private List<Weapon> inventoryWeapons;
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
            foreach(Weapon w in GetComponentsInChildren<Weapon>()){
                if(w==null)
                    continue;
                inventoryWeapons.Add(w);
            }
        }

        public bool swing(Statistics stats)
        {
            if(currTimeSinceLastAttack>0)
                return false;
            currTimeSinceLastAttack = stats.timeBetweenAttacks;
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
            currentlyEquippedWeapon.CaptureEnemies();
            currentlyEquippedWeapon.ApplyAttack(transform,stats);
            return true;
        }   

        public void nextWeapon(){
            currentWeaponIndex=(currentWeaponIndex+1)%inventoryWeapons.Count;
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
        }

        internal void swingSpecial(Statistics stats)
        {
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
            currentlyEquippedWeapon.SpecialAttack();
        }

        internal void swingSpecialTwo(Statistics stats)
        {
            currentlyEquippedWeapon = inventoryWeapons[currentWeaponIndex];
            currentlyEquippedWeapon.SpecialAttackTwo();
        }
    }
 }
