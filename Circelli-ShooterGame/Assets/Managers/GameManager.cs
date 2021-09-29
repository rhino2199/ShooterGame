/****
 * Created by: Ryan Circelli
 * Date Created: Sept 29, 2021
 * 
 * Last Edited By: Ryan Circelli
 * Last Updated Sept 29,2021
 * 
 * Description:Game manager to control global game behaviours
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Variables
    #region GameManager Sigleton
    static GameManager gm;
    public static GameManager GM
    {
        get { return gm; }
    }

    void CheckGameManagerIsInScene()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    public static int Score;
    public string ScorePrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text GameOverText = null;
    public GameObject Player;
    //public static bool IsPlayerDead = false; set to true



    private void Awake()
    {
        CheckGameManagerIsInScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }

       /* if (Player == null)
        {
            GameOver();
        }
       */
       // if (IsPlayerDead) { GameOver(); }
    }


    public static void GameOver()
    {
        if(gm.GameOverText != null)
        {
            gm.GameOverText.gameObject.SetActive(true);
        }
    }
}
