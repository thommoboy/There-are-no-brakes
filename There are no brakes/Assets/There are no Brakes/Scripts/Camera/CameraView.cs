using UnityEngine;
using System.Collections;

	public class CameraView : MonoBehaviour {

         public Camera m_Camera; // the camera
		 public GameObject[] m_Targets; // targets to encapsulate (must have a collider)
         public float m_CameraSmoothTime = 1f; // smoothing time for camera zoom
         public Vector3 m_Origin; // origin point (0, 0, 0)
         public float m_MinDistance; // minimum distance from targets
         public float m_MaxDistance; // maximum distance from targets (Mathf.Infinity if < minimumDistance)
         public Vector2 m_Padding; // padding around gameobjects in visible viewport
         public Vector2 m_OffsetCenter; // offset the camera center
         public bool m_LookAtCenter; // rotate to look at center of all targets along origin
         public Rect m_BoundingRect; // never go outside this, if area of rect is 0 then ignore

         void Start() {
             m_Targets = GameObject.FindGameObjectsWithTag("Player");

             // set up camera
             if (m_Camera == null) {
                 m_Camera = Camera.main;
             }
         }

         // cumulative velocity
         private Vector3 cameraVelocity;
         void Update() {
             // quick return
             if (m_Targets.Length == 0) return;
             // bounding rect to encapsulate all targets
             Rect viewport = new Rect();
             // set up initial viewport for 1 target
             {
                 var target = m_Targets[0].GetComponent<CapsuleCollider>().bounds;
                 var center = target.center;
                 var extent = target.extents;
                 viewport.xMin = center.x - extent.x;
                 viewport.xMax = center.x + extent.x;
                 viewport.yMin = center.y - extent.y;
                 viewport.yMax = center.y + extent.y;
             }
             // add in the other targets
             for (var i = 1; i < m_Targets.Length; ++i) {
                 //if (!m_Targets[i].GetComponent<PlayerController>().isAlive) continue;
                 var target = m_Targets[i].GetComponent<CapsuleCollider>().bounds;
                 var center = target.center;
                 var extent = target.extents;

                 var lowX = center.x - extent.x;
                 var highX = center.x + extent.x;
                 if (lowX < viewport.xMin) viewport.xMin = lowX;
                 if (highX > viewport.xMax) viewport.xMax = highX;

                 var lowY = center.y - extent.y;
                 var highY = center.y + extent.y;
                 if (lowY < viewport.yMin) viewport.yMin = lowY;
                 if (highY > viewport.yMax) viewport.yMax = highY;
             }

             // desired height
             var frustumHeight = Mathf.Max(viewport.height + m_Padding.y, (viewport.width + m_Padding.x) / m_Camera.aspect);
             // required distance for desired height
             var distance = Mathf.Clamp(frustumHeight * 0.5f / Mathf.Tan(m_Camera.fieldOfView * 0.5f * Mathf.Deg2Rad), m_MinDistance, m_MaxDistance > m_MinDistance ? m_MaxDistance : Mathf.Infinity);

             // smooth camera zoom
             Vector3 targetCamPos;
             // (Mathf.Approximately(m_BoundingRect.width, 0f) || Mathf.Approximately(m_BoundingRect.height, 0f))
             bool useBoundingRect = !Mathf.Approximately(m_BoundingRect.width * m_BoundingRect.height, 0f);
             var minX = Mathf.NegativeInfinity;
             var maxX = Mathf.Infinity;
             var minY = Mathf.NegativeInfinity;
             var maxY = Mathf.Infinity;
             if (useBoundingRect) {
                 minX = m_BoundingRect.x;
                 maxX = m_BoundingRect.xMax;
                 minY = m_BoundingRect.y;
                 maxY = m_BoundingRect.yMax;
             }
             targetCamPos = new Vector3(Mathf.Clamp(viewport.center.x + m_OffsetCenter.x, minX, maxX), Mathf.Clamp(viewport.center.y + m_OffsetCenter.y, minY, maxY), m_Origin.z - distance);
             
             var currentCamPos = m_Camera.transform.position;
             m_Camera.transform.position = Vector3.SmoothDamp(currentCamPos, targetCamPos, ref cameraVelocity, m_CameraSmoothTime * Time.deltaTime);

             // look at center if necessary
             if (m_LookAtCenter) {
                 m_Camera.transform.LookAt(new Vector3(viewport.center.x, viewport.center.y, m_Origin.z));
             }
         }
     }