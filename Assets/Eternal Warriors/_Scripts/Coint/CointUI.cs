using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CointUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoint;

    private void Update()
    {
        textCoint.text = CointManager.instance.coint.ToString();
    }
    
}
