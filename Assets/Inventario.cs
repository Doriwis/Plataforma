using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventario : MonoBehaviour
{
    [SerializeField]Sprite nul;
    [SerializeField] TextMeshProUGUI[] indice;
    [SerializeField]Image[] slot;
    [SerializeField]player yo;
    
    // Start is called before the first frame update
    void Start()
    {
        yo=GameObject.FindWithTag("Player").GetComponent<player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (yo.invent[i]!=null)
            {
              slot[i].sprite = yo.invent[i].spriteImg;
                string cont = "" + yo.invent[i].contador;
                indice[i].text = cont;
            }
            else
            {
                Debug.Log("A");
                
                indice[i].text = "";
            }
            
        }
    }
}
