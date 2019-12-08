using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ButtonScript : MonoBehaviourPunCallbacks, IPunObservable

{
    private static Queue<int> selectedColors = new Queue<int>();
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject reset;
    public GameObject execute;
    public GameObject slidingDoor;
    public GameObject slidingDoor2;
    public AudioClip wrong;
    public AudioClip right;
    private Animation animationSlidingDoor;
    private Animation animationSlidingDoor2;
    private Animation animationOne;
    private Animation animationTwo;
    private Animation animationThree;
    private Animation animationFour;
    private Animation animationFive;
    private Animation animationSix;
    private Animation animationSeven;
    private Animation animationEight;
    private Animation animationReset;
    private Animation animationExecute;
    private AudioSource soundExecute;
    private PhotonView PV;


    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        animationSlidingDoor2 = slidingDoor2.GetComponent<Animation>();
        animationSlidingDoor = slidingDoor.GetComponent<Animation>();
        soundExecute = execute.GetComponent<AudioSource>();
        animationExecute = execute.GetComponent<Animation>();
        animationReset = reset.GetComponent<Animation>();
        animationEight = button8.GetComponent<Animation>();
        animationSeven = button7.GetComponent<Animation>();
        animationSix = button6.GetComponent<Animation>();
        animationFive = button5.GetComponent<Animation>();
        animationFour = button4.GetComponent<Animation>();
        animationThree = button3.GetComponent<Animation>();
        animationTwo = button2.GetComponent<Animation>();
        animationOne = button1.GetComponent<Animation>();
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

    // Update is called once per frame
    void Update()
    {
    }

    private void DeQueueColor()
    {
        if (selectedColors.Count > 2)
        {
            selectedColors.Dequeue();
        }
    }
    public void Button_PressedR1(string hit)
    {
        PV.RPC("button_Pressed_Network", RpcTarget.All ,hit);
    }
    
    [PunRPC]
    void button_Pressed_Network(string hit)
    {
        switch (hit)
            {
                case "ButtonOne":
                    Debug.Log("Button 1");
                    animationOne.Play();
                    selectedColors.Enqueue(1);
                    DeQueueColor();
                    break;
                case "ButtonTwo":
                    Debug.Log("Button 2");
                    animationTwo.Play();
                    selectedColors.Enqueue(2);
                    DeQueueColor();
                    break;
                case "ButtonThree":
                    Debug.Log("Button 3");
                    animationThree.Play();
                    selectedColors.Enqueue(3);
                    DeQueueColor();
                    break;
                case "ButtonFour":
                    Debug.Log("Button 4");
                    animationFour.Play();
                    selectedColors.Enqueue(4);
                    DeQueueColor();
                    break;
                case "ButtonFive":
                    Debug.Log("Button 5");
                    animationFive.Play();
                    selectedColors.Enqueue(5);
                    DeQueueColor();
                    break;
                case "ButtonSix":
                    Debug.Log("Button 6");
                    animationSix.Play();
                    selectedColors.Enqueue(6);
                    DeQueueColor();
                    break;
                case "ButtonSeven":
                    Debug.Log("Button 7");
                    animationSeven.Play();
                    selectedColors.Enqueue(7);
                    DeQueueColor();
                    break;
                case "ButtonEight":
                    Debug.Log("Button 8");
                    animationEight.Play();
                    selectedColors.Enqueue(8);
                    DeQueueColor();
                    break;
                case "Reset":
                    animationReset.Play();
                    selectedColors.Clear();
                    break;
                case "Execute":
                    animationExecute.Play();
                    if (selectedColors.Contains(7) && selectedColors.Contains(5))
                    {
                        soundExecute.PlayOneShot(right);
                        animationSlidingDoor.Play();
                        animationSlidingDoor2.Play();
                    }
                    else
                    {
                        soundExecute.PlayOneShot(wrong);
                    }
                    break;
            }
    }
   
}