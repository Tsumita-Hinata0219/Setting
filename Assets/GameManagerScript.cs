using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class GameManagerScript : MonoBehaviour
{
    int[] map;


    // 配列の内容を出力する処理
    void PrintfArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    // プレイヤーがどのインデックスに居るのかを返す処理
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

    // 移動の可不可を判断して移動させる処理
    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        // 移動先が範囲外なら移動不可
        if (moveTo < 0|| moveTo >= map.Length) { return false; }

        // 移動先に2(箱)が居たら
        if (map[moveTo] == 2)
        {
            // どの方向へ移動するか算出
            int velocity = moveTo - moveFrom;
            /*
            プレイヤーの移動先から、さらに先へ2(箱)を移動させる
            箱の移動処理、MoveNumberメソッドないでMoveNumberメソッドを
            呼ぶ、処理が再帰している。移動不可をでbool記録
             */
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            // もし箱が移動失敗したら、プレイヤーの移動も失敗
            if (!success) { return false; }
        }
        // プレイヤー、箱かかわらずの移動処理
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0 };

        // 配列の内容を出力する
        PrintfArray();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの移動処理
        // 右移動処理
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // プレイヤーがどの位置に居るか
            int playerIndex = GetPlayerIndex();

            // 移動処理
            MoveNumber(1, playerIndex, playerIndex + 1);

            // 配列の内容を出力する
            PrintfArray();
        }

        //左移動処理
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            // プレイヤーがどの位置に居るか
            int playerIndex = GetPlayerIndex();

            // 移動処理
            MoveNumber(1, playerIndex, playerIndex - 1);

            // 配列の内容を出力する
            PrintfArray();
        }



    }
}
