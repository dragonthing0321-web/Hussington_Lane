using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesController : MonoBehaviour
{
    public static int currentLives = 4;
   
    public GameObject[] lives;
    public AudioSource playerSounds;
    public AudioClip deathSound;
    public AudioClip hurtSounds;
    public GameObject gameOverScreen;
    public bool isGameOver = false;
    public ScoreManager scoreManager;
    

    void Start()
    {
        UpdateLivesUI();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Instakill"))
            {
            currentLives = 0;
            UpdateLivesUI();
            Debug.Log("Lives: " + currentLives);
            if (currentLives <= 0)
            {
                Debug.Log("Game Over");
                // SceneManager.LoadScene("MenuScreen");
                playerSounds.PlayOneShot(deathSound);
                scoreManager.isGameOver = true;
                isGameOver = true;
                Destroy(gameObject);
                gameOverScreen.SetActive(true);
                if (AudioController.Instance != null)
                {
                    AudioController.Instance.StopAudio();
                }
               
            }
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentLives--;
            Destroy(collision.gameObject);

            UpdateLivesUI();
            Debug.Log("Lives: " + currentLives);
            if (currentLives <= 0)
            {
                Debug.Log("Game Over");
                // SceneManager.LoadScene("MenuScreen");
                playerSounds.PlayOneShot(deathSound);
                Destroy(gameObject);
                gameOverScreen.SetActive(true);
                if (AudioController.Instance != null)
                {
                    AudioController.Instance.StopAudio();
                }
            }
            else 
            {
              playerSounds.PlayOneShot(hurtSounds);
            }
        }
    }

    public void UpdateLivesUI()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < currentLives)
            {
                lives[i].SetActive(true);
            }
            else
            {
                lives[i].SetActive(false);
            }
        }
    }
}
