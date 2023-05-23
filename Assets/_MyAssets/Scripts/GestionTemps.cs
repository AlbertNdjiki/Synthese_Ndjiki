using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestionTemps : MonoBehaviour
{

    

    // Start is called before the first frame update

    public TextMeshProUGUI timerText;
    public float currentTime;
    public bool countDown;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerText.text = "Temps : " + currentTime.ToString();
        
    }

   

}
