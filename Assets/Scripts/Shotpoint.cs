using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        Transform mytransform = this.transform;
        Vector3 localPos = mytransform.localPosition;
        if (Movement.x != 0 || Movement.y != 0)
        {
            localPos.x = (Movement.x / 1);
            localPos.y = (Movement.y / 1);
            mytransform.localPosition = localPos;
        }
        if (Movement.x == 0 && Movement.y == 1)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0);
        }
        if (Movement.x == -1 && Movement.y == 1)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45);
        }
        if (Movement.x == -1 && Movement.y == 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90);
        }
        if (Movement.x == -1 && Movement.y == -1)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135);
        }
        if (Movement.x == 0 && Movement.y == -1)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180);
        }
        if (Movement.x == 1 && Movement.y == -1)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 225);
        }
        if (Movement.x == 1 && Movement.y == 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270);
        }
        if (Movement.x == 1 && Movement.y == 1)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 315);
        }

    }
}

