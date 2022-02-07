using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poses : MonoBehaviour
{
    public GameObject mesenshi;
    public GameObject action1button;
    public GameObject action2button;
    public GameObject action3button;
    public GameObject action4button;

    public bool _random = false;
    public float _threshold = 0.5f;
    public float _interval = 10f;

    private Animator anim;
    private AnimatorStateInfo currentState;
    private AnimatorStateInfo previousState;

    private bool action1move = false;
    private bool action2move = false;
    private bool action3move = false;
    private bool action4move = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;
        StartCoroutine("RandomChange");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetButton("Jump"))
        {
            anim.SetBool("hello", true);
        }

        if (Input.GetKeyDown("up") || Input.GetButton("Jump"))
        {
            anim.SetBool("piece", true);
        }

        if (Input.GetKeyDown("up") || Input.GetButton("Jump"))
        {
            anim.SetBool("waist", true);
        }

        if (Input.GetKeyDown("down"))
        {
            anim.SetBool("idle", true);
        }
        
        if (anim.GetBool("hello"))
        {
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("hello", false);
                previousState = currentState;
            }
        }
        
        if (anim.GetBool("idle"))
        {
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("idle", false);
                previousState = currentState;
            }
        }
        if (anim.GetBool("piece"))
        {
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("piece", false);
                previousState = currentState;
            }
        }
        if (anim.GetBool("waist"))
        {
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("waist", false);
                previousState = currentState;
            }
        }
    }
    public void action1ButtonDown()
    {
        action1move = true;
        //Debug.Log("ボタン1を押した");
        if (action1move == true)
        {
            anim.SetBool("hello", true);
            //Debug.Log("OK");
        }
    }

    public void action2ButtonDown()
    {
        action2move = true;
        if (action2move == true)
        {
            anim.SetBool("idle", true);
        }
    }

    public void action3ButtonDown()
    {
        action3move = true;
        if (action3move == true)
        {
            anim.SetBool("piece", true);
        }
    }

    public void action4ButtonDown()
    {
        action4move = true;
        if (action4move == true)
        {
            anim.SetBool("waist", true);
        }
    }

    IEnumerator RandomChange()
    {
        while (true)
        {
            if (_random)
            {
                float _seed = Random.Range(0.0f, 1.0f);
                if (_seed < _threshold)
                {
                    anim.SetBool("idle", true);
                }
                else if (_seed >= _threshold)
                {
                    anim.SetBool("hello", true);
                }
            }
            yield return new WaitForSeconds(_interval);
        }

    }
}
