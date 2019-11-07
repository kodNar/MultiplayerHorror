using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ButtonScript : MonoBehaviour

{
    public GameObject definedButton;
    private new Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        definedButton = this.gameObject;
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
                    animation.Play("buttonAnimation");
                    break;
                case "ButtonTwo":
                    Debug.Log("Button 2");
                    break;
                case "ButtonThree":
                    Debug.Log("Button 3");
                    break;
                case "ButtonFour":
                    Debug.Log("Button 4");
                    break;
                case "ButtonFive":
                    Debug.Log("Button 5");
                    break;
                case "ButtonSix":
                    Debug.Log("Button 6");
                    break;
                case "ButtonSeven":
                    Debug.Log("Button 7");
                    break;
                case "ButtonEight":
                    Debug.Log("Button 8");
                    break;
            }
        }
    }
}