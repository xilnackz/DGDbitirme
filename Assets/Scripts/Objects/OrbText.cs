using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrbText : MonoBehaviour
{
    public TextMeshProUGUI orbText;
    private int orbCount;

    private void Awake()
    {
        orbText.text = $"Orb: {orbCount}";
    }

    private void OnEnable()
    {
        Orb.OnOrbCollected += IncrementOrbCount;
    }

    private void OnDisable()
    {
        Orb.OnOrbCollected -= IncrementOrbCount;
    }

    public void IncrementOrbCount()
    {
        orbCount++;
        orbText.text = $"Orb: {orbCount}";
    }
}
