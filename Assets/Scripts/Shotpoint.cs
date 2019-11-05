using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotpoint : MonoBehaviour
{
    float x, y,X=0,Y=1;
    [SerializeField, Range(1, 4)] private int playerID;
    private string controllerName;
    // Start is called before the first frame update
    void Start()
    {
        controllerName = "Gamepad" + playerID + "_";
    }

    // Update is called once per frame
    void Update()
    {
        // 右・左
        float x = Input.GetAxis("Horizontal");
        // 上・下
        float y = Input.GetAxis("Vertical");
     /*     // 右・左
          x = Input.GetAxis(controllerName + "X");
          // 上・下
          y = Input.GetAxis(controllerName + "Y");*/
        Vector3 localPos = transform.localPosition;
        if (x != 0 || y != 0)
        {
            X = Mathf.Sign(x) * Mathf.Sqrt(x * x / (x * x + y * y));
            Y = Mathf.Sign(y) * Mathf.Sqrt(y * y / (x * x + y * y));
          //  Debug.Log(X + "と" + Y);
            localPos.x = (X / 2);
            localPos.y = (Y / 2);
            transform.localPosition = localPos;
        }
        float rad = Mathf.Atan2(Y, X);
        float degree = rad * 180 / Mathf.PI - 90;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, degree);    
    }
}

