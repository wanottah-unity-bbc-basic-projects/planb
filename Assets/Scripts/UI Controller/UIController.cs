
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.18
//

public class UIController : MonoBehaviour
{
    public static UIController uiController;



    public Slider energySlider;
    public Slider ammoSlider;
    public Slider computerSlider;

    public TMP_Text energyText;
    public TMP_Text ammoText;
    public TMP_Text computerText;



    private void Awake()
    {
        uiController = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


} // end of class
