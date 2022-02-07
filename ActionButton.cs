using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionButton : MonoBehaviour
{
    public GameObject mesenshi;
    public GameObject action1button;
    public GameObject action2button;
    private Animator anim;                      // Animatorへの参照
    private AnimatorStateInfo currentState;     // 現在のステート状態を保存する参照
    private AnimatorStateInfo previousState;    // ひとつ前のステート状態を保存する参照
    public bool _random = false;                // ランダム判定スタートスイッチ
    public float _threshold = 0.5f;             // ランダム判定の閾値
    public float _interval = 10f;
    private bool action1move = false;
    private bool action2move = true;

    void Start()
    {
        //setButton();
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;
        // ランダム判定用関数をスタートする
        StartCoroutine("RandomChange");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("next", true);
        }
        if (Input.GetKeyDown("up") || Input.GetButton("Jump"))
        {
            // ブーリアンNextをtrueにする
            anim.SetBool("next", true);
        }

        // ↓キーが押されたら、ステートを前に戻す処理
        if (Input.GetKeyDown("down"))
        {
            // ブーリアンBackをtrueにする
            anim.SetBool("Back", true);
        }

        // "Next"フラグがtrueの時の処理
        if (anim.GetBool("next"))
        {
            // 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("next", false);
                previousState = currentState;
            }
        }

        // "Back"フラグがtrueの時の処理
        if (anim.GetBool("Back"))
        {
            // 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("Back", false);
                previousState = currentState;
            }
        }
    }

    public void action1ButtonDown()
    {
        action1move = true;
        Debug.Log("ボタン1を押した");
        if (action1move == true)
        {
            anim.SetBool("hello", true);
            Debug.Log("OK");
        }
    }
    
    public void action2ButtonDown()
    {
        action2move = true;
        if (action2move == true)
        {
            anim.SetBool("next", true);
        }
    }
    IEnumerator RandomChange()
    {
        // 無限ループ開始
        while (true)
        {
            //ランダム判定スイッチオンの場合
            if (_random)
            {
                // ランダムシードを取り出し、その大きさによってフラグ設定をする
                float _seed = Random.Range(0.0f, 1.0f);
                if (_seed < _threshold)
                {
                    anim.SetBool("Back", true);
                }
                else if (_seed >= _threshold)
                {
                    anim.SetBool("Next", true);
                }
            }
            // 次の判定までインターバルを置く
            yield return new WaitForSeconds(_interval);
        }

    }
}
