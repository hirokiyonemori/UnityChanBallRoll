using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalChecker_Complete : MonoBehaviour
{
    public GameObject unityChan;
    public AudioSource gameBgm;
    public AudioSource goalBgm;

    //public GameObject retryButton;
    public GameObject nextButton;

    public GameObject textObj;
    //public PlayerController_Complete playerController_Complete;

    private bool goalFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        //retryButton.SetActive(false);
        nextButton.SetActive(false);
        textObj.SetActive(false);
        goalFlag = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && goalFlag )
        {
            NextStage();
            //Debug.Log(" Jump.Instance.StageNo " + PlayerManager.Instance.StageNo);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        unityChan.transform.LookAt(Camera.main.transform);
        unityChan.GetComponent<Animator>().SetTrigger("Goal");

        gameBgm.Stop();
        goalBgm.Play();

        //プレイヤーがやられた時に表示するように修正
        //retryButton.SetActive(true);
        //nextButton.SetActive(true);
        textObj.SetActive(true);
        goalFlag = true;

    }

    public void RetryStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextStage()
    {
        //Debug.Log(" PlayerManager.Instance.StageNo " + PlayerManager.Instance.StageNo);
        switch (PlayerManager.Instance.StageNo)
        {
            case 0:
                SceneManager.LoadScene("Stage2");
                break;
            case 1:
                SceneManager.LoadScene("Stage3");
                break;
            case 2:
                SceneManager.LoadScene("Score");
                break;

        }
        PlayerManager.Instance.StageNo++;

    }
}
