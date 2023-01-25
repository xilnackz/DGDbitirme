using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPuzzles : MonoBehaviour
{
   [SerializeField] GameObject Obje;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Puzzle")
        {
            Destroy(Obje);
        }
    }

    


}
