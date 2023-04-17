using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map;



    void PrintfArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };

        PrintfArray();

        ////追加　文字列の宣言と初期化
        //string debugText = "";
        //for (int i = 0; i < map.Length; i++)
        //{
        //    //変更　文字列に結合していく
        //    debugText += map[i].ToString() + ",";
        //}
        ////結合した文字列を出力
        //Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
        //見つからなかった時のために-1で初期化
        int playerIndex = -1;

        //要素数はmap.Lengthで取得
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                playerIndex = i;
                break;
            }
        }

        /*
          playerIndex + 1 のインデックスのものと交換するので、
          playerIndex - 1　よりさらに小さいインデックスのとき
          のみ交換処理を行う
         */
       
        if (playerIndex < map.Length + 1)
        {
            //右移動処理
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }
        }

        //左移動処理
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (playerIndex > 1)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
            }
        }



    }
}
