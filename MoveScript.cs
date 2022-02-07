using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("bow");
            Debug.Log("ボタン1を押した");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("hello");
        }
    }
}
