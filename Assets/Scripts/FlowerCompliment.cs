using UnityEngine;

public class FlowerCompliment : MonoBehaviour
{
   

    [SerializeField] public ComplimentManager complimentsManager;

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Trigger the compliment
            complimentsManager.ShowCompliment();

            // Destroy the flower
            Destroy(gameObject);
        }
    }


}
