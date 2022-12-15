using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public int health;
    public int attackDmg;
    public bool isEnemy;
    public bool isPlayer;
    public bool destroyableObj;
    public GameObject orbSpawn;

    public void Update()
    {
        PlayerDead();
        DestroyObject();
        DestroyEnemy();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void DealDamage(GameObject target)
    {
         var atm = target.GetComponent<AttributesManager>();

         if (atm != null)
         {
             atm.TakeDamage(attackDmg);
         }
    }

    public void DestroyObject()
    {
        if (destroyableObj && health <= 0)
        {
            
            Destroy(gameObject);
            
        }
    }
    public void DestroyEnemy()
    {
        if (isEnemy && health <= 0)
        {
            Instantiate(orbSpawn, transform.position , transform.rotation);
            Destroy(gameObject);
            
        }
    }
    public void PlayerDead()
    {
        if (isPlayer && health <= 0)
        {
            //oyuncuyu öldürme
        }
    }
}
