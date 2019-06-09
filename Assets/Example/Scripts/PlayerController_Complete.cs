using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController_Complete : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    int count;
    public Text countText;
    AudioSource getSE;
    public GameObject unityChanObj;

    private Vector3 Player_pos;

    // Use this for initialization
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        count = PlayerManager.Instance.getScore();
        SetCountText();
        getSE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(moveH, 0, moveV);
        rb.AddForce(move * speed);

        Vector3 diff = unityChanObj.transform.position - Player_pos; //プレイヤーがどの方向に進んでいるかがわかるように、初期位置と現在地の座標差分を取得
        if (diff.magnitude > 0.01f　&& diff.x != 0 ) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
        {
            unityChanObj.transform.rotation = Quaternion.LookRotation(diff);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
        }

        Player_pos = unityChanObj.transform.position; //プレイヤーの位置を更新

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("A"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            getSE.Play();
            PlayerManager.Instance.setScore(count);
        }
        else if (other.gameObject.CompareTag("B"))
        {
            //スコアを-5にする
            int score =PlayerManager.Instance.getScore() -5;
            PlayerManager.Instance.setScore(score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void SetCountText()
    {
        countText.text = "ゲット数：" + count.ToString();
    }
}
