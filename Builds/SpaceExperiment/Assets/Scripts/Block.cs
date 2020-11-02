using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingBlocks
{
    public class Block : MonoBehaviour
    {
        public bool isInteract = false;

        public float centerRadius;
        public Collider _Collider;
        public Outline _Outline;


        public Vector3[] Faces;
        public int CurrentFace;
        public Vector3[] SnapPointsOut;


        public delegate void RayHit(RaycastHit hit);
        public event RayHit OnRayHit;


        // Start is called before the first frame update
        void Start()
        {
            if (!_Outline) { _Outline = this.GetComponent<Outline>(); }
            if (!_Collider) { _Collider = this.GetComponent<Collider>(); }
        }

        // Update is called once per frame



        private void OnMouseOver()
        {
            Block[] childList = GetComponentsInChildren<Block>(true);
            foreach(Block _block in childList)
            {
                _block._Outline.enabled = true;
            }


            isInteract = true;
        }
        private void OnMouseExit()
        {
            Block[] childList = GetComponentsInChildren<Block>(true);
            foreach (Block _block in childList)
            {
                _block._Outline.enabled = false;
            }


            isInteract = false;
        }



        public void TriggerRayHit(RaycastHit hit)
        {
            if(OnRayHit != null)
            {
                FindFace(hit);
                OnRayHit(hit);
            }
        }

        public void FindFace(RaycastHit hit)
        {
            Vector3 _origin = hit.point;

            List<Common.Distance> _distanceList = new List<Common.Distance>();

            for (int i = 0; i < Faces.Length; i++)
            {
                float _distance = Vector3.Distance(_origin, Faces[i]);
                _distanceList.Add(new Common.Distance(_distance, i));
            }

            //sort distances
            _distanceList.Sort(delegate (Common.Distance t1, Common.Distance t2)
            {
                return (t1.distance.CompareTo(t2.distance));
            });
                


            CurrentFace = _distanceList[0].index;

        }

    }
}