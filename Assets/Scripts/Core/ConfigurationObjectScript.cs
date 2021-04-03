using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ApolionGames.JamOne.Core{

    public class ConfigurationObjectScript : MonoBehaviour
    {
        private static ConfigurationObjectScript me;
        [SerializeField]
        private PlayerScript playerScript;

        public string Language ="English";

        public string LevelName="Level01";
        public string CutSceneName="Cutscene01";
        public  string diagName="dialog";
        private string latestYesNo;

        void Awake()
        {

            if (me != null && me != this)
            {
                Destroy(this.gameObject);
                return;
            }
            me = this;
            DontDestroyOnLoad(this.gameObject);
        }
        public string getLatestYesNo(){
            return latestYesNo;
        }
        internal void setLatestYesNo(string v)
        {
            this.latestYesNo = v;
        }
        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            print("Scene has loaded");
        }
        public static ConfigurationObjectScript getInstance(){
           return me;
        }
        public PlayerScript getPlayer(){
            return playerScript;
        }
        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            playerScript = FindObjectOfType<PlayerScript>();
        }
    }
}
