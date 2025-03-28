using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            animator.enabled = false;
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall() {
        yield return new WaitForSeconds(fallDelay);
        
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
