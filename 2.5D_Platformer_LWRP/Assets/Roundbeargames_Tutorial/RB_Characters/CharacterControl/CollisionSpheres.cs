﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class CollisionSpheres : MonoBehaviour
    {
        public CharacterControl owner;
        public List<GameObject> BottomSpheres = new List<GameObject>();
        public List<GameObject> FrontSpheres = new List<GameObject>();

        public void SetColliderSpheres()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = Instantiate(Resources.Load("ColliderEdge", typeof(GameObject))
                    , Vector3.zero, Quaternion.identity) as GameObject;
                BottomSpheres.Add(obj);
                obj.transform.parent = this.transform.Find("Bottom");
            }

            Reposition_BottomSpheres();

            for (int i = 0; i < 10; i++)
            {
                GameObject obj = Instantiate(Resources.Load("ColliderEdge", typeof(GameObject))
                    , Vector3.zero, Quaternion.identity) as GameObject;
                FrontSpheres.Add(obj);
                obj.transform.parent = this.transform.Find("Front");
            }

            Reposition_FrontSpheres();
        }

        public void Reposition_FrontSpheres()
        {
            float bottom = owner.boxCollider.bounds.center.y - (owner.boxCollider.bounds.size.y / 2f);
            float top = owner.boxCollider.bounds.center.y + (owner.boxCollider.bounds.size.y / 2f);
            float front = owner.boxCollider.bounds.center.z + (owner.boxCollider.bounds.size.z / 2f);

            FrontSpheres[0].transform.localPosition = new Vector3(0f, bottom + 0.05f, front) - this.transform.position;
            FrontSpheres[1].transform.localPosition = new Vector3(0f, top, front) - this.transform.position;

            float interval = (top - bottom + 0.05f) / 9;

            for (int i = 2; i < FrontSpheres.Count; i++)
            {
                FrontSpheres[i].transform.localPosition = new Vector3(0f, bottom + (interval * (i - 1)), front)
                    - this.transform.position;
            }
        }

        public void Reposition_BottomSpheres()
        {
            float bottom = owner.boxCollider.bounds.center.y - (owner.boxCollider.bounds.size.y / 2f);
            float front = owner.boxCollider.bounds.center.z + (owner.boxCollider.bounds.size.z / 2f);
            float back = owner.boxCollider.bounds.center.z - (owner.boxCollider.bounds.size.z / 2f);

            BottomSpheres[0].transform.localPosition = new Vector3(0f, bottom, back) - this.transform.position;
            BottomSpheres[1].transform.localPosition = new Vector3(0f, bottom, front) - this.transform.position;

            float interval = (front - back) / 4;

            for (int i = 2; i < BottomSpheres.Count; i++)
            {
                BottomSpheres[i].transform.localPosition = new Vector3(0f, bottom, back + (interval * (i - 1)))
                    - this.transform.position;
            }
        }
    }
}