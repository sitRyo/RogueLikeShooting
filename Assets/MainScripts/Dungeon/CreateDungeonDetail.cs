using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonConst;
using DPara = DungeonConst.parameters;

public class CreateDungeonDetail : MonoBehaviour {

    [SerializeField] private int m_RoomWidthMax = 10;
    [SerializeField] private int m_RoomWidthMin = 5;
    [SerializeField] private int m_RoomHeightMax = 10;
    [SerializeField] private int m_RoomHeightMin = 5;
    [SerializeField] private int m_NumberOfRoomMax = 5;
    [SerializeField] private int m_NumberOfRoomMin = 5;

    public void CreateRandomWall(ref DPara[,] m_Map, int width, int height) {
        int roomCount = Random.Range(m_NumberOfRoomMin, m_NumberOfRoomMax);
        for (int i = 0; i < roomCount; ++i) {
            // 左上の点
            int x = Random.Range(0, width - m_RoomWidthMax); 
            int y = Random.Range(0, height - m_RoomHeightMax);
            // どこまで壁を大きくするか？
            int nx = Random.Range(m_RoomWidthMin, m_RoomWidthMax);
            int ny = Random.Range(m_RoomHeightMin, m_RoomHeightMax);

            for (int h = y; h < y + ny; ++h) {
                for (int w = x; w < x + nx; ++w) {
                    // 壁に変更
                    m_Map[h, w] = DPara.Wall;
                }
            }
        }
    }
}
