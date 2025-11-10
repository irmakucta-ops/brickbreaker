using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private GameDirector _gameDirector;
    public int startHealth;
    private int _currentHealth;

    public SpriteRenderer Sprite;

    public TextMeshPro healthText;





    public void StartBrick(GameDirector gameDirector)
    {
        _gameDirector = gameDirector;
        var levelNo = _gameDirector.levelManager.levelNo;
        startHealth = Random.Range(1,6) +levelNo/10;
        _currentHealth = startHealth;
        healthText.text = _currentHealth.ToString();
    }

    public void GetHit(int damage)
    {

        _currentHealth -= damage;
        healthText.text = _currentHealth.ToString();
        Sprite.transform.DOScale(.25f, .1f).SetLoops(2, LoopType.Yoyo);
        if (_currentHealth <= 0)
        {
            _gameDirector.fxManager.PlayBrickDestroyPS(transform.position);
            GetComponentInParent<Level>().BrickDestroyed(this);
            gameObject.SetActive(false);
        }
    }
}
 