using UnityEngine;

public class Referee : MonoBehaviour
{
    private bool winnerDeclared = false;

    void OnTriggerEnter(Collider car)
    {
        CarIdentify id = car.GetComponent<CarIdentify>();
        string winnerName = id.displayName;

        if (id.kind == CarKind.Player)
        {
            PlayerLoopCheck validator = car.GetComponent<PlayerLoopCheck>();
            if (validator == null) return;

            if (!validator.AllVisitedThisLap)
            {
                Debug.Log("Pelaaja ylitti maalin, mutta kaikkia checkpointteja ei ole käyty -> ei voittoa");
                return;
            }
        }

        if (!winnerDeclared)
        {
            Debug.Log($"Winner: {winnerName}");
            winnerDeclared = true;
        }
    }
}
