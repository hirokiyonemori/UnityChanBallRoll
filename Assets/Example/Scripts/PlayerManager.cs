using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{

    private static PlayerManager mInstance;
    private int score = 0;
    private int stageNo = 0;

    private string key1 = "SCORE1"; //ハイスコアの保存先キー
    private string key2 = "SCORE2"; //ハイスコアの保存先キー
    private string key3 = "SCORE3"; //ハイスコアの保存先キー


    public static PlayerManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                //GameObject obj = new GameObject("PlayerManager");
                mInstance = new PlayerManager();

            }
            return mInstance;
        }
        set
        {

        }
    }

    public void Initialize()
    {
        //PlayerPrefs.GetInt(key, 0);
        score = 0;
        stageNo = 0;
    }

    public List<int> GetRanking()
    {
        List<int> data = new List<int>(); 
        data.Add(PlayerPrefs.GetInt(key1, 3));
        data.Add(PlayerPrefs.GetInt(key2, 2));
        data.Add(PlayerPrefs.GetInt(key3, 1));
        return data;
    }
    /// <summary>
    ///　以下のコードでは２位が更新する時に３位のスコアにならない
    /// </summary>
    public void UpdateRanking()
    {
        int score = PlayerPrefs.GetInt(key1, 3);
        bool playerUpdateFlag = false; 
        if( this.score >= score )
        {
            Debug.Log(" スコア１更新");
            PlayerPrefs.SetInt(key2, PlayerPrefs.GetInt(key1, 2));
            PlayerPrefs.SetInt(key1, this.score);
            playerUpdateFlag = true;
        }
        score = PlayerPrefs.GetInt(key2, 2);
        if (this.score >= score && !playerUpdateFlag )
        {
            PlayerPrefs.SetInt(key3, PlayerPrefs.GetInt(key3, 1));
            PlayerPrefs.SetInt(key2, this.score);
            playerUpdateFlag = true;
        }
        score = PlayerPrefs.GetInt(key3, 1);
        if (this.score >= score && !playerUpdateFlag)
        {
            PlayerPrefs.SetInt(key3, this.score);
        }

    }

    public int StageNo { get => stageNo; set => stageNo = value; }

    public void setScore(int n)
    {
        if (n <= 0)n = 0;

        this.score = n;
    }
    public int getScore()
    {
        return this.score;
    }
}
