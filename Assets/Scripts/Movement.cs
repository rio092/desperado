using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool isRunning = false;
    public int n;
    public static float x;
    public static float y;
    public float speed;
    private Animator _anim;
    public Animator Anim { get { return this._anim ? this._anim : this._anim = GetComponent<Animator>(); } }
    public GameObject bullet;
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        n = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (n == 1)
        {
            // 右・左
            x = Input.GetAxisRaw("Horizontal");
            // 上・下
            y = Input.GetAxisRaw("Vertical");
            Vector2 direction = new Vector2(x, y);
             GetComponent<Rigidbody2D>().velocity = direction * speed;
            Anim.SetFloat("x", x);
            Anim.SetFloat("y", y);
            StartCoroutine("Shot");
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "bullet")
        {
            n = 0;
            GetComponent<Rigidbody2D>().velocity = col.attachedRigidbody.velocity;
            Debug.Log("asd");
            Destroy(col.gameObject);
            StartCoroutine("Stop");
            
        }
        Debug.Log("as");       
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2);
        n = 1;
    }
    public IEnumerator Shot()
    {
        if (isRunning)
            yield break;

        isRunning = true;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet, point.transform.position, point.transform.rotation);

            yield return new WaitForSeconds(2);
        }

        isRunning = false;

    }
}
