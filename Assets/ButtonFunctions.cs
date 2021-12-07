using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update

     void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToInstructions(){
        SceneManager.LoadScene("Instructions");
    }

    public void PlayGame(){
        if (PersistantData.Instance.getLevelIndex() > 0){
        SceneManager.LoadScene(PersistantData.Instance.getLevelIndex());
        }
        else SceneManager.LoadScene("Scene 1.5");
        Time.timeScale = 1;

    }

    public void MainMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void Settings(){
        SceneManager.LoadScene("Settings");
    }

    public void HighScores(){
        SceneManager.LoadScene("High Scores");
    }
    

}
