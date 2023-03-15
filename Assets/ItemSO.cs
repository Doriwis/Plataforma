using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Items")]
public class ItemSO : ScriptableObject
{
    [SerializeField] public string nombre;
    [SerializeField] public Sprite spriteImg;
    [SerializeField] public int contador;
}
