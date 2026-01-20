using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material _highlightMaterial;
    [SerializeField] private Material _defaultMaterial;

    private Transform _selection;

    private void Update()
    {
        if (_selection != null)
        {
            var _selectionRenderer = _selection.GetComponent<Renderer>();
            _selectionRenderer.material = _defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = _highlightMaterial;
                }
                _selection = selection;
            }

        }
    }

    
}
