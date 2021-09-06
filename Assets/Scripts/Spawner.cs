using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float _nextSpawnTime;
    [SerializeField] float _delay = 5f;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] Enemy[] _enemies;
    void Update()
    {
        if (ShouldSpawn())
            Spawn();
    }

    void Spawn()
    {
        _nextSpawnTime = Time.time + _delay;
        Transform spawnpoint = ChooseSpawner();
        Enemy enemy = ChooseEnemy();
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
    }

    Enemy ChooseEnemy()
    {
        int randomindex = UnityEngine.Random.Range(0, _enemies.Length);
        var enemy = _enemies[randomindex];
        return enemy;
    }

    Transform ChooseSpawner()
    {
        int randomindex = UnityEngine.Random.Range(0, _spawnPoints.Length);
        var spawnpoint = _spawnPoints[randomindex];
        return spawnpoint;
    }

    bool ShouldSpawn()
    {
        return Time.time >= _nextSpawnTime;
    }
}
