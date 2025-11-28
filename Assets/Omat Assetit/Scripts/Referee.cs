using UnityEngine;
using TMPro;

public class Referee : MonoBehaviour
{
    public TMP_Text resultText;
    private bool winnerDeclared = false;

    void Start()
    {
        resultText.text = "";
    }

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
                return;
            }
        }

        if (!winnerDeclared)
        {
            resultText.text = $"WINNER: {winnerName}";
            GameManager.Instance.Phase = RacePhase.Finished;
            winnerDeclared = true;
        }
    }
}
