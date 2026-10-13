using System.Collections;
using UnityEngine;

public class PowerUpModifier : MonoBehaviour
{
    public ScoreManager scoreManager;
    public PlayerController playerController;
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            scoreManager.AddScore(5);
            StartCoroutine(TripleJumpTime());
            Destroy(gameObject);
        }
    }

    public IEnumerator TripleJumpTime() 
    {
        playerController.maxJumpValue = 3;
        yield return new WaitForSeconds(3.5f);
        playerController.maxJumpValue = 2;

    }
}
 