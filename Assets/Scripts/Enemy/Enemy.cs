using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    protected TextMesh scoreValue;

    protected LayerMask PlayerProjectile;

    protected BoxCollider2D Collider2D;
    
    protected SpriteRenderer spriteRenderer;

    public delegate void RemoveEnemy(Transform t);

    public event RemoveEnemy ObjectDestroyed;

    protected virtual void Awake()
    {
        PlayerProjectile = LayerMask.GetMask("PlayerProjectile");
        Collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Killed();
        Invoke("RemoveFromList", 2);
    }

    protected void RemoveFromList()
    {
        // Event Happened
        // Delete Enemy from EnemyList
        ObjectDestroyed(transform);

        //Destroy Enemy GameObject
        Destroy(gameObject);
    }


    // Need To Change 
    protected void Killed()
    {
        transform.parent = null;

        GameController.singleton.AddScore(int.Parse(scoreValue.text));
        scoreValue.gameObject.SetActive(true);
        spriteRenderer.enabled = false;
        Collider2D.enabled = false;
    }

}
