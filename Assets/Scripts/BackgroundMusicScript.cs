using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioSource thisSource;
    public AudioClip levelstart;
    public AudioClip backgroundNormal;
    // Start is called before the first frame update
    void Start()
    {
        thisSource = GetComponent<AudioSource>();
        thisSource.PlayOneShot(levelstart, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!thisSource.isPlaying)
        {
            thisSource.PlayOneShot(backgroundNormal, 1.0f);
        }
    }
}
