using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private float startPos, moving = 0, length;
    [SerializeField] private float speed = 5f;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moving += speed * Time.deltaTime * parallaxEffect;
        if (length < startPos + moving){
            moving = 0;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        transform.position = new Vector3(startPos + moving, transform.position.y, transform.position.z);
    }
}
