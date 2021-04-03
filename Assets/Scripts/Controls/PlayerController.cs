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
        [SerializeField]
        private KeyCode INTERACTKEYCODE;

        private bool previousKey;

        private float dodgeTimer, tapTimer;

        // Start is called before the first frame update
        void Start()
    {
        figther = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
        stats = GetComponent<Statistics>();
            dodgeTimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(stats!=null){
            if(mover!=null)  {
                if(Input.GetKey(this.UPKEYCODE)){
                        if (Input.GetKeyDown(this.UPKEYCODE))
                                mover.stopVertical();
                            mover.move(new Vector3(0, stats.moveUPDist * Time.deltaTime, 0));
                    }
                    else 
                if(Input.GetKey(this.DOWNKEYCODE)){
                    if(Input.GetKeyDown(this.DOWNKEYCODE))
                        mover.stopVertical();
                    mover.move(new Vector3(0,-stats.moveDownDist*Time.deltaTime,0));
                } else 
                if(Input.GetKey(this.LEFTKEYCODE)){
                    if(Input.GetKeyDown(this.LEFTKEYCODE))
                        mover.stopHorizontal();
                    //Dodge(Time.time, -stats.moveLeftDist - 4.0f );
                    mover.move(new Vector3(-stats.moveLeftDist*Time.deltaTime,0,0));
                } else 
                if(Input.GetKey(this.RIGHTKEYCODE)){
                    if(Input.GetKeyDown(this.RIGHTKEYCODE))
                        mover.stopHorizontal();
                        //Dodge(Time.time, stats.moveRightDist + 4.0f);
                        mover.move(new Vector3(stats.moveRightDist*Time.deltaTime,0,0));
                } else 
                {
                    mover.stop();
                }
                    if (Input.GetKeyUp(RIGHTKEYCODE) || Input.GetKeyUp(LEFTKEYCODE))
                    {
                        previousKey = true;
                    }
            } 
            if(figther!=null)
                {
                    if(Input.GetKey(this.SWINGKEYCODE))
                    {
                        figther.swing(stats);
                    }

                }
        }

    }
        //private void Dodge(float elapsetime, float direction)
        //{
        //    tapTimer = Time.time;
        //    if(dodgeTimer >= (elapsetime - tapTimer) && previousKey)
        //    {
        //        Debug.Log("ok");
        //        mover.move(new Vector3(direction * Time.deltaTime, 0, 0));
        //        previousKey = false;
        //    }
        //}
        
        private void OnCollisionStay2D(Collision2D col)
        {
            if (figther != null)
            {
                if (Input.GetKeyDown(this.INTERACTKEYCODE))
                {
                    figther.Interact(col);
                }
            }
        }
    }

} 
