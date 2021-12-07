using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D bulletPrefab;
    [SerializeField] GameObject explosion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void SpawnBullet(Transform plane)
    {   Rigidbody2D bulletInstance;
        Vector2 position = plane.transform.position;
        bulletInstance = Instantiate(bulletPrefab, position, plane.rotation) as Rigidbody2D;
        bulletInstance.tag = plane.tag;
    }

    public void SpawnExplosion(Transform collider){
        GameObject explosionInstance;
        Vector2 position = collider.transform.position;
        explosionInstance = Instantiate(explosion, position, collider.rotation) as GameObject;
    }
}
