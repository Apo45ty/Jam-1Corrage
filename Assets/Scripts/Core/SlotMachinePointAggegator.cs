using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Controls;
using UnityEngine;
namespace ApolionGames.JamOne.Core{

    public class SlotMachinePointAggegator : MonoBehaviour
    {
        private RandomSprite[] slotitems;
        public int total;

        // Start is called before the first frame update
        void Start()
        {
            slotitems = GetComponentsInChildren<RandomSprite>();

        }

        // Update is called once per frame
        void Update()
        {
            if(slotitems!=null&&slotitems.Length>0&& slotitems[0].getIsRunning()&&Input.GetKeyDown(PlayerController.pSWINGKEYCODE)){
                this.total=0;
                foreach(RandomSprite rSpr in slotitems){
                    this.total += rSpr.getCurrentSlotMachineItem().score;
                }
            }
        }
    }
}
