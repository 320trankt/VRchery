using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int current_score = 0;
    public int max_score = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void score(int value){
        current_score += value;
        Debug.Log("Score!" + value + " points.");
    }
}
