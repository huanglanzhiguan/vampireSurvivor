using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Transform sprite;
    public float maxSize, minSize;
    public float speed;
    
    private float _currentSize = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        speed *= Random.Range(0.75f, 1.25f);
        _currentSize = maxSize;
    }

    // Update is called once per frame
    void Update()
    {
        sprite.localScale = Vector3.MoveTowards(sprite.localScale, Vector3.one * _currentSize, 
            speed * Time.deltaTime);
        if (Mathf.Approximately(sprite.localScale.x, maxSize))
        {
            _currentSize = minSize;
        } else if (Mathf.Approximately(sprite.localScale.x, minSize))
        {
            _currentSize = maxSize;
        }
    }
}
