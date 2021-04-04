using System;
using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.Playables;

namespace ApolionGames.JamOne.CutScenes{

    public class SetConfYesNo : MonoBehaviour
    {
        [SerializeField]private PlayableDirector dirrec;
        public void VotedYes(){
            ConfigurationObjectScript.getInstance().setLatestYesNo("Yes");
            continueTimeline();
        }
        
        public void VotedNo(){
            ConfigurationObjectScript.getInstance().setLatestYesNo("No");
            continueTimeline();
        }

        private void continueTimeline()
        {
            dirrec.playableGraph.GetRootPlayable(0).SetSpeed(1);
            dirrec.Resume();
        }

        public void initializeYesNoVote(){
            dirrec.playableGraph.GetRootPlayable(0).SetSpeed(0);
            dirrec.Pause();
        }
    }
}
