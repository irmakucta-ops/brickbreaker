using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameDirector _gameDirector;

    public float speed;
    private Vector3 _dir = new Vector3(0, 1, 0);
    private Rigidbody2D _rb;
    public Color playerParticleColor;
    public float xDirMultiplier;

    public void StartBall(GameDirector gameDirector)
    {
        _rb = GetComponent<Rigidbody2D>();
        _gameDirector = gameDirector;
        _dir.x = Random.Range(-.5f, .5f);
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _dir.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        _dir = Vector3.Reflect(_dir, collision.contacts[0].normal);
        if (_dir.y < 0 && _dir.y > -.1f)

        {
            _dir.y = .1f;
        }

    else if (_dir.y > 0 && _dir.y < .1f)

        {
            _dir.y = .1f;
        }
            _gameDirector.audioManager.PlayImpactAS();
        var particleColor = Color.white;

        if (collision.gameObject.CompareTag("Brick"))
        { 
            collision.gameObject.GetComponentInParent<Brick>().GetHit(1);
             _gameDirector.audioManager.PlayBrickHitAS();
            particleColor = Color.yellow;
        }
        if (collision.gameObject.CompareTag("BottomBorder"))
        {
            _gameDirector.levelManager.BallDestroyed(this);
            Destroy(gameObject);
            _gameDirector.audioManager.PlayFailAS();
            particleColor = Color.red;  
        }
        if (collision.gameObject.CompareTag("PlayerPaddle"))
        {
            if ((transform.position.y < -4f && _dir.y > 0) || (  transform.position.y > -4f && _dir.y < 0))
            {
                _dir.y = -1;
            }
            particleColor = playerParticleColor;
            _dir.x = (transform.position.x - collision.transform.position.x) * xDirMultiplier;
        }
       _gameDirector.fxManager.PlayImpactPS(collision.contacts[0].point, collision.contacts[0].normal, particleColor);
    }

    public void StopBall()
    {
      _dir = Vector3.zero;
        transform.DOScale(0, 2f).SetEase(Ease.InBack);
    }
}
  
