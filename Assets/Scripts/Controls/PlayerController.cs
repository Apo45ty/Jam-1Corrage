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
        [SerializeField]
        private KeyCode UPKEYCODE;

        [SerializeField]
        private KeyCode DOWNKEYCODE;
        [SerializeField]
        private KeyCode LEFTKEYCODE;
        [SerializeField]
        private KeyCode RIGHTKEYCODE;
        private KeyCode SWINGKEYCODE;

        // Start is called before the first frame update
        void Start()
    {
        figther = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
        stats = GetComponent<Statistics>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats!=null){
            if(mover!=null)  {
                if(Input.GetKey(this.UPKEYCODE)){
                    if(Input.GetKeyDown(this.UPKEYCODE))
                        mover.stopVertical();
                    mover.move(new Vector3(0,stats.moveUPDist*Time.deltaTime,0));
                }  else 
                if(Input.GetKey(this.DOWNKEYCODE)){
                    if(Input.GetKeyDown(this.DOWNKEYCODE))
                        mover.stopVertical();
                    mover.move(new Vector3(0,-stats.moveDownDist*Time.deltaTime,0));
                } else 
                if(Input.GetKey(this.LEFTKEYCODE)){
                    if(Input.GetKeyDown(this.LEFTKEYCODE))
                        mover.stopHorizontal();
                    mover.move(new Vector3(-stats.moveLeftDist*Time.deltaTime,0,0));
                } else 
                if(Input.GetKey(this.RIGHTKEYCODE)){
                    if(Input.GetKeyDown(this.RIGHTKEYCODE))
                        mover.stopHorizontal();
                    mover.move(new Vector3(stats.moveRightDist*Time.deltaTime,0,0));
                } else 
                {
                    mover.stop();
                }
            } 
            if(figther!=null){
                if(Input.GetKey(this.SWINGKEYCODE)){
                    figther.swing(stats);
                }
            }
        }
    }
}

} 
