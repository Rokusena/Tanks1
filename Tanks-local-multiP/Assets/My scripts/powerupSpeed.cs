using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupSpeed : MonoBehaviour
{
    public float speedIncrese = 1.5f;
    public float time = 15;
    private Player player;
    private float oldSpeed;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Tank"))
        {
            transform.position = new Vector3(0, 100, 0);
            player = collision.gameObject.GetComponent<Player>();
            oldSpeed = player.speed;
            StartCoroutine(ChangeSpeed());
          
        }
    }
    IEnumerator ChangeSpeed()
    {
        player.speed *= speedIncrese;
        yield return new WaitForSeconds(time);
        player.speed = oldSpeed;
        Destroy(gameObject);
    }
}
