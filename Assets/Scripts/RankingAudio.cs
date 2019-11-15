using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySE(SEName.Drum, (float)0.3);
        StartCoroutine("Fun");
    }

    // Update is called once per frame
    IEnumerator Fun()
    {;
        yield return new WaitForSeconds(4);
        AudioManager.Instance.PlaySE(SEName.Fun, 1);
    }
}
