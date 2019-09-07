using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour  where T:Singleton<T> 
{
    private static T singleton;
    public static T Instance
    {
        get
        {
            return singleton;
        }
    }

    protected void Awake()
    {
        if(singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = (T)this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DestroyMe()
    {
        singleton = null;
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
