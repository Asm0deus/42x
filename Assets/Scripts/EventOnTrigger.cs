using UnityEngine;
using UnityEngine.Events;

public class EventOnTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _gameOverEvent;
    private void OnTriggerEnter(Collider other)
    {
        GameState state = other.GetComponent<GameState>();
        if(state)
        {
            _gameOverEvent.Invoke();
        }
    }
}
