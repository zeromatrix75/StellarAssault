using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHit : MonoBehaviour
{
    private Player player;

    public GameObject explosionPrefab;
    private GameObject currentExplosion;
    public int bossHealth;
    public int pointsGained;
    public Transform positionOffset;
    private float burstRadius = 1.5f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        
        originalColor = spriteRenderer.color;
    }

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
        else if (collidedObject.CompareTag("Projectile1"))
        {
           bossHealth--;

            StartCoroutine(ChangeColorAndAlphaForSplitSecond());
           
           //Destroy(this.gameObject);
           if(bossHealth <= 0){
                
                
                StartCoroutine(FireExplosion());
           }
        }
     


    }

IEnumerator FireExplosion()
{

    for (int i = 0; i < 10; i++)
    {
        Vector3 randomOffset = Random.insideUnitCircle * burstRadius;
        Vector3 explosionPosition = positionOffset.position + randomOffset;

        currentExplosion = Instantiate(explosionPrefab, explosionPosition, positionOffset.rotation);

        yield return new WaitForSeconds(.25f);
    }

    GameManager.stageCleared = true;
    GameManager.player.points += pointsGained;
    Destroy(this.gameObject);
}

    private IEnumerator ChangeColorAndAlphaForSplitSecond()
    {

        // Set color to white with 50% alpha
        Color newColor = Color.red;
        newColor.a = 1.0f; // Set alpha 
        spriteRenderer.color = newColor;

        yield return new WaitForSeconds(0.05f); // Adjust the duration as needed

        // Restore the original color
        spriteRenderer.color = originalColor;
    }

}
