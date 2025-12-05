using UnityEngine;
using System.Collections;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text uiText;
    public int countDownFrom = 3;
    public float stepSeconds = 1f;
    public AudioClip pling;
    public AudioClip goSFX;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        for (int i = countDownFrom; i  > 0; i--)
        {
            uiText.text = i.ToString();
            AudioManager.Instance.PlaySFX(pling);
            yield return new WaitForSeconds(stepSeconds);
        }

        uiText.text = "GO!";
        AudioManager.Instance.PlaySFX(goSFX);
        yield return new WaitForSeconds(0.5f);
        uiText.text = "";
        uiText.gameObject.SetActive(false);
        GameManager.Instance.Phase = RacePhase.Racing;
    }
}
