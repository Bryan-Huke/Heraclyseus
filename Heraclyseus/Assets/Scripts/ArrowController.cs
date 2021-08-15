using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    public Camera cam;
    public bool isControlledByKeyboard = true;

    private ArrowControls arrowControls;
    private Vector2 lookDir;

    void Awake()
    {
        arrowControls = new ArrowControls();
    }

    private void OnEnable()
    {
        arrowControls.Enable();
    }

    private void OnDisable()
    {
        arrowControls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        if (isControlledByKeyboard)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(arrowControls.Combat.MousePos.ReadValue<Vector2>());
            lookDir = new Vector2(mousePos.x, mousePos.y) - new Vector2(transform.position.x, transform.position.y);
        }
        else
            lookDir = arrowControls.Combat.LookDir.ReadValue<Vector2>();
    }


    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


    public Vector2 getLookDir()
    {
        return lookDir;
    }

}
