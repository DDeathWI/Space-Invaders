using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Detect When Main Enemy Block Hit Screen Edge
    public ObserverDetectEnemyHittingScreenEdge hit;

    public List<Transform> ListEnemies = new List<Transform>();

    [SerializeField]
    private bool MoveRight;

    [SerializeField]
    private float move_accelereation = 0.01f;

    [SerializeField]
    private GameObject enemy_normal_prefab;

    [SerializeField]
    private GameObject enemy_shooting_prefab;

    [SerializeField]
    private GameObject enemy_mother_prefab;

    [SerializeField]
    private float move_speed;

    [SerializeField]
    protected float DownSpeed;

    [SerializeField]
    private List<int> ColumnShootingEnemies;

    [SerializeField]
    private List<int> RowShootingEnemies;

    [SerializeField]
    private float moveTime;

    [SerializeField]
    private float motherBoardSpawnDelay = 4;

    [SerializeField]
    private int motherBoadChance = 40;

    private Coroutine moveCoroutine;
    private Coroutine motherBoardSpawn;

    private Vector2 enemy_normal_size;
    private Vector3 SpawnPoint;

    private Vector3 LeftMotherSpawnPoints;
    private Vector3 RightMotherSpawnPoints;

    private Vector2 space;

    // Initiali2ate Values and Run Coroutines 
    private void Start() {
        hit = new ObserverDetectEnemyHittingScreenEdge();

        SpawnPoint = Camera.main.ViewportToWorldPoint(new Vector2(.5f, .8f));

        enemy_normal_size = enemy_normal_prefab.GetComponent<BoxCollider2D>().size;
        space = enemy_normal_size / 5;

        SpawnPoint = new Vector3(SpawnPoint.x - 2.5f*(enemy_normal_size.x + space.x), SpawnPoint.y, 0);

        LeftMotherSpawnPoints = Camera.main.ViewportToWorldPoint(new Vector2(0, .85f))
             - new Vector3(enemy_mother_prefab.GetComponent<BoxCollider2D>().size.x / 2,0,0);

        RightMotherSpawnPoints = Camera.main.ViewportToWorldPoint(new Vector2(1, .85f))
            + new Vector3(enemy_mother_prefab.GetComponent<BoxCollider2D>().size.x / 2, 0, 0); ;

        Debug.Log(LeftMotherSpawnPoints);

        LeftMotherSpawnPoints = new Vector3(LeftMotherSpawnPoints.x, LeftMotherSpawnPoints.y, 0);
        RightMotherSpawnPoints = new Vector3(RightMotherSpawnPoints.x, RightMotherSpawnPoints.y, 0);

        Spawn();
        moveCoroutine = StartCoroutine(Move());
        motherBoardSpawn = StartCoroutine(MotherSpawn());
    }

    // Main Enemy Block Spawn 
    private void Spawn()
    {
        for (int height = 0; height > -6; height--)
        {
            float posY = height * enemy_normal_size.y + space.y * height;

            bool canShooting = false;

            if (ColumnShootingEnemies.Contains(-height + 1))
                canShooting = true;

            for (int width = 0; width < 6; width++)
            {
                float posX = width * enemy_normal_size.x + space.x * width;
                Transform invader;

                if (canShooting)
                {
                    if (RowShootingEnemies.Contains(width + 1))
                    {
                        invader = Instantiate(enemy_shooting_prefab, SpawnPoint + new Vector3(posX, posY, 0), Quaternion.identity).transform;
                    }
                    else {
                        invader = Instantiate(enemy_normal_prefab, SpawnPoint + new Vector3(posX, posY, 0), Quaternion.identity).transform;
                    }
                }
                else
                {
                    invader = Instantiate(enemy_normal_prefab, SpawnPoint + new Vector3(posX, posY, 0), Quaternion.identity).transform;
                }

                ListEnemies.Add(invader);

                invader.parent = transform;

                Normal_Enemy enemyScript = invader.GetComponent<Normal_Enemy>();

                enemyScript.EnemyMoveObserver = hit;
                enemyScript.OnHitEdge += HitScreenEdge;

                enemyScript.ObjectDestroyed += RemoveEnemy;

                if (MoveRight)
                {
                    hit.AddEvent(ObserverDetectEnemyHittingScreenEdge.Edge.Right, HitScreenEdge);
                }
                else
                {
                    hit.AddEvent(ObserverDetectEnemyHittingScreenEdge.Edge.Left, HitScreenEdge);
                }


            }
        }
    }

    // Main Eney Block Move
    private IEnumerator Move()
    {
        while (true)
        {
            if (!GameController.singleton.GamePaused)
            {
                if (MoveRight)
                {
                    transform.Translate(new Vector2(move_speed, 0));
                }
                else
                {
                    transform.Translate(new Vector2(-move_speed, 0));
                }
            }

            float resultSpeedDelay = moveTime - move_accelereation;
            resultSpeedDelay = Mathf.Clamp(resultSpeedDelay, 0.03f, 1);

            yield return new WaitForSecondsRealtime(resultSpeedDelay);
        }
    }

    // Action When ScreenEdgeHit
    private void HitScreenEdge()
    {
        MoveRight = !MoveRight;
        move_accelereation += 0.05f;
        transform.Translate(new Vector2(0, -DownSpeed));
    }

    // Moother BoadSpawn 
    private IEnumerator MotherSpawn()
    {
        while (true)
        {
            if (GameController.singleton.GamePaused)
            {
                yield return new WaitForSecondsRealtime(GameController.singleton.PauseTime);
            }
            else
            {
                yield return new WaitForSecondsRealtime(motherBoardSpawnDelay);

                bool respawnMother = Random.Range(0, 100) <= motherBoadChance;

                if (respawnMother)
                {
                    Transform invader;
                    EnemyMother enemyScript;

                    int randomMove = Random.Range(0, 2);

                    if (randomMove == 0)
                    {
                        invader = Instantiate(enemy_mother_prefab, LeftMotherSpawnPoints, Quaternion.identity).transform;
                        enemyScript = invader.GetComponent<EnemyMother>();
                        enemyScript.moveSpeed = .1f;
                    }
                    else
                    {
                        invader = Instantiate(enemy_mother_prefab, RightMotherSpawnPoints, Quaternion.identity).transform;
                        enemyScript = invader.GetComponent<EnemyMother>();
                        enemyScript.moveSpeed = -.1f;
                    }

                    enemyScript.ObjectDestroyed += RemoveEnemy;

                    ListEnemies.Add(invader);
                }
            }
        }
    }


    // Need Some Changes with Game End ANd Pause
    private void RemoveEnemy(Transform t)
    {
        ListEnemies.Remove(t);


        Debug.Log("Enemy Removed" + ListEnemies.Count);

        if (ListEnemies.Count == 0)
        {
            GameController.singleton.GameOver = true;

            StopCoroutine(moveCoroutine);
            StopCoroutine(motherBoardSpawn);

            Debug.Log("Game Over");
            GameController.singleton.GamePaused = true;
            GameController.singleton.EndPanel.SetActive(true);
        }
    }
}


