using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    int X, Y;
    bool isRunning = false;
    public  int n;
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
    public Shotpoint shot;
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
        
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }
        else
        {
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //  Debug.Log("a" + n);
        if (n == 1)
            {
            Debug.Log("b" + n);
            // 右・左
           x = Input.GetAxis("Horizontal");
                // 上・下
                y = Input.GetAxis("Vertical"); 
       /*        // 右・左
              x = Input.GetAxis(controllerName + "X");
              // 上・下
              y = Input.GetAxis(controllerName + "Y"); */
              X = (int)System.Math.Round(x);
              Y = (int)System.Math.Round(y);
            Vector2 direction = new Vector2(X, Y);
                GetComponent<Rigidbody2D>().velocity = direction * speed;
            if (shot.x != 0 || shot.x != 0)
            {
                    float a = shot.x;
                    float b = shot.y;
                    float ShotX = Mathf.Sign(a) * Mathf.Sqrt(a * a / (a * a + b * b));
                 float ShotY = Mathf.Sign(b) * Mathf.Sqrt(b * b / (a * a + b * b));
                    Anim.SetBool("IsIdle", false);
                Anim.SetBool("IsRun", true);
                Anim.SetFloat("Right", ShotX);
                Anim.SetFloat("Forward", -ShotY);
            }else {
                Anim.SetBool("IsRun", false);
                Anim.SetBool("IsIdle", true);
            }

                if (Input.GetButtonDown(controllerName + "Function1") || Input.GetKeyDown(KeyCode.Z))
                {
                    if (!isRunning)
                    {
                        StartCoroutine("Shot");
                    }
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "bullet" && col.gameObject.name!= "Bullet"+ playerID+"(Clone)")
        {
            Destroy(col.gameObject);
            if (hit == 0)
            {
                int backx = (int)Mathf.Round(col.attachedRigidbody.velocity.x);
                int backy = (int)Mathf.Round(col.attachedRigidbody.velocity.y);
                hit = 1;
                n = 0;
                Anim.SetFloat("Right", -backx);
                Anim.SetFloat("Forward", backy);
                Anim.SetBool("IsKnockback", true);
                GetComponent<Rigidbody2D>().velocity = (col.attachedRigidbody.velocity)/2;
                StartCoroutine("Stop");
                point.transform.localPosition = new Vector3((-backx) + (1 / 10), (-backy) * 7/4 -1, 0);
                float rad = Mathf.Atan2(backx, -backy);
                float degree = rad * 180 / Mathf.PI  ;
                point.transform.rotation = Quaternion.Euler(0.0f, 0.0f, degree);
            }
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1f);
        n = 1;
        Anim.SetBool("IsKnockback", false);
        yield return new WaitForSeconds(0.3f);
        hit = 0;
    }
    public IEnumerator Shot()
    {
        isRunning = true;
        Anim.SetBool("IsAttack", true);
        n = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Instantiate(bullet, point.transform.position, point.transform.rotation);
        yield return new WaitForSeconds(1.5f);
        if(hit==0) n = 1;
        Anim.SetBool("IsAttack", false);
        isRunning = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        n = 1;
    }
}
