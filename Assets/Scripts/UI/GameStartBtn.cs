using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartBtn : MonoBehaviour
{
    public void OnClickStartBtn()
    {
        UIManager.Instance.ChangeScene("MainScene");
    }
}
