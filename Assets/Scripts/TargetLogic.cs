using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetLogic : MonoBehaviour
{
    //[SerializeField] public Transform game_controller;
    [SerializeField] public int point_value;
    [SerializeField] private TMP_Text ScoreBanner;

    private GameController game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        //game = game_controller.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        game.score(point_value);
        //ScoreBanner.text = "Score:\n" + game.current_score;
        if (point_value == 100){
            ScoreBanner.text = "Score!\n" + point_value + " points\nBullseye!";
        }else{
            ScoreBanner.text = "Score!\n" + point_value + " points";
        }
    }
}
