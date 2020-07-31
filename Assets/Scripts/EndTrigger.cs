using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameController gameController;

    void OnTriggerEnter(Collider other)
    {
        gameController.CompleteLevel();
    }
}
