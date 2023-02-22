using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] int indiceNuevoNivel;
    [SerializeField] Vector3 NuevaPosParaPlayer;

    public int GetIndiceNuevoNivel()
    {
        return indiceNuevoNivel;
    }
    public Vector3 GetNuevaPosicion()
    {
        return NuevaPosParaPlayer;
    }
}
