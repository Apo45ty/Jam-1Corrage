using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ApolionGames.JamOne.Core{

    public class SlotMachineItem : MonoBehaviour
    {
        [SerializeField]
        public Sprite image;
        void Start(){
            image=GetComponent<SpriteRenderer>().sprite;
        }

        [SerializeField]
        public int score;
        void Update(){
            if(image==null)
                image=GetComponent<SpriteRenderer>().sprite;
        }
    }
}
