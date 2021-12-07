using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject controller;

    [SerializeField] float vmovement;
    [SerializeField] float hmovement;
    [SerializeField] bool isFacingRight;
    [SerializeField] float speed = 10.0f;
    [SerializeField] bool firePressed;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }

        if (controller == null){
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        hmovement = Input.GetAxis("Horizontal");

        vmovement = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1")){
            firePressed = true;
            PersistantData.Instance.addBullets(1);
        }

    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(vmovement * speed, rigid.velocity.y);
        rigid.velocity = new Vector2(hmovement * speed, rigid.velocity.x);
        
        if (hmovement < 0 && isFacingRight || hmovement > 0 && !isFacingRight){
            Flip();

        }
        
        if (firePressed){
            Vector2 currentPos = transform.position;
            controller.GetComponent<Spawner>().SpawnBullet(transform);
            Debug.Log("Fire!");
            firePressed = false;
        }
    }

    private void Flip() {

        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

   


}
