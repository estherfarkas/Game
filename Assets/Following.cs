using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] Transform target; //the enemy's target
    [SerializeField] int moveSpeed = 3; //move speed
    [SerializeField] int rotationSpeed = 3; //speed of turning
    [SerializeField] GameObject controller;


    [SerializeField] Transform myTransform; //current transform data of this enemy


void Awake()
{
    myTransform = transform; //cache transform data for easy access/preformance
}


void Start()
{
     target = GameObject.FindWithTag("Player").transform; //target the player
     if (controller == null){
         controller = GameObject.FindGameObjectWithTag("Controller");
     }
    InvokeRepeating("SpawnEnemyBullets", 3.0f, 1);

}


void Update () {
    //rotate to look at the player
    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);


 //move towards the player
 myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

}

    private void SpawnEnemyBullets(){
         controller.GetComponent<Spawner>().SpawnBullet(transform);

    }

}
