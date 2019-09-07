using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletpoint: MonoBehaviour
{
    // bullet prefab
    public GameObject bullet;
    public float speed;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Position = transform.position;
        // 右・左"Horizontal"
        float x = Input.GetAxisRaw("Horizontal");
        // 上・下"Vertical"
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = direction;
        //  direction.x *= speed;
        //  direction.y *= speed;
        //  Position.x += direction.x;
        //  Position.y += direction.y;
        //  transform.position = Position;
        switch (y){
            case 0:
                if (x == 1)
                {
                    transform.Rotate(new Vector3(0, 0, 1), -90);
                }
                else if (x == -1){ transform.Rotate(new Vector3(0, 0, 1), -90); }
                    break;
            case 1:
                if (x == 1)
                {
                    transform.Rotate(new Vector3(0, 0, 1), -90);
                }
                else if (x==0)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0); ;
                }
                else if (x == -1)
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0); ;
                }
                break;
            case -1:
                if (x == 1)
                {
                    transform.Rotate(new Vector3(0, 0, 1), -90);
                }
                else if (x == 0)
                {
                    transform.Rotate(new Vector3(0, 0, 1), -90);
                }
                else if (x == -1)
                {
                    transform.Rotate(new Vector3(0, 0, 1), -90);
                }
                break;
        }
    


        // z キーが押された時
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        Instantiate(bullet, transform.position, transform.rotation);
                    }

    }
}