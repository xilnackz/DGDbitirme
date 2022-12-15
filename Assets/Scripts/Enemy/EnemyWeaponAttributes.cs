using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponAttributes : MonoBehaviour
{
    // Start is called before the first frame update
    
    public AttributesManager atm;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<AttributesManager>().TakeDamage(atm.attackDmg);
        }
    }
}
