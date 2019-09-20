using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float x;
    public static float y;
    public float speed;
    private Animator _anim;
    public Animator Anim { get { return this._anim ? this._anim : this._anim = GetComponent<Animator>(); } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右・左
        x = Input.GetAxisRaw("Horizontal");
        // 上・下
        y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        Anim.SetFloat("x", x);
        Anim.SetFloat("y", y);
    }
}
