using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour
{

    public int width;
    public int height;

    public string seed;
    public bool useRandomSeed;

    [Range(0, 100)]
    public int randomFillPercent;
    public GameObject wallPrefab;

    public int smoothTimes;

    bool[,] map;

    void Start()
    {
        GenerateMap();
    }

    void Update()
    {
        
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateMap();
        }*/
    }

    void GenerateMap()
    {
        map = new bool[width, height];
        RandomFillMap();

        for (int x = 0; x < smoothTimes; x++)
        {
            SmoothMap();
        }

    }


    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        var pseudoRandom = new System.Random(seed.GetHashCode());

        // 入れ子配列って汚くない? そうでもない? foreachにしたいけど多次元配列だと面倒なんだよね
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // マップ端はかならず埋める
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = true;
                }
                else
                {
                    map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? true : false;
                }
            }
        }

    }

    // ノイジーなマップを滑らかにしてより地形らしい構造に近づける
    void SmoothMap()
    {

        // 一々配列を生成するのは速度的にもメモリ的にもあまりよろしくない(まあ配列だから早めではあるけど)
        var mapMirror = new bool[width, height];
        Array.Copy(map, mapMirror, map.Length);

        // 入れ子配列って汚くない? そうでもない? foreachにしたいけど多次元配列だと面倒なんだよね
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var SurroundingWallCount = GetSurroundingWallCount(mapMirror, x, y);
                if (SurroundingWallCount > 4)
                {
                    map[x, y] = true;
                }
                else if (SurroundingWallCount < 4)
                {
                    map[x, y] = false;
                }
            }
        }

    }

    int GetSurroundingWallCount(bool[,] map, int posX, int posY)
    {
        int count = 0;
        for (int x = posX - 1; x <= posX + 1; x++)
        {
            for (int y = posY - 1; y <= posY + 1; y++)
            {
                if (x >= 0 && x < width && y >= 0 && y < height)
                {  // 境界チェック
                    if (x != posX || y != posY)
                    {                   // グリッド本体はスルー
                        count += map[x, y] ? 1 : 0;
                    }
                }
                else
                {
                    // map外は埋められていると仮定(じゃないとmap端が空白になる可能性あるしね)
                    count++;
                }
            }
        }
        return count;
    }
/*
    void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y]) ? Color.black : Color.white;
                    var pos = new Vector3(-width / 2 + x + 0.5f, 0, -height / 2 + y + 0.5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
*/
}
