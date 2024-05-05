using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputLine : MonoBehaviour
{

    [SerializeField] private GameObject inpLine;

    public bool shouldShow;
    // Start is called before the first frame update
    void Start()
    {
        shouldShow = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.inpLine.SetActive(shouldShow);
    }
}
