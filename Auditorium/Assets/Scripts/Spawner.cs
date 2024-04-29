using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Spawner : MonoBehaviour
{
    public GameObject _particlePrefab;
    public Transform[] spawnPoints; 
    private float _spawnRadius = 1f;
    private float spawnInterval = 1f;
    private float _chrono = 0f;
    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        _chrono += Time.deltaTime;

        if (_chrono >= spawnInterval)
        {
            Vector2 spawnposition = (Vector2)transform.position + Random.insideUnitCircle * _spawnRadius;
            GameObject Particle = Instantiate( _particlePrefab, spawnposition, Quaternion.identity); ;
            Particle.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
            _chrono = 0f;
            }


    }
   
}
