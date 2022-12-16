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

    
    public void OnButtonPressed_on(VirtualButtonBehaviour Vb_on)
    {
        GetData_temAqua();
        GetData_temWater();
        GetData_lvlAqua();
        GetData_lvlFood();
    }
 
    void GetData_temAqua() => StartCoroutine(GetData_Coroutine());
    void GetData_temWater() => StartCoroutine(GetData_Coroutine1());
    void GetData_lvlAqua() => StartCoroutine(GetData_Coroutine2());
    void GetData_lvlFood() => StartCoroutine(GetData_Coroutine3());
 


