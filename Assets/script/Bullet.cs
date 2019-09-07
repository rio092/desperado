using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
   
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
    }
}
