using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    private Player player;

    public GameObject explosionPrefab;
    private GameObject currentExplosion;
    public int pointsGained;
    public Transform positionOffset;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Player"))
        {
            player = collidedObject.GetComponent<Player>();
            if (player != null)
            {
                player.health--;
                Debug.Log("Success: " + player.health);
                Destroy(this.gameObject);
            }
        }
        else if (collidedObject.CompareTag("Projectile1"))
        {
            Debug.Log("Hit projectile");
            GameManager.player.points += pointsGained;
            StartCoroutine(FireExplosion());
           Destroy(this.gameObject);
        }
        else if(collidedObject.CompareTag("Boundary")){
            Destroy(this.gameObject);
            Debug.Log("Other Collided Tag");
        }



    }

    IEnumerator FireExplosion()
    {
        currentExplosion = Instantiate(explosionPrefab, positionOffset.position, positionOffset.rotation);
        yield break;
    }
}
