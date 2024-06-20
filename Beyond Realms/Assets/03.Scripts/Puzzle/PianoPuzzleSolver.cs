using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PianoPuzzleSolver : MonoBehaviour
{
    public byte[] tilePassword = { 7, 10, 3, 5, 4, 6 };
    private List<byte> userTileClicked = new List<byte>();
    public PianoPuzzle[] piano;

    public GameObject[] pokeColliders;

    public UnityEvent clearPuzzle;

    private void Start()
    {
        userTileClicked.Clear();
    }

    public void AddNumber(string number)
    {
        byte parsedNumber;
        if (!byte.TryParse(number, out parsedNumber))
        {
            return;
        }

        // ����Ʈ�� �߰�
        userTileClicked.Add(parsedNumber);
        Debug.Log("Current userTileClicked: " + string.Join(", ", userTileClicked));

        // ��й�ȣ ���̿� ��
        if (userTileClicked.Count == tilePassword.Length)
        {
            CheckPassword();
        }
        else if (userTileClicked.Count > tilePassword.Length)
        {
            // �ʿ��� ���, �ʰ��� ���ڸ� �����ϰų� ����Ʈ�� �ʱ�ȭ�� �� �ֽ��ϴ�.
            userTileClicked.Clear();
        }
    }

    private void CheckPassword()
    {
        // ��й�ȣ�� ��ġ�ϴ��� Ȯ��
        bool isCorrect = true;
        for (byte i = 0; i < tilePassword.Length; i++)
        {
            if (userTileClicked[i] != tilePassword[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            // ��й�ȣ�� �´� ����� ó��
            foreach (PianoPuzzle tile in piano)
            {
                tile.CorrectSound();
            }
            clearPuzzle.Invoke();
            pokeColliders[0].SetActive(false);
            pokeColliders[1].SetActive(false);
        }
        else
        {
            // ��й�ȣ�� Ʋ�� ����� ó��
            foreach (PianoPuzzle tile in piano)
            {
                tile.InCorrectSound();
            }
            userTileClicked.Clear();
        }
    }
}