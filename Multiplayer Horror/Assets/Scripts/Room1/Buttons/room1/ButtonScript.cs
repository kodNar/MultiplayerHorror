using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ButtonScript : MonoBehaviour

{
    private new Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            String buttonName = PlayerRaycasting.whatItHit.collider.gameObject.name;

            switch (buttonName)
            {
                case "ButtonOne":
                    Debug.Log("Button 1");
                    animation.Play("buttonAnimation1");
                    ControlPanel.selectedColors.Enqueue(1);
                    DeQueueColor();
                    break;
                case "ButtonTwo":
                    Debug.Log("Button 2");
                    animation.Play("buttonAnimation2");
                    ControlPanel.selectedColors.Enqueue(2);
                    DeQueueColor();
                    break;
                case "ButtonThree":
                    Debug.Log("Button 3");
                    animation.Play("buttonAnimation3");
                    ControlPanel.selectedColors.Enqueue(3);
                    DeQueueColor();
                    break;
                case "ButtonFour":
                    Debug.Log("Button 4");
                    animation.Play("buttonAnimation4");
                    ControlPanel.selectedColors.Enqueue(4);
                    DeQueueColor();
                    break;
                case "ButtonFive":
                    Debug.Log("Button 5");
                    animation.Play("buttonAnimation5");
                    ControlPanel.selectedColors.Enqueue(5);
                    DeQueueColor();
                    break;
                case "ButtonSix":
                    Debug.Log("Button 6");
                    animation.Play("buttonAnimation6");
                    ControlPanel.selectedColors.Enqueue(6);
                    DeQueueColor();
                    break;
                case "ButtonSeven":
                    Debug.Log("Button 7");
                    animation.Play("buttonAnimation7");
                    ControlPanel.selectedColors.Enqueue(7);
                    DeQueueColor();
                    break;
                case "ButtonEight":
                    Debug.Log("Button 8");
                    animation.Play("buttonAnimation8");
                    ControlPanel.selectedColors.Enqueue(8);
                    DeQueueColor();
                    break;
            }
        }

        if (Input.GetKey(KeyCode.P))
        {
            foreach (int ele in ControlPanel.selectedColors)
            {
               Debug.Log(ele.ToString());
            }
        }
    }

    private void DeQueueColor()
    {
        if (ControlPanel.selectedColors.Count > 2)
        {
            ControlPanel.selectedColors.Dequeue();
        }
        
    }
}