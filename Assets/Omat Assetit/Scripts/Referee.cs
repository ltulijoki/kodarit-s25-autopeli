using UnityEngine;

public class Referee : MonoBehaviour
{
    void OnTriggerEnter(Collider car)
    {
        CarIdentify id = car.GetComponent<CarIdentify>();
        string winnerName = id.displayName;
        Debug.Log($"Winner: {winnerName}");
    }
}
