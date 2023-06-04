using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    [SerializeField] public GameObject[] arrows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        StartCoroutine(ShootArrows());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShootArrows(){
        while (arrows.Count() > 0){
            yield return new WaitForSeconds(3f);
            arrows.First().GetComponent<ArrowInteraction>().ReleaseArrow(10);
            arrows = arrows.Skip(1).ToArray();
        }
    }
}
