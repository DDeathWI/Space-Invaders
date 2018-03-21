using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    protected TextMesh scoreValue;

    protected LayerMask PlayerProjectile;

    protected BoxCollider2D Collider2D;
    
    protected SpriteRenderer spriteRenderer;
    
    protected virtual void Awake()
    {
        PlayerProjectile = LayerMask.GetMask("PlayerProjectile");
        Collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        SetNotActive();

    }

    protected void SetNotActive()
    {
        spriteRenderer.enabled = false;
        Collider2D.enabled = false;
        GameController.singleton.AddScore(int.Parse(scoreValue.text));
        scoreValue.gameObject.SetActive(true);

        Destroy(gameObject, 2);
        transform.parent = null;
    }

    protected void OnDestroy()
    {
        EnemyController.listEnemies.Remove(transform);

        if (EnemyController.listEnemies.Count == 0)
        {
            GameController.singleton.EndPanel.SetActive(true);
            GameController.singleton.GameOver = true;
        }

    }







}
