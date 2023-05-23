using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject Panel;
    private bool _instructions;
    // Start is called before the first frame update
    public void AfficherInstructions()
    {
        if (Panel != null && !_instructions)
        {
            Panel.SetActive(true);
            _instructions = true;
        }
        else if (Panel != null && _instructions)
        {
            EnleverInstructions();
        }
    }

    public void EnleverInstructions()
    {
        Panel.SetActive(false);
        

        _instructions = false;
    }


}
