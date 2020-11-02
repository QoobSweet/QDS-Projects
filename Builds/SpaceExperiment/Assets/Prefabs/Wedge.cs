using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuildingBlocks;

namespace BuildingBlocks
{
    public class Wedge : Block
    {
        // Start is called before the first frame update
        void Start()
        {
            Faces = new Vector3[4];
            OnRayHit += UpdateSnapPoints;
        }

        // Update is called once per frame
        void Update()
        {
            centerRadius = this.transform.localScale.x;

            if (isInteract)
            {
                UpdateFacePositions();
            }
        }

        public void UpdateFacePositions()
        {
            Faces[0] = this.transform.position + new Vector3(-centerRadius, 0, 0);
            Faces[1] = this.transform.position + new Vector3(centerRadius, 0, 0);
            Faces[2] = this.transform.position + new Vector3(0, centerRadius, 0);
            Faces[3] = this.transform.position + new Vector3(0, 0, -centerRadius);
        }

        public void UpdateSnapPoints(RaycastHit hit)
        {
            int Face = CurrentFace;
            Vector3[] r = new Vector3[9];
            Vector3 cOrigin = Faces[Face];


            int i = 0;
            switch (Face)
            {
                case 0:
                    foreach (var v2 in FaceOffsets())
                    {
                        Vector3 offset = new Vector3(0, v2.x, v2.y);
                        r[i] = offset + cOrigin;
                        i++;
                    }
                    break;
                case 1:
                    foreach (var v2 in FaceOffsets())
                    {
                        Vector3 offset = new Vector3(0, v2.x, v2.y);
                        r[i] = offset + cOrigin;
                        i++;
                    }
                    break;
                case 2:
                    foreach (var v2 in FaceOffsets())
                    {
                        Vector3 offset = new Vector3(v2.x, 0, v2.y);
                        r[i] = offset + cOrigin;
                        i++;
                    }
                    break;
                case 3:
                    foreach (var v2 in FaceOffsets())
                    {
                        Vector3 offset = new Vector3(v2.x, 0, v2.y);
                        r[i] = offset + cOrigin;
                        i++;
                    }
                    break;
            }

            SnapPointsOut = r;
        }

        public Vector2[] FaceOffsets()
        {
            Vector2[] r = new Vector2[]
            {
            new Vector2(0,0),
            new Vector2(centerRadius,-centerRadius),
            new Vector2(centerRadius,0),
            new Vector2(centerRadius,centerRadius),
            new Vector2(0,centerRadius),
            new Vector2(-centerRadius,centerRadius),
            new Vector2(-centerRadius,0),
            new Vector2(-centerRadius,-centerRadius),
            new Vector2(0,-centerRadius)
            };
            return r;
        }
    }
}