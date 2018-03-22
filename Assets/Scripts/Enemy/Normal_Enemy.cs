public class Normal_Enemy : Enemy {

    public ObserverDetectEnemyHittingScreenEdge EnemyMoveObserver;

    public ObserverDetectEnemyHittingScreenEdge.Operation OnHitEdge;

    protected virtual void LateUpdate()
    {
        // Hit Right Edge
        if (transform.position.x + Collider2D.size.x / 2 >= GameController.singleton.rightBorder - 0.2f)
        {
            //Hit Right Edge
            EnemyMoveObserver.EventHappens(ObserverDetectEnemyHittingScreenEdge.Edge.Right);

            //Detect Hit Left Edge
            EnemyMoveObserver.AddEvent(ObserverDetectEnemyHittingScreenEdge.Edge.Left, OnHitEdge);
        }
        
        // Hit Left Edge
        else if (transform.position.x - Collider2D.size.x / 2 <= GameController.singleton.leftBorder + 0.2f)
        {

            //Hit Left Edge
            EnemyMoveObserver.EventHappens(ObserverDetectEnemyHittingScreenEdge.Edge.Left);

            //Detect Hit Left Edge
            EnemyMoveObserver.AddEvent(ObserverDetectEnemyHittingScreenEdge.Edge.Right, OnHitEdge);
        }
    }


}
