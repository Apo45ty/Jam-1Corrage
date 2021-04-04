using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApolionGames.JamOne.Controls;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace ApolionGames.JamOne.CutScenes{

    public class MyCutSceneManager : MonoBehaviour
    {
    [SerializeField]
            private Text MyTextBox;
            private string[] lines;
            private int currentline = 0;
            private static int diagCount = 1;
            [SerializeField]
            private string cutsceneName="";
            [SerializeField]
            private int MaxNumberOfDialogs=2;
            private bool isInCutScene;

            public void initializeFileTextBox(){
                GetComponent<PlayableDirector>().playableGraph.GetRootPlayable(0).SetSpeed(0);
                GetComponent<PlayableDirector>().Pause();
                currentline = 0;
                ConfigurationObjectScript conf = ConfigurationObjectScript.getInstance();
                                Debug.Log("Resources/"+conf.Language+"/"+conf.LevelName+"/"+cutsceneName+"/"+conf.diagName+diagCount.ToString("00")+".txt");
                TextAsset sr = Resources.Load( conf.Language+"/"+conf.LevelName+"/"+cutsceneName+"/"+conf.diagName+diagCount.ToString("00"))as TextAsset;
            
                // Debug.Log(Encoding.ASCII.GetString(sr.bytes));
                lines = Encoding.ASCII.GetString(sr.bytes).Split("\n"[0]);
                MyTextBox.text = lines[currentline++];
                isInCutScene= true;
            }
            void Update(){
                if(isInCutScene&&Input.GetKeyDown(PlayerController.pINTERACTKEYCODE)){
                    if(currentline<lines.Length){
                        Debug.Log(lines[currentline]);
                        MyTextBox.text = lines[currentline++];
                    } else {
                        isInCutScene=false;
                        diagCount++;
                        GetComponent<PlayableDirector>().playableGraph.GetRootPlayable(0).SetSpeed(1);
                        GetComponent<PlayableDirector>().Resume();
                        if(diagCount>MaxNumberOfDialogs){
                            diagCount = 1;
                            Destroy(this);
                        }
                    }
                }
            }
            
    }
}
