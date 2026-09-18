using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //This is Audio Manager
    
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip background;
    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip buttonClick;

    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayGunShot()
    {
        sfxSource.PlayOneShot(gunShot);
    }

    public void PlayGameOver()
    {
        sfxSource.PlayOneShot(gameOver);
    }

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClick);
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
}