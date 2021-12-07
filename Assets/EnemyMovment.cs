using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 1f;
    [SerializeField] float movement = -1f;
    [SerializeField] Vector2 screenPos;
    [SerializeField] GameObject controller;
    [SerializeField] bool following = false;
    [SerializeField] GameObject Player;

 

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }

        if (controller == null){
            controller = GameObject.FindGameObjectWithTag("GameController");

        }
        Player = GameObject.Find("Player");
        screenPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        InvokeRepeating("SpawnEnemyBullets", 3.0f, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        if (following == false){
        
        
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (transform.position.x >= screenPos.x || transform.position.x <= -9.0){
            Flip();
        }
        }
        else {

            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed*Time.deltaTime);
        }

        
    }

    private void Flip() {

        transform.Rotate(0, 180, 0);
        movement = movement * -1f;
        transform.Translate(movement * 3, 0f, 0f, Camera.main.transform);

    }
    
    private void SpawnEnemyBullets(){
         controller.GetComponent<Spawner>().SpawnBullet(transform);

    }




}
