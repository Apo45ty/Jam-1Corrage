using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{

public class Statistics : MonoBehaviour
{
        public float moveUPDist=5;
        public float moveDownDist=5;
        public float moveLeftDist=5;
        public float moveRightDist=5;
        public float timeBetweenAttacks=3;
        //Points needed to trigger an attack by gambelers sword
        public float PointsToAttack =  500;

        public int Strength = 5;

        internal float computePointsToAttack()
        {
            return PointsToAttack;
        }
    }
}
