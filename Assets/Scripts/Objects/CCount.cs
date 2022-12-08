using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CCount : MonoBehaviour
{
    TMPro.TMP_Text _text;
    public int count;

    private void Awake()
    {
        _text = GetComponent<TMPro.TMP_Text>();
    }

    void Start()
    {
        UpdateCount();
    }

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        _text.text = $"{count}";
    }
}
