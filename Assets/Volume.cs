using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider mySlider;



    void Start()
    {
        mySlider.value = PlayerPrefs.GetFloat("SliderVolume", .5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeVolume(){
        PlayerPrefs.SetFloat("SliderVolume", mySlider.value);
    }
}
