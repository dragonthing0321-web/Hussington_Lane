using UnityEngine;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour
{
    private Button button;
    private MenuController menuController;
    public float difficulty;
    public int lives;

    void Start()
    {
       button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty); 
        menuController = GameObject.Find("MenuController").GetComponent<MenuController>();

    }

    public void SetDifficulty() 
    {
        Debug.Log(gameObject.name + " was clicked");
        LivesController.currentLives = lives;
        MenuController.previousLives = lives;
        menuController.PlayGame(difficulty);

       
    }
    void Update()
    {
        
    }
}
