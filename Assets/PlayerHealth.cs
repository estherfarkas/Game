using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int healthScore = 10;
    [SerializeField] int enemyHealthScore = 10;
    [SerializeField] int playerDead = 0;
    [SerializeField] int enemyDead = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text enemyScore;
    [SerializeField] Text sceneText;
    [SerializeField] Text totalBullets;
    [SerializeField] int level;


    const int DEFAULT_HIT = 1;



    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(SceneManager.GetActiveScene().buildIndex + "  is the build index");
        healthScore = PersistantData.Instance.GetScore();
        PersistantData.Instance.setIndex(level);
        DisplayLevel();
        DisplayScore();
        DisplayEnemyScore();
        DisplayBullets();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayBullets();
    }

    public void DecreaseHealth(int hitPoints, GameObject thing){

        if (thing.tag == "Player"){
            healthScore -= hitPoints;
            Debug.Log("Health Remaining: " + healthScore);
            PersistantData.Instance.SetScore(healthScore);
            DisplayScore();
        }
        else {
            enemyHealthScore -= hitPoints;
            Debug.Log("Enemy Health Remaing: " + enemyHealthScore);
            DisplayEnemyScore();
        }

        if (healthScore <= playerDead){
            RestartLevel();
        }
        if (enemyHealthScore <= enemyDead){
            AdvanceLevel();

        }
    }

    public void DecreaseHealth(GameObject thing){
        DecreaseHealth(DEFAULT_HIT, thing);
    }

    public void DisplayScore(){
        scoreText.text = "Health Score: " + healthScore;

    }
    public void DisplayEnemyScore(){
        enemyScore.text = "Enemy Health Score: " + enemyHealthScore;

    }
    public void DisplayBullets(){
        totalBullets.text = "My Total Bullets Shot: " + PersistantData.Instance.getBullets();
    }

    public void DisplayLevel(){
        sceneText.text = "Level: " + level; 
    }

    public void RestartLevel(){
        PersistantData.Instance.SetScore(10);
        SceneManager.LoadScene(level);
    }

    public void AdvanceLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

}
