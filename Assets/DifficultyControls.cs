using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Dropdown difficulty;
    void Start()
    {
        difficulty.value = PlayerPrefs.GetInt("Difficulty", 1);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficulty(){
        PlayerPrefs.SetInt("Difficulty", difficulty.value);
        PersistantData.Instance.SetDifficulty(difficulty.value);

    }
}
