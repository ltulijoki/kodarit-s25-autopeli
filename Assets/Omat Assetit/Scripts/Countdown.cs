using UnityEngine;
using System.Collections;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text uiText;
    public int countDownFrom = 3;
    public float stepSeconds = 1f;

    IEnumerator Start()
    {
        for (int i = countDownFrom; i  > 0; i--)
        {
            uiText.text = i.ToString();
            yield return new WaitForSeconds(stepSeconds);
        }

        uiText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        uiText.text = "";
        uiText.gameObject.SetActive(false);
        GameManager.Instance.Phase = RacePhase.Racing;
    }
}
