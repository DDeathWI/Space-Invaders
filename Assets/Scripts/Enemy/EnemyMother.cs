using UnityEngine;

public class EnemyMother : Shooting_Enemy {

    public float moveSpeed;

    protected override void Start()
    {

    }

    private void Update()
    {
        if (!GameController.singleton.GamePaused)
            if(spriteRenderer.enabled)
                transform.Translate(new Vector2(moveSpeed, 0));
    }

    protected override void LateUpdate()
    {

        if (moveSpeed > 0)
        {
            if (transform.position.x + Collider2D.size.x / 2 >= GameController.singleton.rightBorder + 0.2f)
            {
                //false
                Destroy(gameObject);


            }
        }
        else if (transform.position.x - Collider2D.size.x / 2 <= GameController.singleton.leftBorder - 0.2f)
        {
            //true
            Destroy(gameObject);
        }

    }
}
