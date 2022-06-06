using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    WalkToPointA,
    WalkToPointB,
    Dead
}
public class Enemy : MonoBehaviour
{
    [Space(10)]
    [Header("Enemy")]
    [SerializeField] private EnemyState _currentEnemyState;

    [SerializeField] private GameState _gameState;
    [SerializeField] private int _rewardEnemy = 1;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    public void Start()
    {
        _pointA.parent = null;
        _pointB.parent = null;
        _gameState = FindObjectOfType<GameState>();
    }
    private void Update()
    {
        switch (_currentEnemyState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.WalkToPointA:
                _navMeshAgent.SetDestination(_pointA.position);
                if (Vector3.Distance(transform.position, _pointA.position) < 0.2f)
                {
                    SetState(EnemyState.WalkToPointB);
                }
                break;
            case EnemyState.WalkToPointB:
                _navMeshAgent.SetDestination(_pointB.position);
                if (Vector3.Distance(transform.position, _pointB.position) < 0.2f)
                {
                    SetState(EnemyState.WalkToPointA);
                }
                break;
            case EnemyState.Dead:
                break;
            default:
                break;
        }
    }
    public void SetState(EnemyState state)
    {
        _currentEnemyState = state;
        switch (_currentEnemyState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.WalkToPointA:
                _navMeshAgent.SetDestination(_pointA.position);
                break;
            case EnemyState.WalkToPointB:
                _navMeshAgent.SetDestination(_pointB.position);
                break;
            case EnemyState.Dead:
                _navMeshAgent.isStopped = true;
                _gameState.UpdateScore(_rewardEnemy);
                Destroy(gameObject);
                Debug.Log("Враг - " + transform.root.gameObject.name + " убит.");
                break;
            default:
                break;
        }
    }
}
