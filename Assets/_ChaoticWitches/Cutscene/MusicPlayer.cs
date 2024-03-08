using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    private void Awake()
    {
        music = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        music.Play();
    }
}
