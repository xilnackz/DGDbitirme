using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon;
    public GameObject _skill1;
    public PlayerMovementTutorial pmv;
    public void EnableWeaponCollider(int isEnable)
    {
        if (weapon !=null)
        {
            var col = weapon.GetComponent<Collider>();

            if (col != null)
            {
                if (isEnable == 1)
                {
                    col.enabled = true;
                }
                else
                {
                    col.enabled = false;
                }
            }
        }
    }

    public void EnableSkill1Collider(int isEnable)
    {
        if (_skill1 !=null)
        {
            var col = _skill1.GetComponent<Collider>();

            if (col != null)
            {
                if (isEnable == 1)
                {
                    col.enabled = true;
                }
                else
                {
                    col.enabled = false;
                }
            }
        }
    }

    public void EnableMovement(bool enable)
    {
        if (enable == false)
        {
            pmv.lockMovement = true;
        }
        else
        {
            pmv.lockMovement = false;
        }
    }
}
