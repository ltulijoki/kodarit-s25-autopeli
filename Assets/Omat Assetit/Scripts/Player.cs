using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    public AudioClip engineSFX;

    private bool isMovingSoundPlaying = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Phase != RacePhase.Racing)
        {
            AudioManager.Instance.StopSFX();
            return;
        }

        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        if (move != 0 && !isMovingSoundPlaying)
        {
            AudioManager.Instance.PlaySFXLoop(engineSFX);
            isMovingSoundPlaying = true;
        }
        else if (move == 0)
        {
            AudioManager.Instance.StopSFX();
            isMovingSoundPlaying = false;
        }
    }
}
