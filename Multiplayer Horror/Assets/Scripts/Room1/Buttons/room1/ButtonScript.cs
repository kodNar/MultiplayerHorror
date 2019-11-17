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

    // Start is called before the first frame update
    void Start()
    {
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
                    button1.GetComponent<Animation>().Play();
                    selectedColors.Enqueue(1);
                    DeQueueColor();
                    break;
                case "ButtonTwo":
                    Debug.Log("Button 2");
                    button2.GetComponent<Animation>().Play();
                    selectedColors.Enqueue(2);
                    DeQueueColor();
                    break;
                case "ButtonThree":
                    Debug.Log("Button 3");
                    button3.GetComponent<Animation>().Play();
                    selectedColors.Enqueue(3);
                    DeQueueColor();
                    break;
                case "ButtonFour":
                    Debug.Log("Button 4");
                    button4.GetComponent<Animation>().Play();
                    selectedColors.Enqueue(4);
                    DeQueueColor();
                    break;
                case "ButtonFive":
                    Debug.Log("Button 5");
                    button5.GetComponent<Animation>().Play();
                    selectedColors.Enqueue(5);
                    DeQueueColor();
                    break;
                case "ButtonSix":
                    Debug.Log("Button 6");
                    button6.GetComponent<Animation>().Play();
                    selectedColors.Enqueue(6);
                    DeQueueColor();
                    break;
                case "ButtonSeven":
                    Debug.Log("Button 7");
                    button7.GetComponent<Animation>().Play();
                    selectedColors.Enqueue(7);
                    DeQueueColor();
                    break;
                case "ButtonEight":
                    Debug.Log("Button 8");
                    button8.GetComponent<Animation>().Play();
                    selectedColors.Enqueue(8);
                    DeQueueColor();
                    break;
            }
        }

        if (Input.GetKey(KeyCode.P))
        {
            foreach (int ele in selectedColors)
            {
                Debug.Log(ele.ToString());
                Debug.Log(selectedColors.Count);
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