using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] Camera cam;
    AudioSource audioInteraction;
    Vector3 ScreenCenter = new Vector3(Screen.width / 2, Screen.height / 2f, 0f);
    Vector3 MousePos;
    RaycastHit hit;
    [SerializeField] LineRenderer lineR;
    bool isStop = true;
    // Update is called once per frame

    private void Start()
    {
        audioInteraction = GetComponent<AudioSource>();
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = 0f;
        lineR.SetPosition(0, cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)));

    }
    void Update()
    {
        lineR.SetPosition(1, cam.ScreenToWorldPoint(MousePos));

        if (Input.GetButtonDown("Fire1"))
        {

            CheckForColliders();
        }
        DoingInteraction();
    }

    void CheckForColliders()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

        }
    }

    void DoingInteraction()
    {
        if (hit.transform.TryGetComponent<Interactible>(out Interactible interactibleGO))
        {
            // this.transform.position = interactibleGO.GetPosition().position;
            transform.position = Vector3.Lerp(transform.position, interactibleGO.GetPosition().position, Time.deltaTime * 2f);
            PlaySound();
        }

        if (hit.transform.TryGetComponent<Patient>(out Patient patientGO))
        {
            patientGO.SwitchWindow(0);
            PlaySound();
        }
    }


    void PlaySound()
    {
        audioInteraction.Play();
    }
}
