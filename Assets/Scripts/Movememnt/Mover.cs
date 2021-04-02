using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApolionGames.JamOne.Movement{

public class Mover : MonoBehaviour
{
        private Rigidbody2D rb;

        // Start is called before the first frame update
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void move(Vector3 vector3)
        {
            if(rb==null)
            return;
            rb.AddForce(vector3);
        }
    }
}
