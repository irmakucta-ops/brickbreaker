using UnityEngine;

public class FXManager : MonoBehaviour
{
    public ParticleSystem impactPS;
    public ParticleSystem brickDestroyPS;


    public void PlayImpactPS(Vector3 pos, Vector3 dir, Color color)
    {
        var newPS = Instantiate(impactPS);
        newPS.transform.position =pos;
        newPS.transform.LookAt(pos + dir);
        var main =newPS.main;
        main.startColor = color;
        newPS.Play();
    }

    public void PlayBrickDestroyPS(Vector3 pos)

    {
        var newPS =Instantiate(brickDestroyPS);
        newPS.transform.position =pos;
        newPS.Play();
    
    }

}
