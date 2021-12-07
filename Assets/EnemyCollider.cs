using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        if (audio == null){
            audio = GetComponent<AudioSource>();

        }
        if (controller == null){
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collisions){
        if (collisions.tag != gameObject.tag){

            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            controller.GetComponent<Spawner>().SpawnExplosion(gameObject.transform);
            Debug.Log("Collided!");

            if (PersistantData.Instance.getDifficulty() == 0){
            controller.GetComponent<PlayerHealth>().DecreaseHealth(gameObject);
            }
            else {
                controller.GetComponent<PlayerHealth>().DecreaseHealth(2, gameObject);

            }

        }
            

        
    }
}
