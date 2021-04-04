using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{

public class Health : MonoBehaviour
{
    [SerializeField]
    public float currentHealth = 100;
    [SerializeField]
    public float maxHealth = 100;

        internal void doDamage(float v)
        {
            this.currentHealth=Mathf.Max(0,this.currentHealth-v);

        }

        internal bool IsDead()
        {
            return currentHealth==0;
        }

        internal void increaseHealth(int v)
        {
            this.currentHealth=Mathf.Min(maxHealth,this.currentHealth+v);
        }
    }
}
