using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine; 

public class Level : MonoBehaviour
{
    private GameDirector _gameDirector;
    private List<Brick> _bricks = new List<Brick>();

    public Brick brickPrefab;

    public List<Transform> availableSpawnPositions;
    public void StartLevel(GameDirector gameDirector)
     
    {
        _gameDirector = gameDirector;
        _bricks = GetComponentsInChildren<Brick>().ToList();
        GenerateParametricLevel();
     
    }

    public void BrickDestroyed(Brick brick)
    {
        _bricks.Remove(brick);
        if (_bricks.Count == 0)
        {
            _gameDirector.Win();
        }
        else
        {
            if(Random.value <.2f)
            {
                _gameDirector.powerupManager.SummonPowerUp(brick.transform.position);
            }
           
        }
    }
    void GenerateParametricLevel()
    {
        var state = Random.state;
        Random.InitState(_gameDirector.levelManager.levelNo);

        var brickCount = Mathf.Min(_gameDirector.levelManager.levelNo, availableSpawnPositions.Count - 5);

        for (int i = 0; i < brickCount; i++)
        {
            var chosenSpawnPos = availableSpawnPositions[Random.Range(0, availableSpawnPositions.Count)];

            var newBrick = Instantiate(brickPrefab, transform);
            newBrick.transform.position = chosenSpawnPos.position;
            newBrick.StartBrick(_gameDirector);
            _bricks.Add(newBrick);

            availableSpawnPositions.Remove(chosenSpawnPos);
        }
        
        Random.state = state;
    }
}
