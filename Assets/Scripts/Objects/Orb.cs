using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Orb : MonoBehaviour, ICollectible
{
    public static event Action OnOrbCollected;
    public void Collect()
    {
        Destroy(gameObject);
        OnOrbCollected?.Invoke();
    }
}
