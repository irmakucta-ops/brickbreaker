using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public Powerup powerupPrefab;

    public void SummonPowerUp(Vector3 pos)
    {
        var newPowerup =Instantiate(powerupPrefab);
        newPowerup.transform.position = pos;
    }
}
