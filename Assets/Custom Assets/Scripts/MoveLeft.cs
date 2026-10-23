using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   public float speed = 30.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Instakill"))
        { 
            Destroy(gameObject);
        }
    }
}
