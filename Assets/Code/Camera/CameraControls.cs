using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using static UnityEngine.InputSystem.InputAction;

namespace com.vintagerockets.untitledtowerdefense
{
    public class CameraControls : MonoBehaviour
    {
        [SerializeField] private InputAction mouseClickAction;
        [SerializeField] private InputAction mouseDragAction;
        [SerializeField] private InputAction mouseScrollAction;
        [SerializeField, Range(5f, 20)] private float sensitivityDrag = 20;
        [SerializeField, Range(0.5f, 2)] private float sensitivityScroll = 1.5f;
        private bool clicking;

        private void Start()
        {
            mouseClickAction.started += ctx => HandleClickInput(ctx);
            mouseClickAction.canceled += ctx => HandleClickInput(ctx);
            mouseDragAction.performed += ctx => HandleDragInput(ctx);
            mouseScrollAction.performed += ctx => HandleScrollInput(ctx);
        }

        void OnEnable()
        {
            mouseClickAction.Enable();
            mouseDragAction.Enable();
            mouseScrollAction.Enable();
        }

        void OnDisable()
        {
            mouseClickAction.Disable();
            mouseDragAction.Disable();
            mouseScrollAction.Disable();
        }

        private void HandleClickInput(CallbackContext ctx)
        {
            clicking = ctx.started;
        }

        private void HandleDragInput(CallbackContext ctx)
        {
            if (!clicking) return;
            Vector2 value = mouseDragAction.ReadValue<Vector2>();
            transform.Translate(-value.x * sensitivityDrag * Time.deltaTime, 0, -value.y * sensitivityDrag * Time.deltaTime, Space.Self);
        }

        private void HandleScrollInput(CallbackContext ctx)
        {
            float value = mouseScrollAction.ReadValue<Vector2>().y;
            if (value > 0) transform.Translate(0, -sensitivityScroll, sensitivityScroll, Space.Self);
            else if (value < 0) transform.Translate(0, sensitivityScroll, -sensitivityScroll, Space.Self);
        }

    }
}
