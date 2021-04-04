using System;
using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
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

        public void DoGameOver()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public  string diagName="dialog";
        private string latestYesNo;
        private List<Weapon> inventory;

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
            if(inventory!=null){
                playerScript.GetComponent<Fighter>().LoadWeaponInventory(inventory);
                foreach(Weapon w in inventory){
                    w.transform.parent=playerScript.transform;
                    w.transform.localPosition = new Vector2(-0.13f,-0.2f);
                    w.transform.localScale = Vector3.one;
                }
            }
        }
        public void LevelCompleated(){
            storeLevelVars();
            loadNextLevel();
        }

        private void loadNextLevel()
        {
            if(SceneManager.GetActiveScene().name.Equals("Tutorial")){
                 LevelName = "Level01";
                 SceneManager.LoadScene("Level01");
            } else if(SceneManager.GetActiveScene().name.Equals("Level01")){
                LevelName = "Level02";
                 SceneManager.LoadScene("Level02");
            } else if(SceneManager.GetActiveScene().name.Equals("Level02")){
                LevelName = "Level03";
                 SceneManager.LoadScene("Level03");
            } 
            return;
        }

        private void storeLevelVars()
        {
            SaveInventoryForNextScene(playerScript.GetComponent<Fighter>().getInventoryWeapons()); 
            return;
        }

        public void SaveInventoryForNextScene(List<Weapon> inventoryWeapons)
        {
            if(!SceneManager.GetActiveScene().name.Equals("Tutorial")){
                foreach(Weapon w in inventoryWeapons){
                    w.transform.parent=transform;
                    DontDestroyOnLoad(w.gameObject);
                }
                this.inventory=inventoryWeapons;
            }
        }
    }
}
