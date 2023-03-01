using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager gM;


    private void Awake()
    {
        if (true)
        {
            gM = this;
            DontDestroyOnLoad(this.gameObject);

        }

    }




    void Update()
    {
        
    }
}
