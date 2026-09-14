using UnityEngine;

public class AudioController : MonoBehaviour
{
   public static AudioController Instance { get; private set; }
   private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }   

}
