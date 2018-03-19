using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private Rigidbody2D body;

    // Update is called once per frame
    void LateUpdate () {
        if (GameController.singleton.GamePaused)
            return;

        //transform.Translate(new Vector2(0, speed));

        body.velocity = new Vector2(0, speed);

        if (transform.position.y >= GameController.singleton.topBorder)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}

