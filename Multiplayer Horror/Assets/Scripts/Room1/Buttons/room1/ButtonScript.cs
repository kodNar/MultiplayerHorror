using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ButtonScript : MonoBehaviour

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
    private Animation animationOne;
    private Animation animationTwo;
    private Animation animationThree;
    private Animation animationFour;
    private Animation animationFive;
    private Animation animationSix;
    private Animation animationSeven;
    private Animation animationEight;

    // Start is called before the first frame update
    void Start()
    {
        animationEight = button8.GetComponent<Animation>();
        animationSeven = button7.GetComponent<Animation>();
        animationSix = button6.GetComponent<Animation>();
        animationFive = button5.GetComponent<Animation>();
        animationFour = button4.GetComponent<Animation>();
        animationThree = button3.GetComponent<Animation>();
        animationTwo = button2.GetComponent<Animation>();
        animationOne = button1.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            String buttonName = PlayerRaycasting.whatItHit.collider.gameObject.name;

            switch (buttonName)
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
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (int ele in selectedColors)
            {
                Debug.Log(ele.ToString());
            }
        }
    }

    private void DeQueueColor()
    {
        if (selectedColors.Count > 2)
        {
            selectedColors.Dequeue();
        }
    }
}