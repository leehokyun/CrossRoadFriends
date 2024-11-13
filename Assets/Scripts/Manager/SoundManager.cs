using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject soundSourceGO;
    public GameObject instantiatePos;
    public static SoundManager instance;

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume;

    private AudioSource musicAudioSource;
    public AudioClip musicClip;

    private void Awake()
    {
        instance = this;
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;
    }

    private void Start()
    {
        ChangeBackgroundMusic(musicClip);
    }

    private void ChangeBackgroundMusic(AudioClip musicClip)
    {
        instance.musicAudioSource.Stop();
        instance.musicAudioSource.clip = musicClip;
        instance.musicAudioSource.Play();
    }
    private void PlayClip(AudioClip clip)
    {
        //오브젝트 풀하기 (강의에 있음)
        Instantiate(soundSourceGO, instantiatePos.transform.position, Quaternion.identity);
        SoundSource soundSource = soundSourceGO.GetComponent<SoundSource>();
        soundSource.Play(clip, instance.soundEffectVolume, instance.soundEffectPitchVariance);
    }
}
