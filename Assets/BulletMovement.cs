using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float movement = 1f;
    [SerializeField] Vector2 screenPos;

    void Start()
    {
        screenPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        
    }

    // Update is called once per frame
    void Update()
    {   

        
    }

    private void FixedUpdate() {

        if (transform.localRotation.y == 180 || transform.localRotation.y == -180){
            movement = -1f;
        }

        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (transform.position.x >= screenPos.x || transform.position.x <= -9.0){
            Destroy(gameObject);
        }

    }

    

    
}
