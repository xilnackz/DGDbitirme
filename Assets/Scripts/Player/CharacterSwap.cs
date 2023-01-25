using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    public GameObject temerario, dura, cross;
    public int whichcharon = 1;
    void Start()
    {
        temerario.gameObject.SetActive(true);
        dura.gameObject.SetActive(false);
        cross.gameObject.SetActive(false);
        
    }

    public void SwapCharacter()
    {
        switch (whichcharon)
        {
            case 1:
                
                whichcharon = 2;
                temerario.gameObject.SetActive(false);
                dura.gameObject.SetActive(true);
                cross.gameObject.SetActive(true);
                break;
            
            case 2:
                whichcharon = 1;
                temerario.gameObject.SetActive(true);
                dura.gameObject.SetActive(false);
                cross.gameObject.SetActive(false);
                break;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwapCharacter();
        }
        
    }
}
