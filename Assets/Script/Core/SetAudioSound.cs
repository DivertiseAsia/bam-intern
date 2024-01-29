using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetAudioSound : MonoBehaviour
{
    public static SetAudioSound instance;
    [SerializeField] AudioSource BGM_audio;
    [SerializeField] AudioSource SFX_audio;
    public AudioSO so;
    int l;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null) instance = this;
        else Destroy(gameObject);
        so = AudioSO.instance;

        BGM_audio.Play();
        SFX_audio.enabled = false;
    }
    public void Update()
    {
        BGM_audio.volume = so.BGM_value;
        SFX_audio.volume = so.SFX_value;
    }


    public void ChangeBGM(AudioClip clip)
    {
        BGM_audio.clip = clip;
        BGM_audio.Play();
    }

    public void StopBGM()
    {
        BGM_audio.Stop();
    }

    public void DelayedPlaySFX(AudioClip clip, float delay)
    {
        StartCoroutine(PlaySFXRoutine(clip,delay));
    }

    IEnumerator PlaySFXRoutine(AudioClip clip, float delay)
    {
        SFX_audio.enabled = true;
        yield return new WaitForSeconds(delay);
        PlaySFX(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX_audio.clip = clip;
        SFX_audio.Play();
    }
}
