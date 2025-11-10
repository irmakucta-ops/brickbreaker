using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public float maxSpeed;
    private Vector3 _targetPos;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        var xPos = (Input.mousePosition / Screen.width * 4f).x - 2;

        xPos = Mathf.Clamp(xPos, -2f, 2f);

        _rb.position = new Vector3(xPos, -4, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            gameDirector.levelManager.BallPowerUpCollected(collision.transform.position);

        }
    }

}
