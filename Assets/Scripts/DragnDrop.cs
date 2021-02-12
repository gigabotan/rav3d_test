using UnityEngine;

namespace rav3d
{
    public class DragnDrop : MonoBehaviour
    {
        private bool _mouseState;
        private GameObject target;
        public Vector3 screenSpace;
        public Vector3 offset;
        
	
        // Update is called once per frame
        void Update ()
        {
            // Debug.Log(_mouseState);
            if (Input.GetMouseButtonDown (0)) {
                RaycastHit hitInfo;
                target = GetClickedObject(out hitInfo);
                if (target && !target.GetComponent<Rigidbody>().isKinematic) {
                    
                    _mouseState = true;
                    screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
                    offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                }
            }
            if (Input.GetMouseButtonUp (0)) {
                _mouseState = false;
            }
            if (_mouseState && !target.GetComponent<Rigidbody>().isKinematic) 
            {
                var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
                var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
                target.transform.position = curPosition;
            }
        }
	
	
        GameObject GetClickedObject (out RaycastHit hit)
        {
            GameObject target = null;
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
                target = hit.collider.gameObject;
            }

            if (target && target.GetComponent<Draggable>())
            {
                return target;
            }

            return null;
        }
    }
}