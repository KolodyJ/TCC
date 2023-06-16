using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager mManager;

    public AudioSource aSource;
    public AudioClip[] listAudioClip;

    private void Awake()
    {
        if(mManager == null)
        {
            mManager = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        aSource = GetComponent<AudioSource>();    
    }

    public void PlaySound(int p)
    {
        if(aSource.clip != listAudioClip[p])
        {
            aSource.clip = listAudioClip[p];
            aSource.Play();
        }
    }


}
