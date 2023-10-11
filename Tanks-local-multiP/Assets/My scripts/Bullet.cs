using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2Int DamageLimits = new Vector2Int(10, 20);
    public float lifetime = 5f;
    private Rigidbody rb;
    public GameObject explosionVFx;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 1000f);
        Invoke(nameof(explode), lifetime);
     

    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tank") || collision.gameObject.CompareTag("Destructable"))
        {
            var health = collision.gameObject.GetComponent<Health>();

            if (health != null)
            {
                var damage = Random.Range(DamageLimits.x, DamageLimits.y);
                
                health.TakeDamage(damage);
            }
            explode();
        }
    }
    void explode()
    {
        Instantiate(explosionVFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
