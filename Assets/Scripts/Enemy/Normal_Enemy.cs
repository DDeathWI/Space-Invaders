public class Normal_Enemy : Enemy {

    public DetectEnemyEdgeHit EnemyMoveObserver;

    public DetectEnemyEdgeHit.Operation OnHitEdge;

    protected virtual void LateUpdate()
    {
        // Hit Right Edge
        if (transform.position.x + Collider2D.size.x / 2 >= GameController.singleton.rightBorder - 0.2f)
        {
            //false
            EnemyMoveObserver.EventHappens(DetectEnemyEdgeHit.Edge.Right);
            EnemyMoveObserver.AddEvent(DetectEnemyEdgeHit.Edge.Left, OnHitEdge);
        }
        
        // Hit Left Edge
        else if (transform.position.x - Collider2D.size.x / 2 <= GameController.singleton.leftBorder + 0.2f)
        {
            //true
            EnemyMoveObserver.EventHappens(DetectEnemyEdgeHit.Edge.Left);
            EnemyMoveObserver.AddEvent(DetectEnemyEdgeHit.Edge.Right, OnHitEdge);
        }
    }


}
