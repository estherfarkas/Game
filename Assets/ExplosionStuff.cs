using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionStuff : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;
    [SerializeField] float delay = .03f;
    void Start()
    {
        
        if (anim == null){
            anim = GetComponent<Animator>();
            anim.SetBool("PlanHit", true);
        }
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
