using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private LayerMask PlayerProjectile;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
