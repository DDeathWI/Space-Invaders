using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private int PlayerLife = 3;

    [SerializeField]
    private float movement_speed = 3f;

    [SerializeField]
    private GameObject projectile_prefab;

    [SerializeField]
    private Transform projectile_start_position;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update () {
        if (GameController.singleton.GamePaused)
        {
            body.velocity = new Vector2(0, 0);
            return;
        }

        Move();

        Shooting();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, GameController.singleton.leftBorder, GameController.singleton.rightBorder), transform.position.y);
    }

    /// <summary>
    /// Player Move
    /// </summary>
    private void Move() {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector2(movement_speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(-movement_speed * Time.deltaTime, 0);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }

    /// <summary>
    /// Player Shooting
    /// </summary>
    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(projectile_prefab, projectile_start_position.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damaged();
    }

    private void Damaged()
    {
        PlayerLife--;

        if (PlayerLife <= 0)
        {
            //GameOver
            GameController.singleton.GamePaused = true;
            GameController.singleton.EndPanel.SetActive(true);

            Destroy(gameObject);
            return;
        }

        GameController.singleton.SetLife(PlayerLife);
        GameController.singleton.ReAppear(transform);
    }
}
