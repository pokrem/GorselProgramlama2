using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunYoneticisi : MonoBehaviour
{
    GameObject anaCember;
    GameObject kucukCember;

    // Start is called before the first frame update
    void Start()
    {
        anaCember = GameObject.FindGameObjectWithTag("anaCember");
        kucukCember = GameObject.FindGameObjectWithTag("kucukCember");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunBitti()
    {
        Debug.Log("oyun bitti");
    }
}