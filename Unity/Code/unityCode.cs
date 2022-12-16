// C# code for Unity.


//Declaring Libraries.
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Vuforia;



public class unityCode: MonoBehaviour
{
    //Declaring variables for the input fields.
    InputField tempAquarium;
    InputField tempHotWater;
    InputField levelAquarium;
    InputField levelFood;

    //Declaring the virtual button.
    public VirtualButtonBehaviour Vb_on;
 

  void Start()
    {
	//Initializing the variables to their respective input fields. 
        tempAquarium = GameObject.Find("fieldTempAquarium").GetComponent<InputField>();
        tempHotWater = GameObject.Find("fieldTempHotWater").GetComponent<InputField>();
        levelAquarium = GameObject.Find("fieldLevelAquarium").GetComponent<InputField>();
        levelFood = GameObject.Find("fieldLevelFood").GetComponent<InputField>();
        
	//Call function "OnButtonPressed_on" when the virtual button is pressed.
        Vb_on.RegisterOnButtonPressed(OnButtonPressed_on);
    }

    
    public void OnButtonPressed_on(VirtualButtonBehaviour Vb_on)
    {
	//Call other functions to get the data.
        GetData_temAqua();
        GetData_temWater();
        GetData_lvlAqua();
        GetData_lvlFood();
    }
 
    //Again call another function to fetch data.
    void GetData_temAqua() => StartCoroutine(GetData_Coroutine());
    void GetData_temWater() => StartCoroutine(GetData_Coroutine1());
    void GetData_lvlAqua() => StartCoroutine(GetData_Coroutine2());
    void GetData_lvlFood() => StartCoroutine(GetData_Coroutine3());
 

   //Function to fetch data from Blynk API and update the Input Fields.
   IEnumerator GetData_Coroutine()
    {
        Debug.Log("Getting Data");
        tempAquarium.text = "Loading...";

	//Getting the data from this URL.
        string uri = "https://sgp1.blynk.cloud/external/api/get?token=-XiF3fwP7C74lFBf-lIlRbImokZDu5VL&v2";

	//If there is network error; display the error; else, show the fetched data.
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
                tempAquarium.text = request.error;
            else
            {
                tempAquarium.text = request.downloadHandler.text;
                tempAquarium.text = tempAquarium.text.Substring(2,2);
            }
        }
    }


   
   //Same explanation as above; here just the Virtual Pin of Blynk API is changed.
   IEnumerator GetData_Coroutine1()
    {
        Debug.Log("Getting Data");
        tempHotWater.text = "Loading...";
        string uri = "https://sgp1.blynk.cloud/external/api/get?token=-XiF3fwP7C74lFBf-lIlRbImokZDu5VL&v3";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
                tempHotWater.text = request.error;
            else
            {
                tempHotWater.text = request.downloadHandler.text;
                tempHotWater.text = tempHotWater.text.Substring(2,2);
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
            if (request.result == UnityWebRequest.Result.ConnectionError)
                levelAquarium.text = request.error;
            else
            {
                levelAquarium.text = request.downloadHandler.text;
                levelAquarium.text = levelAquarium.text.Substring(2,2);
            }
        }
    }




   IEnumerator GetData_Coroutine3()
    {
        Debug.Log("Getting Data");
        levelFood.text = "Loading...";
        string uri = "https://sgp1.blynk.cloud/external/api/get?token=-XiF3fwP7C74lFBf-lIlRbImokZDu5VL&v1";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
                levelFood.text = request.error;
            else
            {
                levelFood.text = request.downloadHandler.text;
                levelFood.text = levelFood.text.Substring(2,2);
            }
        }
    }


}