using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PersistantData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int playerScore;
    [SerializeField] int currentLevelIndex;
    [SerializeField] int  difficulty;
    [SerializeField] int volume;
    [SerializeField] int totalBullets;

    public static PersistantData Instance;

    void Start()
    {
        playerScore = 10;
        currentLevelIndex = 0;
        difficulty = 0;
        totalBullets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake(){
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void SetScore(int n){
        playerScore = n;
    }

    public int GetScore(){
        return playerScore;
    }

    public void setIndex(int i){
        currentLevelIndex = i;
    }

    public int getLevelIndex(){
        return currentLevelIndex;
    }

    public int getDifficulty(){
        return difficulty;
    }

    public void SetDifficulty(int n){
        difficulty = n;
    }

    public void setVolume(int n){
        AudioListener.volume = n;
    }

    public int getVolume(){
        return volume;
    }

    public void addBullets(int n){
        totalBullets += n;
    }

    public int getBullets (){
        return totalBullets;
    }
}
