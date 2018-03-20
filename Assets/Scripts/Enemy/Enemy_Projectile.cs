using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.1f;

    [SerializeField]
    private Rigidbody2D body;

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameController.singleton.GamePaused)
        {
            body.velocity = new Vector2(0, 0);
            return;
        }

        //transform.Translate(new Vector2(0, speed));

        body.velocity = new Vector2(0, -speed);

        if (transform.position.y <= GameController.singleton.bottomBorder)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
