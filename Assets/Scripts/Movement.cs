using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    int X, Y;
    bool isRunning = false;
    public int n;
    public static float x;
    public static float y;
    public float speed;
    public Pause pause;
    private int hit;
    [SerializeField, Range(1, 4)] private int playerID;
    private string controllerName;
    private Animator _anim;
    public Animator Anim { get { return this._anim ? this._anim : this._anim = GetComponent<Animator>(); } }
    public GameObject bullet;
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        n = 0;
        controllerName = "Gamepad" + playerID + "_";
        StartCoroutine("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }
        else
        {*/
            if (n == 1)
            {
                // 右・左
                x = Input.GetAxis("Horizontal");
                // 上・下
                y = Input.GetAxis("Vertical"); 
            /*  // 右・左
              x = Input.GetAxisRaw(controllerName + "X");
              // 上・下
              y = Input.GetAxisRaw(controllerName + "Y");*/
              X = (int)System.Math.Round(x);
              Y = (int)System.Math.Round(y);
            Vector2 direction = new Vector2(X, Y);
                GetComponent<Rigidbody2D>().velocity = direction * speed;
            //  Anim.SetFloat("x", x);
            //  Anim.SetFloat("y", y);

                if (Input.GetButtonDown(controllerName + "Function1") || Input.GetKeyDown(KeyCode.Z))
                {
                    StartCoroutine("Shot");
                }
            }
       // }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "bullet" && hit == 0)
        {
            hit = 1;
            n = 0;
            GetComponent<Rigidbody2D>().velocity = col.attachedRigidbody.velocity;
            Debug.Log("asd");
            Destroy(col.gameObject);
            StartCoroutine("Stop");
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1f);
        n = 1;
        yield return new WaitForSeconds(0.5f);
        hit = 0;
    }
    public IEnumerator Shot()
    {
        Debug.Log("aaa");
        if (isRunning)  yield break;

        isRunning = true;
        Instantiate(bullet, point.transform.position, point.transform.rotation);
        yield return new WaitForSeconds(1.5f);
        isRunning = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        n = 1;
    }
}
