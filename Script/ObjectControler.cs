using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platsformcon : MonoBehaviour
{
    public Transform posA, posB;
    [SerializeField] float speed = 1.5f;
    private SpriteRenderer objectSR;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = posA.position;
        objectSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f){
            targetPos = posB.position;
            objectSR.flipX = !objectSR.flipX;
        }
        if (Vector2.Distance(transform.position, posB.position) < .1f){
            targetPos = posA.position;
            objectSR.flipX = !objectSR.flipX;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.transform.SetParent(null);
        }
    }
}
