using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Transform pos0;
    public Transform pos1;
    private LineRenderer l;
    // Start is called before the first frame update
    void Start()
    {
        l = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        l.SetPosition(0, pos0.position);
        l.SetPosition(1, pos1.position);
    }
}
