using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource _audioSource;
    public Color _offColor = Color.black;
    public Color _onColor = Color.white;
    public SpriteRenderer[] _bars;
    public float volumeChangeRate = 0.1f; 
    public float volumeIncrement = 0.1f;
    public float decayInterval = 1f;

    private float _chrono = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _bars.Length; i++)
        {
            float seuil = (float)i / (float)_bars.Length;
            
            if (_audioSource.volume > seuil)
            {
                // on allume la barre
                _bars[i].color = _onColor;
            }
            else
            {
                // On éteinds la barre
                _bars[i].color = _offColor;
            }
        }
            if (_chrono >= decayInterval)
            {
                _audioSource.volume -= volumeChangeRate * Time.deltaTime;
            }
            else
            {
                _chrono += Time.deltaTime;
            }

        _audioSource.volume -= volumeChangeRate * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Particle"))
        {
            _audioSource.volume += volumeIncrement;
            _chrono = 0f;
        }
    }
}
