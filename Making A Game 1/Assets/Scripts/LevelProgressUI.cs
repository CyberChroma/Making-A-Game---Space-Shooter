using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    private Slider slider;
    private Transform levelEnd;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        levelEnd = FindObjectOfType<LevelEnd>().transform;
        slider.value = 0;
        slider.maxValue = levelEnd.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = slider.maxValue - levelEnd.position.z;
    }
}
