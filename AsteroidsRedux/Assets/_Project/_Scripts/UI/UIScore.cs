using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    private TextMeshProUGUI _tmpScore;

    private void Awake()
    {
        _tmpScore = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _tmpScore.text = "20";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
