using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePort : MonoBehaviour
{
    [SerializeField]GameObject[] portales;
    [SerializeField]int indexllave;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        indexllave = GameObject.FindWithTag("Player").GetComponent<player>().indicellaves;
        if (indexllave==0)
        {
            portales[0].SetActive(true);
        }
        else if (indexllave > 0 &&indexllave <2)
        {
            portales[0].SetActive(true);
            portales[1].SetActive(true);
        }
        else if (indexllave > 1&&indexllave < 3)
        {
            portales[0].SetActive(true);
            portales[1].SetActive(true);
            portales[2].SetActive(true);
        }
        else if (indexllave >2 && indexllave < 4)
        {
            portales[0].SetActive(true);
            portales[1].SetActive(true);
            portales[2].SetActive(true);
            portales[4].SetActive(true);
        }
        else if (indexllave > 3 && indexllave < 5)
        {
            portales[0].SetActive(true);
            portales[1].SetActive(true);
            portales[2].SetActive(true);
            portales[3].SetActive(true);
            portales[4].SetActive(true);
        }
        
    }
}
