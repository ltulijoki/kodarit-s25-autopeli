using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int orderIndex = 0;

    void OnTriggerEnter(Collider other)
    {
        PlayerLoopCheck validator = other.GetComponent<PlayerLoopCheck>();
        if (validator != null)
        {
            validator.MarkVisited(orderIndex);
        }
    }
}
