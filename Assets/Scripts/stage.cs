﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit2D(Collider2D col)
   {
        Debug.Log("AAA");
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Debug.Log("CCC");
        }

    }
}

