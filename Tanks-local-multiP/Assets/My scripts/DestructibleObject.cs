using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public GameObject breakVFX;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(breakVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
