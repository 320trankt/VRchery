using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRot : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private bool inAir = true;
    private Vector3 lastPosition = Vector3.one;
    [SerializeField] private Transform tipPosition;
    private AudioSource audioSource;
    [SerializeField] private AudioClip impact;

    private void Awake(){
        this.rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        this.lastPosition = Vector3.zero;
        this.rb.interpolation = RigidbodyInterpolation.Interpolate;
        StartCoroutine(RotateWithVelocity());
    }
    private void FixedUpdate()
    {
        if (this.inAir)
        {
            this.CheckCollision();
            this.lastPosition = tipPosition.position;
        }
        //transform.forward = Vector3.Slerp(transform.forward, rb.velocity.normalized, Time.fixedDeltaTime);
    }

    private void CheckCollision()
    {
        if (Physics.Linecast(lastPosition, tipPosition.position, out RaycastHit hitInfo))
        {
            if ((hitInfo.collider.tag == "Bow") || (hitInfo.collider.tag == "Arrow") || (hitInfo.collider.tag == "XRInteractor")){
                Debug.Log("Arrow collided with arrow, bow, or XR Interactor, ignoring collision");
            }else{
                audioSource.clip = impact;
                audioSource.Play();
                if (hitInfo.transform.TryGetComponent(out TargetLogic target)){
                    this.rb.interpolation = RigidbodyInterpolation.None;
                    //this.transform.parent = hitInfo.transform;
                    target.AddPoint();
                }
                /* else if (hitInfo.transform.TryGetComponent(out Rigidbody body))
                {
                    this.rb.interpolation = RigidbodyInterpolation.None;
                    this.transform.parent = hitInfo.transform;
                    body.AddForce(rb.velocity, ForceMode.Impulse);
                } */
                this.StopArrow();
            }
        }
    }


    private void SetPhysics(bool usePhysics){
        this.rb.useGravity = usePhysics;
        this.rb.isKinematic = !usePhysics;
    }
    private void StopArrow()
    {
        this.inAir = false;
        this.SetPhysics(false);
    }

    private IEnumerator RotateWithVelocity()
    {
        yield return new WaitForFixedUpdate();
        while(this.inAir)
        {
            Quaternion newRotation = Quaternion.LookRotation(rb.velocity);
            this.transform.rotation = newRotation;
            yield return null;
        }
    }
}
