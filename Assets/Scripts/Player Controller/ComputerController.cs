
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.12.18
//

public class ComputerController : MonoBehaviour
{
    public static ComputerController computerController;



    // total computers
    private int totalComputers;

    // current computers
    private float currentComputers;



    private void Awake()
    {
        computerController = this;
    }


    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        totalComputers = 100;

        currentComputers = totalComputers;

        UIController.uiController.computerSlider.maxValue = totalComputers;

        UpdateComputerSlider();
    }


    public void DestroyComputer()
    {
        currentComputers--;

        UpdateComputerSlider();

        // check if player is dead
        if (currentComputers <= 0)
        {

            // disable player controller
            //PlayerController.playerController.gameObject.SetActive(false);

            //        Instantiate(destroyedParticles, player.position, player.rotation);

            //        // Display Game Over UI
            //        //gameOverUI.gameObject.SetActive(true);
        }
    }


    private void UpdateComputerSlider()
    {
        float computerPercentage = (currentComputers / totalComputers) * 100;

        UIController.uiController.computerText.text = ((int)computerPercentage).ToString() + "%";

        UIController.uiController.computerSlider.value = currentComputers;
    }


} // end of class
