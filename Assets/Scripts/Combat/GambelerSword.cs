using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{

    public class GambelerSword : Weapon
    {        
        public float betSize;
        private List<CombatTarget> targets = new List<CombatTarget>();
        [SerializeField] private float AttackSquarSize = 3;
        [SerializeField]
        private float betSizeIncrements=10;

        public override void ApplyAttack(Transform transform, Statistics stats)
        {
            foreach(CombatTarget target in targets){
                Debug.Log(target.name);
            }
        }

        public override void CaptureEnemies()
        {
            targets= new List<CombatTarget>();
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one*AttackSquarSize,0);
            foreach(Collider2D col in colliders){
                CombatTarget combatTarget = col.gameObject.GetComponent<CombatTarget>();
                if (combatTarget!=null)
                {
                    targets.Add(combatTarget);
                }
            }
        }

        public override void initialize()
        {
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
