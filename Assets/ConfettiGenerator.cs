using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiGenerator : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField] GameObject confetti;
        int NUM_CONFETTI = 7;

    void Start()
    {
        PersistantData.Instance.setIndex(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnConfetti()
    {   GameObject confettiInstance;
        int xMin = -12;
        int xMax = 10;
        int yMin = -1;
        int yMax = 7;

        for (int i = 0; i < NUM_CONFETTI; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            confettiInstance = Instantiate(confetti, position, Quaternion.identity);
            Destroy (confettiInstance, 3); 

        }
        
    }
}
