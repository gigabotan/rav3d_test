using rav3d.Model;
using UnityEngine;

namespace rav3d
{
    public class ItemComponent : MonoBehaviour
    {
        public Item ItemData;
        private Rigidbody _rigidbody = null;

        public bool IsFree() => !_rigidbody.isKinematic;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Drop()
        {
            transform.parent = null;
            transform.localPosition = transform.localPosition + Vector3.right * 3;
            
            Debug.Log("Drop");
            _rigidbody.isKinematic = false;
        }

        public void Pick()
        {
            Debug.Log("Pick");
            _rigidbody.isKinematic = true;
            transform.localPosition = Vector3.zero;
        }
    }
}