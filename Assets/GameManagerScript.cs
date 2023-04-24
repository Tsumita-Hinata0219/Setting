using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class GameManagerScript : MonoBehaviour
{
    int[] map;


    // �z��̓��e���o�͂��鏈��
    void PrintfArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    // �v���C���[���ǂ̃C���f�b�N�X�ɋ���̂���Ԃ�����
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

    // �ړ��̉s�𔻒f���Ĉړ������鏈��
    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        // �ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo < 0|| moveTo >= map.Length) { return false; }

        // �ړ����2(��)��������
        if (map[moveTo] == 2)
        {
            // �ǂ̕����ֈړ����邩�Z�o
            int velocity = moveTo - moveFrom;
            /*
            �v���C���[�̈ړ��悩��A����ɐ��2(��)���ړ�������
            ���̈ړ������AMoveNumber���\�b�h�Ȃ���MoveNumber���\�b�h��
            �ĂԁA�������ċA���Ă���B�ړ��s����bool�L�^
             */
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            // ���������ړ����s������A�v���C���[�̈ړ������s
            if (!success) { return false; }
        }
        // �v���C���[�A��������炸�̈ړ�����
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0 };

        // �z��̓��e���o�͂���
        PrintfArray();
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̈ړ�����
        // �E�ړ�����
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // �v���C���[���ǂ̈ʒu�ɋ��邩
            int playerIndex = GetPlayerIndex();

            // �ړ�����
            MoveNumber(1, playerIndex, playerIndex + 1);

            // �z��̓��e���o�͂���
            PrintfArray();
        }

        //���ړ�����
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            // �v���C���[���ǂ̈ʒu�ɋ��邩
            int playerIndex = GetPlayerIndex();

            // �ړ�����
            MoveNumber(1, playerIndex, playerIndex - 1);

            // �z��̓��e���o�͂���
            PrintfArray();
        }



    }
}
