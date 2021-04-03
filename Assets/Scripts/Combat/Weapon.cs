using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ApolionGames.JamOne.Combat{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void CaptureEnemies();
        public abstract void ApplyAttack(Transform transform, Statistics stats);
        public abstract void initialize();
        public abstract void SpecialAttack();
        public abstract void SpecialAttackTwo();
    }
}
