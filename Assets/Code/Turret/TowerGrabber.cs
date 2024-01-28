using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.UI;

namespace com.vintagerockets.untitledtowerdefense.towers
{
    public class TowerGrabber : MonoBehaviour
    {
        [SerializeField] private InputAction mouseClickAction;
        [SerializeField] private GameObject turretPrefab;
        private GameObject currentTurret;

        private void Start()
        {
            mouseClickAction.started += ctx => HandleClickInput(ctx);
        }

        void OnEnable()
        {
            mouseClickAction.Enable();
        }

        void OnDisable()
        {
            mouseClickAction.Disable();
        }

        private void HandleClickInput(CallbackContext ctx)
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 500, 1);
            if (!hit.transform) return;
            bool grabbing = hit.transform.root.gameObject == gameObject;
            if (grabbing && !currentTurret)
            {
                currentTurret = Instantiate(turretPrefab, null, true);
                currentTurret.transform.position = hit.point + Vector3.up * 2;
            }
            else if (currentTurret)
            {
                if (hit.transform.root.CompareTag("Torret Anchor"))
                {
                    currentTurret.transform.position = hit.transform.root.position + Vector3.up * 2;
                    currentTurret.transform.GetChild(0).gameObject.SetActive(true);
                }
                else Destroy(currentTurret);
                currentTurret = null;
            }
        }

        private void Update()
        {
            if (!currentTurret) return;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 500, 1);
            currentTurret.transform.position = hit.point + Vector3.up * 2;
        }

    }
}
