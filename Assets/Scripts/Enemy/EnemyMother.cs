using UnityEngine;

public class EnemyMother : Shooting_Enemy {

    public float moveSpeed;

    private void Update()
    {
        if (!GameController.singleton.GamePaused)
            if(spriteRenderer.enabled)
                transform.Translate(new Vector2(moveSpeed, 0));
    }

    protected override void LateUpdate()
    {
        if (transform.position.x - Collider2D.size.x/2  > GameController.singleton.rightBorder ||
            transform.position.x + Collider2D.size.x/2  < GameController.singleton.leftBorder)
        {
            RemoveFromList();
            Destroy(gameObject);
        }
    }
}
