using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------------Audio SFX------------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------------Audio Sounds------------")]

    public AudioClip SoundShoot;
    public AudioClip SoundDie;
    public AudioClip SoundEnemy;
    public AudioClip SoundClick;

    [Header("------------------Audio Music------------")]

    public AudioClip SongMenu;
    public AudioClip SongLab;
    public AudioClip SongEgip;

    private void Start()
    {
        MusicSource.clip = SongMenu;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.PlayOneShot(clip);
    }
}
