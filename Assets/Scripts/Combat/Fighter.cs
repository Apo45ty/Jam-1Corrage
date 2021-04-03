using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace ApolionGames.JamOne.Combat{

    public class Fighter : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        internal void swing(Statistics stats)
        {
            throw new NotImplementedException();
        }

        internal void Interact(Collision2D col)
        {
            //the player can interact with items depending on the tag.

            switch(col.collider.tag)
            {
                case "interact":
                    col.transform.parent = this.transform;
                    break;
                default:
                    break;
            }
        }

    }
 }
