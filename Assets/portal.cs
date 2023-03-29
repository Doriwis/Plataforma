using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] int indiceNuevoNivel;
    [SerializeField] Vector3 NuevaPosParaPlayer;
    GameObject yo;

    private void Start()
    {
        yo = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (yo!=null && yo.GetComponent<player>().indicellaves >= indiceNuevoNivel)
        {
            this.gameObject.SetActive(true);
        }
    }

    public int GetIndiceNuevoNivel()
    {
        return indiceNuevoNivel;
    }
    public Vector3 GetNuevaPosicion()
    {
        return NuevaPosParaPlayer;
    }
}
