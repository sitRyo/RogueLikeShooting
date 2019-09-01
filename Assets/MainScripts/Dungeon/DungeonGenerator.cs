using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonConst;
using DPara = DungeonConst.parameters;

/* ダンジョン生成のスクリプト
 * 矩形生成の方法を使用してルームの中に壁を作る.
 */

public class DungeonGenerator : MonoBehaviour {

    [SerializeField] private GameObject Wall;
    // [SerializeField] private GameObject Road;
    [SerializeField] private int m_MapWidth = 50;
    [SerializeField] private int m_MapHeight = 50;

    public DPara[,] m_Map;

    private CreateDungeonDetail m_CDD;

    private void Start() {
        m_CDD = GetComponent<CreateDungeonDetail>();
        if (m_CDD == null) {
            Debug.LogError("CreateDungeonDetail.cs doesn't be attached.");
            return;
        }
        FormatMapData();
        CreateOuterWall();
        m_CDD.CreateRandomWall(ref m_Map, m_MapWidth, m_MapHeight);
        AplayMapDataToDungeon();
    }

    private void FormatMapData() {
        m_Map = new DPara[m_MapHeight, m_MapWidth]; // 外枠
        for (int i = 0; i < m_MapHeight; ++i)
            for (int j = 0; j < m_MapWidth; ++j)
                m_Map[i, j] = DPara.Road;
    }

    // 画面外に壁を作る
    private void CreateOuterWall() {
        int xAxis = m_MapWidth / 2;
        int yAxis = m_MapHeight / 2;
        // top and bottom
        for (int i = 0; i < m_MapWidth + 5; ++i) { // 外周の余分な2つを入れる
            Instantiate(Wall, new Vector3(i - xAxis, 1.5f, yAxis + 1), Quaternion.identity); // top
            Instantiate(Wall, new Vector3(i - xAxis, 1.5f, -yAxis - 1), Quaternion.identity); // bottom
        }

        for (int i = 0; i < m_MapHeight + 5; ++i) {
            Instantiate(Wall, new Vector3(-xAxis - 1, 1.5f, yAxis - i + 1), Quaternion.identity); // left
            Instantiate(Wall, new Vector3(xAxis + 1, 1.5f, yAxis - i + 1), Quaternion.identity); // right
        }
    }

    private void AplayMapDataToDungeon() {
        for (int h = 0; h < m_MapHeight; ++h) {
            for (int w = 0; w < m_MapWidth; ++w) {
                Vector3 pos = new Vector3(h - m_MapHeight / 2, 1.5f, w - m_MapWidth / 2);
                switch (m_Map[h, w]) {
                    case DPara.Road:
                        // do nothing;
                        break;
                    case DPara.Wall:
                        Instantiate(Wall, pos, Quaternion.identity);
                        break;
                }
            }
        }
    }
}
