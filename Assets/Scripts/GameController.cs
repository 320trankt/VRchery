using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int current_score = 0;
    public int max_score = 1000;
    [SerializeField] private GameObject teleport_tutorial;
    [SerializeField] private GameObject bow_tutorial;
    [SerializeField] private GameObject button_tutorial;
    private List<GameObject> arrows = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        bow_tutorial = GameObject.FindWithTag("Bow Tutorial");
        teleport_tutorial = GameObject.FindWithTag("TP Tutorial");
        button_tutorial = GameObject.FindWithTag("Button Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void score(int value){
        current_score += value;
        Debug.Log("Score!" + value + " points.");
    }

    public void disable_teleport_tutorial(){
        teleport_tutorial.SetActive(false);
    }

    public void disable_bow_tutorial(){
        bow_tutorial.SetActive(false);
    }

    public void disable_button_tutorial(){
        button_tutorial.SetActive(false);
    }

    public void AddArrow(GameObject arrow){
        arrows.Add(arrow);
    }

    public void clearArrows(){
        bool StillWorking = true;
        do{
            StillWorking = false;
            for (int i = 0; i < arrows.Count; i++){
                GameObject.Destroy(arrows[i]);
                arrows.Remove(arrows[i]);
                StillWorking = true;
                break;
            }
        }
        while(StillWorking);
    }
}
