using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float hitWaitTime;
    
    private Transform _player;
    private Rigidbody2D _rb;

    private float _hitCounter;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitCounter > 0)
        {
            _hitCounter -= Time.deltaTime;
        }
        _rb.velocity = (_player.position - transform.position).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_hitCounter <= 0 && other.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.Instance.GetDamage(5);
            _hitCounter = hitWaitTime;
        }
    }
}
