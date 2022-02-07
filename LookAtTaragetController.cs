using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTaragetController : MonoBehaviour
{
    Animator anim;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        targetPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        targetPos = cameraPos;
    }
    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(1.0f, 0.5f, 0.8f, 0.0f, 0f);
        anim.SetLookAtPosition(this.targetPos);
    }
}
