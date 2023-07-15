using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    private Player player;

    public GameObject explosionPrefab;
    private GameObject currentExplosion;
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
            }
        }

        if (collidedObject.CompareTag("Projectile1"))
        {
            Debug.Log("Hit projectile");
            GameManager.player.points += 10;
            StartCoroutine(FireExplosion());
        }

        Destroy(this.gameObject);
    }

    IEnumerator FireExplosion()
    {
        currentExplosion = Instantiate(explosionPrefab, positionOffset.position, positionOffset.rotation);
        yield break;
    }
}
