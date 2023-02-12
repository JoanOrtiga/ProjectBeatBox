using System;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;
using UnityEngine.UI;

namespace _Anark.Scripts.Game.CardView
{
    //TODO
    public class GridLayoutWorldSpace : MonoBehaviour
    {
        [Serializable]
        public struct Borders
        {
            public Transform topLeft;
            public Transform topRight;
            public Transform botLeft;
            public Transform botRight;
        }
        [SerializeField] private Borders borders;

        [SerializeField] private int maxElementsPerRow;
        [SerializeField] private Vector2 elementSize;
        [SerializeField] private Vector2 offset;
        [SerializeField] private TextAnchor childAlignment;

        private List<Transform> gridElements = new List<Transform>();

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
              
                gridElements.Add(transform.GetChild(i));
            }
            
            SetGrid();
        }

        private void SetGrid()
        {
            Vector2[] elementFinalPositions = new Vector2[gridElements.Count];

            Debug.Log(borders.topLeft.position.x + " " + borders.topRight.position.x);
            float xSize = borders.topRight.localPosition.x - borders.topLeft.localPosition.x;
            Debug.Log(xSize);
            var unitsPerRow = Mathf.FloorToInt((xSize + offset.x) / (elementSize.x + offset.x));
            Debug.Log(gridElements.Count + " " + unitsPerRow);
            var neededRows = Mathf.CeilToInt(gridElements.Count / unitsPerRow);
            var centerOffset = (xSize - unitsPerRow * elementSize.x - (unitsPerRow - 1) * offset.x) / 2;

            int currentElementIndex = 0;
            for (int i = 0; i < neededRows; i++)
            {
                if (currentElementIndex >= elementFinalPositions.Length - 1)
                    break;
                
                for (int e = 0; e < gridElements.Count; e++)
                {
                    float pos = e * (elementSize.x + offset.x); //+ centerOffset;
                    
                    elementFinalPositions[currentElementIndex] = new Vector2(pos, 0);
                    currentElementIndex++;

                    if (currentElementIndex >= elementFinalPositions.Length - 1)
                        break;
                }

            }

            for (int i = 0; i < gridElements.Count; i++)
            {
                gridElements[i].position = elementFinalPositions[i];
            }
        }
    }
}