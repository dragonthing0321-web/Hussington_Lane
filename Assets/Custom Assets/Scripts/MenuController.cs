using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public float spawnRate = 4.5f;
    public float spawnRate1 = 2.5f; 
    public static int previousLives = 4;
    public void PlayGame(float difficulty)
    {
        SceneManager.LoadScene("Gameplay");
        spawnRate /= difficulty;   
        spawnRate1 /= difficulty;
        SpawnManager.spawnRate = spawnRate;
        SpawnManager1.spawnRate1 = spawnRate1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MenuScreen");
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayAudio();
        }
    }   

    public void Replay() 
    {
        LivesController.currentLives = previousLives;
        SceneManager.LoadScene("Gameplay");
        if (AudioController.Instance != null)
        {
            AudioController.Instance.PlayAudio();
        }
    }
}