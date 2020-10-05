
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    [SerializeField] private AudioClip[] playlist;
    [SerializeField] private AudioSource audioSource;
    private int musicIndex = 0;
    [SerializeField] private AudioClip defaultSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioClip GetDefaultSound()
    {
        return defaultSound;
    }
}
