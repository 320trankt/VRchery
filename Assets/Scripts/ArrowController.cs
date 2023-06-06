using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;

    [SerializeField]
    private float arrowMaxSpeed = 10;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip string_pull;
    [SerializeField]
    private AudioClip shoot_arrow;

    private GameController game;
    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
        audioSource.clip = string_pull;
        audioSource.Play();
    }
    public void ReleaseArrow(float strength)
    {
        Debug.Log("released");
        midPointVisual.SetActive(false);
        GameObject arrow = Instantiate(arrowPrefab);
        game.AddArrow(arrow);
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = midPointVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
        audioSource.clip = shoot_arrow;
        audioSource.Play();
    }
    void Start()
    {
        game = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
