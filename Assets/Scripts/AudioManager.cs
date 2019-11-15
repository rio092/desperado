using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMName
{
    Title,
    main,
}

public enum SEName
{
    shot,
    fall,
    drum,
    fun,
}

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSourceBGM;
    private AudioSource audioSourceSE;
    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private AudioClip[] seClips;

    private new void Awake()
    {
        base.Awake();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSourceBGM = audioSources[0];
        audioSourceSE = audioSources[1];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM(BGMName name)
    {
        audioSourceBGM.Stop();
        audioSourceBGM.clip = bgmClips[(int)name];
        audioSourceBGM.Play();
    }

    public void PlaySE(SEName name,float volumeScale)
    {
        audioSourceSE.PlayOneShot(seClips[(int)name], volumeScale);
    }

    public void StopAllsound()
    {
        audioSourceBGM.Stop();
        audioSourceSE.Stop();
    }
}
