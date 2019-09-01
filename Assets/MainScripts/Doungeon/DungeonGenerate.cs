using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonConst;

public class DungeonGenerate : MonoBehaviour { 
    [SerializeField] private int m_MapWidth = 50;
    [SerializeField] private int m_MapHeight = 50;

    public int[,] Map;
}
