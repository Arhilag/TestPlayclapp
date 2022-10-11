using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private float _speed;
    private float _distance;
    
    public void SetCubeSettings(float speed, float distance)
    {
        _speed = speed;
        _distance = distance;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (transform.position.z < _distance)
        {
            transform.position += new Vector3(0,0,0.1f*_speed);
            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
    }
}
