using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPickupSystem : MonoBehaviour
{
    public float pickUpRange;
    public float maxThrowForce;
    public float throwForceIncreaseSpeed;

    public Transform objectHolder;
    public LayerMask pickUpLayer;
    public LayerMask MissionLayer;

    public Camera playerCamera; // Kamerayý tanýmlayýn

    private GameObject currentObject;
    private Rigidbody currentObjectRb;

    private float currentThrowForce;


    private void Start()
    {

    }

    private void Update()
    {
        PickUp();
        Throw();
    }

    private void PickUp()
    {
        if (currentObject != null)
        {
            return;
        }

        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // Kamera merkezine bir ray oluþturun
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, pickUpRange, pickUpLayer))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentObject = hitInfo.collider.gameObject;
                currentObjectRb = currentObject.GetComponent<Rigidbody>();

                // Rigidbody bileþenini kontrol et
                if (currentObjectRb != null)
                {
                    currentObject.transform.parent = objectHolder;
                    currentObject.transform.localPosition = Vector3.zero;
                    currentObject.transform.localEulerAngles = Vector3.zero;

                    foreach (Collider collider in currentObject.GetComponents<Collider>())
                    {
                        collider.enabled = false;
                    }

                    currentObjectRb.isKinematic = true;
                }
                else
                {
                    // Eðer currentObjectRb null ise, bir hata mesajý göster veya baþka bir iþlem yapabilirsiniz.
                    Debug.Log("Object has no rigidbody");
                }
            }
        }
    }


    private void Throw()
    {
        if (currentObject == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Q))
        {

            if (currentThrowForce <= maxThrowForce)
            {
                currentThrowForce += throwForceIncreaseSpeed * Time.deltaTime;
            }
        }

        if (currentThrowForce > maxThrowForce)
        {
            currentThrowForce = maxThrowForce;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            currentObject.transform.parent = null;

            currentObjectRb.isKinematic = false;
            currentObjectRb.AddForce(playerCamera.transform.forward * currentThrowForce, ForceMode.Impulse);

            foreach (Collider collider in currentObject.GetComponents<Collider>())
            {
                collider.enabled = true;
            }
            

            currentObject = null;
            currentObjectRb = null;

            currentThrowForce = 0;

        }
    }
}
