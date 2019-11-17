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
                    break;
                case "ButtonTwo":
                    Debug.Log("Button 2");
                    animation.Play("buttonAnimation2");
                    break;
                case "ButtonThree":
                    Debug.Log("Button 3");
                    animation.Play("buttonAnimation3");
                    break;
                case "ButtonFour":
                    Debug.Log("Button 4");
                    animation.Play("buttonAnimation4");
                    break;
                case "ButtonFive":
                    Debug.Log("Button 5");
                    animation.Play("buttonAnimation5");
                    break;
                case "ButtonSix":
                    Debug.Log("Button 6");
                    animation.Play("buttonAnimation6");
                    break;
                case "ButtonSeven":
                    Debug.Log("Button 7");
                    animation.Play("buttonAnimation7");
                    break;
                case "ButtonEight":
                    Debug.Log("Button 8");
                    animation.Play("buttonAnimation8");
                    break;
            }
        }
    }
}