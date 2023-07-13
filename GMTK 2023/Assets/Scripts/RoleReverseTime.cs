using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RoleReverseTime : MonoBehaviour
{
    public List<GameObject> button_list = new List<GameObject>();
    public GameObject menuCanvas;
    public Transform panel;
    private GameObject b1;
    private GameObject b2;
    private GameObject b3;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /**if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(isActive);
            if (!menuCanvas.activeSelf) {
                ActivatePanel();
            } else {
                DeactivatePanel();
            }
        }**/
    }

    private List<int> GenerateUniqueRandomNumbers(int minRange, int maxRange, int count)
    {
        List<int> numbers = new List<int>();

        for (int i = minRange; i <= maxRange; i++)
        {
            numbers.Add(i);
        }

        List<int> result = new List<int>();

        System.Random random = new System.Random();

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(numbers.Count);
            result.Add(numbers[index]);
            numbers.RemoveAt(index);
        }

        return result;
    }

    void SelectReverses() {

        List<int> indexes = GenerateUniqueRandomNumbers(0, button_list.Count - 1, 3);

        var go = Instantiate<GameObject>( button_list[indexes[0]], panel);
        go.transform.position = b1.transform.position;

        go = Instantiate<GameObject>( button_list[indexes[1]], panel);
        go.transform.position = b2.transform.position;

        go = Instantiate<GameObject>( button_list[indexes[2]], panel);
        go.transform.position = b3.transform.position;
    }

    public void DeactivatePanel() {
        ToggleTimeFreeze();
        if(GameObject.FindWithTag("paneltime") != null)
            panel = GameObject.FindWithTag("paneltime").transform;
        isActive = false;
        
        if(GameObject.FindWithTag("canvass") != null)
            menuCanvas = GameObject.FindWithTag("canvass");
        
        menuCanvas.SetActive(false);
        Debug.Log(menuCanvas);
        
        foreach (Transform child in panel) {
            GameObject.Destroy(child.gameObject);
        }
        Debug.Log("sadsdksofjkpsodkfposdk 2");
    }

    public void ActivatePanel() {
        ToggleTimeFreeze();
        isActive = true;

        if(GameObject.FindWithTag("canvass") != null)
            menuCanvas = GameObject.FindWithTag("canvass");

        menuCanvas.SetActive(true);

        if(GameObject.FindWithTag("paneltime") != null)
            panel = GameObject.FindWithTag("paneltime").transform;

        b1 = GameObject.FindWithTag("buton1");
        b2 = GameObject.FindWithTag("buton2");
        b3 = GameObject.FindWithTag("buton3");
        SelectReverses();
    }

    private void ToggleTimeFreeze()
    {
        if (Time.timeScale == 0f)
        {
            // Unfreeze time
            Time.timeScale = 1f;
            Debug.Log("Time unfrozen.");
        }
        else
        {
            // Freeze time
            Time.timeScale = 0f;
            Debug.Log("Time frozen.");
        }
    }
}
