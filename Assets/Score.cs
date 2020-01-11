using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    List<int> data = new List<int>();
    public List<Text> rankingList = new List<Text>();
    // Start is called before the first frame update
    void Start()
    {

        PlayerManager.Instance.UpdateRanking();
        data = PlayerManager.Instance.GetRanking();
        for(int i = 0; i < data.Count; i ++ )
        {
            rankingList[i].text = data[ i ].ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void ReturnToButton()
    {
        SceneManager.LoadScene("Title");
    }
}
