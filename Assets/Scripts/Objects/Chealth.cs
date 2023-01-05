using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chealth : MonoBehaviour
{
    public AttributesManager atm;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<AttributesManager>().TakeDamage(-30);
        }
    }
}
