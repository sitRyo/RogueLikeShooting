using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerate : MonoBehaviour {
  
  public int[ , ] dungeon;
  public int m_DungeonX { get; private set; }
  public int m_DungeonY { get; private set; }

  bool flag = true;

  void Start() {
    int x = Random.Range(30, 40);
    int y = Random.Range(30, 40);

    m_DungeonX = x;
    m_DungeonY = y;

    dungeon = new int[y, x];
  }

  void Update() {
    if (flag) {
      for (int i = 0; i < m_DungeonY; ++i) {
        string log = "";
        for (int j = 0; j < m_DungeonX; ++j) {
          int tmp = Random.Range(0, 3);
          dungeon[i, j] = tmp;
          log += tmp.ToString() + " ";
        }
        Debug.Log(log);
      }
    }
    flag = false;    
  }
}
