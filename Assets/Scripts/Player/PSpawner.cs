using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject spawner;

    
   private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 
        

        if (Input.GetKeyDown("3"))
        {
            anim.SetTrigger("Spw");
        
           Instantiate(platform,spawner.transform.position,Quaternion.identity); 
           

        }

        
    }
}
