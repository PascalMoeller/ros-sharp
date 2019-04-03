/*
© TGW Logistics Group GmbH, 2019
Author: Pascal Möller (Pascal.Moeller@tgw-group.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

/*==================*\
|*   Unity Usings   *|
\*==================*/

using UnityEngine;
using UnityEditor;

namespace RosSharp.RosBridgeClient
{
    /*==============================*\
    |*   CLASS: ServiceCallEditor   *|
    \*==============================*/

    [CustomEditor(typeof(ServiceCall), true)]
    public class ServiceCallEditor : Editor
    {
        /*=====================*\
        |*   Unity Functions   *|
        \*=====================*/

        private void OnEnable()
        {
            submit = serializedObject.FindProperty("submit");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();
            submit.boolValue = GUILayout.Button("Submit");
            serializedObject.ApplyModifiedProperties();
        }

        /*==============================*\
        |*   Private Member Variables   *|
        \*==============================*/

            /*====================*\
            |*   Runtime memory   *|
            \*====================*/

            private SerializedProperty submit = null;
    }
}