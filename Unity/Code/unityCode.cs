// C# code for Unity.


using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Vuforia;



public class click : MonoBehaviour
{
    InputField tempAquarium;
    InputField tempHotWater;
    InputField levelAquarium;
    InputField levelFood;

    public VirtualButtonBehaviour Vb_on;
 

  void Start()
    {
        tempAquarium = GameObject.Find("TextInputField").GetComponent<InputField>();
        tempHotWater = GameObject.Find("TextInputField1").GetComponent<InputField>();
        levelAquarium = GameObject.Find("TextInputField2").GetComponent<InputField>();
        levelFood = GameObject.Find("TextInputField3").GetComponent<InputField>();
        

        Vb_on.RegisterOnButtonPressed(OnButtonPressed_on);
    }


