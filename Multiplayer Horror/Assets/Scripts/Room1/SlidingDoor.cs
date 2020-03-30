using Photon.Pun;
using UnityEngine;


public class SlidingDoor : MonoBehaviour
{
    public GameObject doorLeft;

    public GameObject doorRight;

    private Animation doorRightOpen;
    private Animation doorLeftOpen;
    private Animation doorRightClose;
    private Animation doorLeftClose;

    // Start is called before the first frame update
    void Start()
    {
        doorRightOpen = doorRight.GetComponent<Animation>();
        doorLeftOpen = doorLeft.GetComponent<Animation>();
        doorRightClose = doorRight.GetComponent<Animation>();
        doorLeftClose = doorLeft.GetComponent<Animation>();
    }

    // Update is called once per frame


    [PunRPC]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorLeftOpen.Play("DoorLeft");
            doorRightOpen.Play("DoorRight");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorRightClose.Play("DoorRightClose");
            doorLeftClose.Play("DoorLeftClose");
        }
    }
}