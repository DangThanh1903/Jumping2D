using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    private bool isMoving = true;
    private float mtimer = 0f;
    private float jtimer = 0f;
    private bool lr = true;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (isMoving) {
            if (lr) {
                mtimer += Time.deltaTime;
                isMoving = (mtimer >= 3f) ? false : true;
                tf.position += Vector3.right * Time.deltaTime;
                jtimer = 0f;
            }
            else {
                mtimer += Time.deltaTime;
                isMoving = (mtimer >= 3f) ? false : true;
                tf.position += Vector3.left * Time.deltaTime;
                jtimer = 0f;
            }
        }
        else {
            if (jtimer >= 1f) {
                lr = !lr;
                isMoving = true;
            }
            else {
                isMoving = false;
            }
            if (jtimer >= 0f && jtimer < 0.5f){
                jtimer += Time.deltaTime;
                tf.position += new Vector3(0, 1, 0) * Time.deltaTime;
            }
            else {
                jtimer += Time.deltaTime;
                tf.position -= new Vector3(0, 1, 0) * Time.deltaTime;
                mtimer = 0f;
            }
            
        }
    }
}
