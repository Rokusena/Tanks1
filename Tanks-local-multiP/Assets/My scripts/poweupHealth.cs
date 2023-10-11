using UnityEngine;

public class poweupHealth : MonoBehaviour
{

    private Player player;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank"))
        {
           
            player = collision.gameObject.GetComponent<Player>();
            var health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(-100);


        }
    }
   
}
