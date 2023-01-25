using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{

    public bool hasItemInSlot;
    public float distance;
    public GameObject cam;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); 

        float distance= 500f;

        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
          
            if (hit.transform.CompareTag("Pickupable") && Input.GetKey("1") && !hasItemInSlot)
            {
                hasItemInSlot = true;
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.GetComponent<Rigidbody>().useGravity =false;
                hit.transform.parent = cam.transform;
            }
            
            if (Input.GetKey("2") && hasItemInSlot)
            {
                hasItemInSlot = false;
                hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                hit.transform.GetComponent<Rigidbody>().useGravity = true;
                hit.transform.parent = null;
            }
        }
        
     
        
    }
}
