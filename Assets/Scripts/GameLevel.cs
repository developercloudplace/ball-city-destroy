using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevel : MonoBehaviour
{
     
     private void Start()
     {
        //  CoinManager.Instance.ShowText();
     }

     public void LoadLevel(string name)
     {
          SceneManager.LoadScene(name);
     }
     public void LoadLevelByName(string name)
     {
          SceneManager.LoadScene(name);
     }


     public void Reload()
     {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }

     public void NextScene()
     {
        //  CoinManager.Instance.IncreaseCoin(10);
        //  CoinManager.Instance.SaveData();
          var currentScene =  SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(currentScene + 1);
          if (currentScene > 11)
          {
               SceneManager.LoadScene("Menu");
          }
     }
     
}
