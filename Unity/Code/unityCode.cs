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
 

   IEnumerator GetData_Coroutine()
    {
        Debug.Log("Getting Data");
        tempAquarium.text = "Loading...";
        string uri = "https://sgp1.blynk.cloud/external/api/get?token=-XiF3fwP7C74lFBf-lIlRbImokZDu5VL&v2";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                tempAquarium.text = request.error;
            else
            {

                tempAquarium.text = request.downloadHandler.text;
                tempAquarium.text = field.text.Substring(2,2);
            }
        }
    }



   IEnumerator GetData_Coroutine1()
    {
        Debug.Log("Getting Data");
        tempHotWater.text = "Loading...";
        string uri = "https://sgp1.blynk.cloud/external/api/get?token=-XiF3fwP7C74lFBf-lIlRbImokZDu5VL&v3";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                tempHotWater.text = request.error;
            else
            {

                tempHotWater.text = request.downloadHandler.text;
                tempHotWater.text = field.text.Substring(2,2);
            }
        }
    }



   IEnumerator GetData_Coroutine2()
    {
        Debug.Log("Getting Data");
        levelAquarium.text = "Loading...";
        string uri = "https://sgp1.blynk.cloud/external/api/get?token=-XiF3fwP7C74lFBf-lIlRbImokZDu5VL&v0";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                levelAquarium.text = request.error;
            else
            {
                levelAquarium.text = request.downloadHandler.text;
                levelAquarium.text = field.text.Substring(2,2);
            }
        }
    }








}



