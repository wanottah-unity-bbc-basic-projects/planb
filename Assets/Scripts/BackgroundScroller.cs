
using UnityEngine;


public class BackgroundScroller : MonoBehaviour
{
    // Background scrolling speed
    public float scrollSpeed = -0.0006f;

    // Scroll background depending on which way the player is moving
    public bool scrollBackground;
    public bool scrollBackgroundLeft;

    // Reference to background image renderer
    [SerializeField]
    private Renderer imageRenderer;

	
	// Update is called once per frame
	void Update ()
    {
        // If player is moving
        if (scrollBackground)
        {
            if (scrollBackgroundLeft)
            {
                // Move background left
                imageRenderer.material.mainTextureOffset -= new Vector2(-scrollSpeed, 0);
            }

            // Otherwise
            else
            {
                // Move background right
                imageRenderer.material.mainTextureOffset -= new Vector2(scrollSpeed, 0);
            }
        }
    }

}
