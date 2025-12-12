using UnityEngine;
using TMPro;

public class Referee : MonoBehaviour
{
    public TMP_Text resultText;
    public TMP_Text lapCountText;
    public int lapCount = 3;
    private bool winnerDeclared = false;

    void Start()
    {
        resultText.text = "";
        lapCountText.text = $"LAP: 1 / {lapCount}";
    }

    void OnTriggerEnter(Collider car)
    {
        CarIdentify id = car.GetComponent<CarIdentify>();
        string winnerName = id.displayName;

        LapCounter lap = car.GetComponent<LapCounter>();

        if (id.kind == CarKind.Player)
        {
            PlayerLoopCheck validator = car.GetComponent<PlayerLoopCheck>();
            if (validator == null) return;

            if (!validator.AllVisitedThisLap)
            {
                return;
            }

            validator.ResetLap();
            lapCountText.text = $"LAP: {lap.lapsCompleted + 1} / {lapCount}";
        }

        lap.lapsCompleted++;

        if (!winnerDeclared && lap.lapsCompleted >= lapCount)
        {
            resultText.text = $"WINNER: {winnerName}";
            GameManager.Instance.Phase = RacePhase.Finished;
            winnerDeclared = true;
        }
    }
}
