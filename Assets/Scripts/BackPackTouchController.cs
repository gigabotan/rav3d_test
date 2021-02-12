using UnityEngine;
using UnityEngine.UI;

namespace rav3d
{
    public class BackPackTouchController : MonoBehaviour
    {
        public GameObject Panel = null;
        public Button Button = null;
        private bool isOpen = false;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isOpen)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(Button.GetComponent<RectTransform>(),
                    Input.mousePosition))
                {
                    Toggle();
                }
            }

            if (Input.GetMouseButtonUp(0) && isOpen)
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            Panel.gameObject.SetActive(!Panel.gameObject.activeSelf);
            Button.gameObject.SetActive(!Button.gameObject.activeSelf);
            isOpen = !isOpen;
        }
    }
}
