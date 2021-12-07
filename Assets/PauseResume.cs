using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseResume : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text buttonText;
    [SerializeField] bool isPaused;

    void Start()
    {
        
          Time.timeScale = 1.0f;
          buttonText.text = "Pause";
          isPaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause(){
        if (isPaused == true){
            Debug.Log("Resume Mode Initiated");
            Time.timeScale = 1.0f;
            buttonText.text = "Pause";
            isPaused = false;
            }
        else {
        Debug.Log("PauseMode initiated");
        Time.timeScale = 0.0f;
        buttonText.text = "Play";
        isPaused = true;
        }


    }
    

    public void Resume()
    {    Debug.Log("Resume Mode Initiated");
        Time.timeScale = 1.0f;
        buttonText.text = "Pause";

        

    }

    public void HighScores()
    {
        SceneManager.LoadScene("highScores");
    }

    public void MainMenu()
    {   PersistantData.Instance.setIndex(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }

}

