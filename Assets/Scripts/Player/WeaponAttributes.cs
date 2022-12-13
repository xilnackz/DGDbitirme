using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    // Start is called before the first frame update
    public AttributesManager atm;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy") || other.CompareTag("Destroyable"))
        {
            other.GetComponent<AttributesManager>().TakeDamage(atm.attackDmg);
        }
    }
}
