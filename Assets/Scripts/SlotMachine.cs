using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private Sprite[] figures;
    [SerializeField] private Slot slotPrefab;

    public Slot slot => slotPrefab;

    public Sprite GetSprite(int slotIndex)
    {
        return figures[slotIndex - 1];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
