using System.Collections;
using System.Collections.Generic;
using System.IO;
using ApolionGames.JamOne.Controls;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace ApolionGames.JamOne.CutScenes{
    public class MySignalManager : MonoBehaviour
    {
        [SerializeField]
        private Text MyTextBox;
        private string[] lines;
        private int currentline = 0;

        public void initializeFileTextBox(){
            currentline = 0;
            GetComponent<PlayableDirector>().Pause();
            ConfigurationObjectScript conf = ConfigurationObjectScript.getInstance();
            Debug.Log(Application.dataPath + "/Resources/" +conf.Language+"/"+conf.LevelName+"/"+conf.CutSceneName+"/"+ "dialog.diag" );
            var sr = new StreamReader(Application.dataPath + "/Resources/" +conf.Language+"/"+conf.LevelName+"/"+conf.CutSceneName+"/"+ "dialog.diag");
            var fileContents = sr.ReadToEnd();
            sr.Close();
 
            lines = fileContents.Split("\n"[0]);
            MyTextBox.text = lines[currentline++];
        }
        void Update(){
            if(Input.GetKeyDown(PlayerController.pINTERACTKEYCODE)){
                if(currentline<lines.Length){
                    Debug.Log(lines[currentline]);
                    MyTextBox.text = lines[currentline++];
                } else 
                    GetComponent<PlayableDirector>().Resume();
            }
        }
    }
}
