using System.Collections;
using System.Collections.Generic;
using Controller;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float JumpBoost = 1.6f;
    [SerializeField] private ScriptableStats script;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            script.JumpPower *= JumpBoost;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            script.JumpPower /= JumpBoost;
        }
    }
}
