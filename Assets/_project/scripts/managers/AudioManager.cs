using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource impactAS;
    public AudioSource brickHitAS;
    public AudioSource failAS;

        private void Update()

    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayImpactAS();
        }
    }

    public void PlayImpactAS()
    {
        impactAS.Play();
    }

    public void PlayBrickHitAS()
    {
        brickHitAS.Play();
    }
    public void PlayFailAS()
    {
        failAS.Play();
    }
}
