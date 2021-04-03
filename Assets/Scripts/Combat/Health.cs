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
    }
}
