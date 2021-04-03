using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.AI{

    public class MyAIBehaviourManager : MonoBehaviour
    {
        [SerializeField]
        private float maxAIThinkTime = 0.5f;
        private float elapseTime = 0;
        [SerializeField]
        private List<MyAIBehaviours> behaviours=new List<MyAIBehaviours>();
        private AIStates currentState=AIStates.thinking;

        void Start(){
        }
        public void UpdateAIBehaviours()
        {
            behaviours=new List<MyAIBehaviours>();
            foreach(MyAIBehaviours w in GetComponents<MyAIBehaviours>()){
                if(w==null)
                    continue;
                behaviours.Add(w);
            }
        }
        void Update()
        {
            elapseTime=Mathf.Min(0,elapseTime-Time.deltaTime);
            if(elapseTime>0)
                return;
            AITick();
        }

        private void AITick()
        {
            elapseTime=maxAIThinkTime;
            foreach (MyAIBehaviours behaviour in behaviours)
            {
                if(this.currentState==behaviour.myState()){
                    behaviour.tick(ConfigurationObjectScript.getInstance().getPlayer());
                }
            }
        }
    }
}
