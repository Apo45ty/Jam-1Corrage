using System;
using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Core;
using UnityEngine;

public class BostIfUltimateWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        PlayerScript playerScript = ConfigurationObjectScript.getInstance().getPlayer();
        if (playerScript)
        {
            Fighter fighter = playerScript.GetComponent<Fighter>();
            foreach(Weapon w in fighter.getInventoryWeapons()){
                if (w is UltimateWeapon){
                    boostBoss();
                    break;
                }
            }
        }
        Destroy(this);
    }

    private void boostBoss()
    {
        GetComponent<Statistics>().Strength = Int32.MaxValue;
        GetComponent<Health>().currentHealth = 300000f;
        GetComponent<Health>().maxHealth = 300000f;
        
    }
}
