using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float x;
    public float y;

    private Animator _anim;

    public Animator Anim { get { return this._anim ? this._anim : this._anim = GetComponent<Animator>(); } }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Position = transform.position;
        // 右・左"Horizontal"
        x = Input.GetAxisRaw("Horizontal");
        //上・下"Vertical"
        y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x,y).normalized;
          GetComponent<Rigidbody2D>().velocity = direction;

        Anim.SetFloat("x", x);
        Anim.SetFloat("y", y);
    }

}