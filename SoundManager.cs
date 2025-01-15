using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public enum BGMType
    {
        BGM_TEST,
    }
    public enum SfxType
    {
        Sfx_TEST,
    }
    [SerializeField]
    AudioClip[] BGM;
    [SerializeField]
    AudioClip[] sfx; // Effect Sounds

    [SerializeField]
    AudioSource audioBGM;
    [SerializeField]
    AudioSource audioSfx;
    public static SoundManager instance;
    private void Awake()
    {
        //singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMType BGM_NAME)
    {
        audioBGM.clip = BGM[(int)BGM_NAME];
        audioBGM.Play();
    }
    public void StopBGM()
    {
        audioBGM.Stop();
    }

    public void PlaySfx(SfxType Sfx_NAME)
    {
        audioSfx.clip = sfx[(int)Sfx_NAME];
        audioSfx.Play();
    }
}
