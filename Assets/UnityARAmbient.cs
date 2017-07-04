using System.Runtime.InteropServices;
using UnityEngine.XR.iOS;

namespace UnityEngine.XR.iOS
{
    public class UnityARAmbient : MonoBehaviour
    {

        private Light l;
		private UnityARSessionNativeInterface m_Session;

        public void Start()
        {
#if !UNITY_EDITOR
            l = GetComponent<Light>();
			m_Session = UnityARSessionNativeInterface.GetARSessionNativeInterface ();
#endif
        }
#if !UNITY_EDITOR
        public void Update()
        {
            // Convert ARKit intensity to Unity intensity
            // ARKit ambient intensity ranges 0-2000
            // Unity ambient intensity ranges 0-8 (for over-bright lights)
            float newai = m_Session.GetARAmbientIntensity();
            l.intensity = newai / 1000.0f;
        }
#endif
    }
}
