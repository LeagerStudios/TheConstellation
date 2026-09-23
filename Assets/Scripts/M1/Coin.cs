using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if(transform.position.x >= -5)
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Player());
        }
    }

    public IEnumerator Player()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
