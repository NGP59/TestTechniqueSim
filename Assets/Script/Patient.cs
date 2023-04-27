using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    int currentIndexOfDialogue;
    [SerializeField]
    List<GameObject> DialogueQueux;
    [SerializeField] GameObject patientCanvas;
    
    private void Start()
    {
        currentIndexOfDialogue = 0;
       // SwitchWindow(currentIndexOfDialogue);
    }

    public void SwitchWindow(int nextDialogueIndex)
    {
        if(patientCanvas.activeInHierarchy == false)
        {
            patientCanvas.SetActive(true);
        }
        DialogueQueux[currentIndexOfDialogue].SetActive(false);
        DialogueQueux[nextDialogueIndex].SetActive(true);
        currentIndexOfDialogue = nextDialogueIndex;
    }

    public void FinalDialogue()
    {
        DialogueQueux[currentIndexOfDialogue].SetActive(false);
        patientCanvas.SetActive(false);
    }
}
