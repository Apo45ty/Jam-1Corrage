using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Movement;
using UnityEngine;

namespace ApolionGames.JamOne.Controls{
public class PlayerController : MonoBehaviour
{
        private Fighter figther;
        private Mover mover;
        private Statistics stats;
        public static KeyCode pSWINGKEYCODE,pSPECIALSWINGKEYCODE,pSPECIALSWINGKEYCODETWO,pINTERACTKEYCODE;

        [SerializeField]
        private KeyCode UPKEYCODE;

        [SerializeField]
        private KeyCode DOWNKEYCODE;
        [SerializeField]
        private KeyCode LEFTKEYCODE;
        [SerializeField]
        private KeyCode RIGHTKEYCODE;
        [SerializeField]
        private KeyCode SWINGKEYCODE;
        [SerializeField]
        private KeyCode SPECIALSWINGKEYCODE;
        [SerializeField]
        private KeyCode SPECIALSWINGKEYCODETWO;
        [SerializeField]
        private KeyCode INTERACTKEYCODE;
        // Start is called before the first frame update
        void Start()
    {
        figther = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
        stats = GetComponent<Statistics>();
        pSWINGKEYCODE = SWINGKEYCODE;
        pSPECIALSWINGKEYCODE=SPECIALSWINGKEYCODE;
        pSPECIALSWINGKEYCODETWO=SPECIALSWINGKEYCODETWO;
        pINTERACTKEYCODE=INTERACTKEYCODE;
    }
        public List<CombatTarget> CaptureEnemies(float range)
        {
            List<CombatTarget> targets= new List<CombatTarget>();
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one*range,0);
            foreach(Collider2D col in colliders){
                CombatTarget combatTarget = col.gameObject.GetComponent<CombatTarget>();
                if (combatTarget!=null)
                {
                    targets.Add(combatTarget);
                }
            }
            return targets;
        }

    // Update is called once per frame
    void Update()
    {
        if(stats!=null){
            if(mover!=null)  {
                if(Input.GetKey(this.UPKEYCODE)){
                    mover.move(new Vector3(0,stats.moveUPDist*Time.deltaTime,0));
                }  else 
                if(Input.GetKey(this.DOWNKEYCODE)){
                    mover.move(new Vector3(0,-stats.moveDownDist*Time.deltaTime,0));
                } 
                if(Input.GetKey(this.LEFTKEYCODE)){
                    mover.move(new Vector3(-stats.moveLeftDist*Time.deltaTime,0,0));
                } else 
                if(Input.GetKey(this.RIGHTKEYCODE)){
                    mover.move(new Vector3(stats.moveRightDist*Time.deltaTime,0,0));
                } 
            } 
            if(figther!=null&&figther.GetCurrentWeapon()!=null){
                if(Input.GetKey(this.SPECIALSWINGKEYCODE)){
                    figther.swingSpecial(stats);
                }
                if(Input.GetKey(this.SPECIALSWINGKEYCODETWO)){
                    figther.swingSpecialTwo(stats);
                }
                if(Input.GetKey(this.SWINGKEYCODE)){
                    figther.swing(CaptureEnemies(figther.GetCurrentWeapon().GetWeaponRange()),this.GetComponent<CombatTarget>());
                }
            }
        }
        
    }
}

} 
