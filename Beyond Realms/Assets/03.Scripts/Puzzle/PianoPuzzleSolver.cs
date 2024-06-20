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

        // 리스트에 추가
        userTileClicked.Add(parsedNumber);
        Debug.Log("Current userTileClicked: " + string.Join(", ", userTileClicked));

        // 비밀번호 길이와 비교
        if (userTileClicked.Count == tilePassword.Length)
        {
            CheckPassword();
        }
        else if (userTileClicked.Count > tilePassword.Length)
        {
            // 필요한 경우, 초과된 숫자를 제거하거나 리스트를 초기화할 수 있습니다.
            userTileClicked.Clear();
        }
    }

    private void CheckPassword()
    {
        // 비밀번호가 일치하는지 확인
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
            // 비밀번호가 맞는 경우의 처리
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
            // 비밀번호가 틀린 경우의 처리
            foreach (PianoPuzzle tile in piano)
            {
                tile.InCorrectSound();
            }
            userTileClicked.Clear();
        }
    }
}