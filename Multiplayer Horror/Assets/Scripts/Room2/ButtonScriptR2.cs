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
    public GameObject elevator2;
    public GameObject elevator3;
    public GameObject elevator4;
    public GameObject elevator21;
    public GameObject elevator22;
    public GameObject elevator23;
    public GameObject elevator24;
    public GameObject button21;
    public GameObject button22;
    public GameObject button23;
    public GameObject button24;
    public GameObject buttonRoomThree;
    public GameObject slidingWall;
    private PhotonView PV;

    private Animation animationOne;
    private Animation animationTwo;
    private Animation animationThree;
    private Animation animationFour;
    private Animation animationElevatorButton;
    private Animation animationDoor;
    private Animation animationElevator;
    private Animation animationButton21;
    private Animation animationButton22;
    private Animation animationButton23;
    private Animation animationButton24;
    private Animation animationButtonRoomThree;
    private Animation animationSlidingWall;

    private Animation animationElevator22;
    // Start is called before the first frame update
    void Start()
    {
        
        PV = GetComponent<PhotonView>();
        animationOne = button1.GetComponent<Animation>();
        animationTwo = button2.GetComponent<Animation>();
        animationThree = button3.GetComponent<Animation>();
        animationFour = button4.GetComponent<Animation>();
        animationButton21 = button21.GetComponent<Animation>();
        animationButton22 = button22.GetComponent<Animation>();
        animationButton23 = button23.GetComponent<Animation>();
        animationButton24 = button24.GetComponent<Animation>();
        animationElevatorButton = elevatorButton1.GetComponent<Animation>();
        animationDoor = door.GetComponent<Animation>();
        animationElevator = elevator.GetComponent<Animation>();
        animationElevator22 = elevator22.GetComponent<Animation>();
        animationButtonRoomThree = buttonRoomThree.GetComponent<Animation>();
        animationSlidingWall = slidingWall.GetComponent<Animation>();
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
                Destroy(elevator4);
                break;
            case "ButtonTwo":
                Debug.Log("Button Two");
                animationTwo.Play();
                Destroy(elevator3);
                break;
            case "ButtonThree":
                Debug.Log("Button three");
                animationThree.Play();
                Destroy(elevator2);
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
            case "ButtonOne2":
                animationButton21.Play();
                Destroy(elevator21);
                break;
            case "ButtonTwo2":
                animationButton22.Play();
                animationElevator22.Play();
                
                break;
            case "ButtonThree2":
                animationButton23.Play();
                Destroy(elevator23);
                break;
            case "ButtonFour2":
                animationButton24.Play();
                Destroy(elevator24);
                break;
            case "ButtonRoomThree":
                animationButtonRoomThree.Play();
                animationSlidingWall.Play();
                break;
        }
    }
}