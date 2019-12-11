using Photon.Pun;
using UnityEngine;

public class ButtonScriptR2 : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject elevatorButton1;
    public GameObject door;
    public GameObject elevator;
    private PhotonView PV;

    private Animation animationOne;
    private Animation animationTwo;
    private Animation animationThree;
    private Animation animationFour;
    private Animation animationElevatorButton;
    private Animation animationDoor;
    private Animation animationElevator;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        animationOne = button1.GetComponent<Animation>();
        animationTwo = button2.GetComponent<Animation>();
        animationThree = button3.GetComponent<Animation>();
        animationFour = button4.GetComponent<Animation>();
        animationElevatorButton = elevatorButton1.GetComponent<Animation>();
        animationDoor = door.GetComponent<Animation>();
        animationElevator = elevator.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
        }
        else if (stream.IsReading)
        {
            //Network read this, others see
        }
    }

    public void Button_pressedR2(string hit)
    {
        PV.RPC("Button_Pressed_Network_R2", RpcTarget.All ,hit);
    }
    
    [PunRPC]
    void Button_Pressed_Network_R2(string hit)
    {
        switch (hit)
        {
            case "ButtonOne":
                Debug.Log("Button one");
                animationOne.Play();
                break;
            case "ButtonTwo":
                Debug.Log("Button Two");
                animationTwo.Play();
                break;
            case "ButtonThree":
                Debug.Log("Button three");
                animationThree.Play();
                break;
            case "ButtonFour":
                animationFour.Play();
                animationDoor.Play();
                Debug.Log("Button four");
                break;
            case "ButtonElevator":
                animationElevatorButton.Play();
                animationElevator.Play();
                Debug.Log("Elevator");
                break;
        }
    }
}