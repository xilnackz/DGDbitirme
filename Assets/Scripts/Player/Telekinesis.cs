using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{

    public bool hasItemInSlot;
    public float distance;
    public GameObject cam;
    private Animator anim;
    // Start is called before the first frame update
    void Start() 
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); 

        float distance= 500f;

        bool Tel = anim.GetBool("Tel");

        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
          
            if (hit.transform.CompareTag("Pickupable") && Input.GetKey("1") && !hasItemInSlot)
            {
                anim.SetBool("Tel", true);
                hasItemInSlot = true;
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.GetComponent<Rigidbody>().useGravity =false;
                hit.transform.parent = cam.transform;
            }
            
            if (Input.GetKey("2") && hasItemInSlot)
            {
                anim.SetBool("Tel", false);
                hasItemInSlot = false;
                hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                hit.transform.GetComponent<Rigidbody>().useGravity = true;
                hit.transform.parent = null;
            }
        }
        
     
        
    }
}
