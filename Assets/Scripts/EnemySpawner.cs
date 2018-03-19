using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject enemy_normal_prefab;

    Vector2 enemy_normal_size;
    Vector3 SpawnPoint;

    Vector2 space;


    // Use this for initialization
    void Start () {
        SpawnPoint = Camera.main.ViewportToWorldPoint(new Vector2(.5f, .8f));
        

        enemy_normal_size = enemy_normal_prefab.GetComponent<BoxCollider2D>().size;
        space = enemy_normal_size / 5;

        SpawnPoint = new Vector3(SpawnPoint.x - 2.5f*(enemy_normal_size.x + space.x), SpawnPoint.y, 0);

        Spawn();
	}

    void Spawn()
    {
        for (int height = 0; height > -6; height--)
        {
            float posY = height * enemy_normal_size.y + space.y * height;

            for (int width = 0; width < 6; width++)
            {
                float posX = width * enemy_normal_size.x + space.x * width;
                Instantiate(enemy_normal_prefab, SpawnPoint + new Vector3(posX, posY, 0), Quaternion.identity);
            }
        }
    }

   

}
