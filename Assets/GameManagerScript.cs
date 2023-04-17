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

        ////�ǉ��@������̐錾�Ə�����
        //string debugText = "";
        //for (int i = 0; i < map.Length; i++)
        //{
        //    //�ύX�@������Ɍ������Ă���
        //    debugText += map[i].ToString() + ",";
        //}
        ////����������������o��
        //Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
        //������Ȃ��������̂��߂�-1�ŏ�����
        int playerIndex = -1;

        //�v�f����map.Length�Ŏ擾
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                playerIndex = i;
                break;
            }
        }

        /*
          playerIndex + 1 �̃C���f�b�N�X�̂��̂ƌ�������̂ŁA
          playerIndex - 1�@��肳��ɏ������C���f�b�N�X�̂Ƃ�
          �̂݌����������s��
         */
       
        if (playerIndex < map.Length + 1)
        {
            //�E�ړ�����
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }
        }

        //���ړ�����
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
