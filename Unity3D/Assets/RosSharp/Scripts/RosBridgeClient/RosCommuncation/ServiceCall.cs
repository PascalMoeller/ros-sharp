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
using UnityEngine.Events;

namespace RosSharp.RosBridgeClient
{
    public abstract class ServiceCall : MonoBehaviour {}

    /*========================*\
    |*   CLASS: ServiceCall   *|
    \*========================*/

    [RequireComponent(typeof(RosConnector))]
    public abstract class ServiceCall<TRequest, TResponse> : ServiceCall
                                            where TRequest : Message
                                           where TResponse : Message
    {
        /*=====================*\
        |*   Unity Functions   *|
        \*=====================*/

        void Update ()
        {
            if(submit)
            {
                DeclareRequest(ref m_request);
                GetComponent<RosConnector>().RosSocket.CallService<TRequest, TResponse>(service, ServiceResponseCallback, m_request);
            }
        }

        /*=============================*\
        |*   Public Member Variables   *|
        \*=============================*/

            /*=====================*\
            |*   Internal memory   *|
            \*=====================*/

            public UnityEvent OnServiceResponseEvent = new UnityEvent();

            /*====================*\
            |*   Runtime memory   *|
            \*====================*/

            public string service   = "";
            
        /*================================*\
        |*   Protected Member Functions   *|
        \*================================*/

            /*===============*\
            |*   Abstracts   *|
            \*===============*/

            protected abstract void DeclareRequest(ref TRequest request);
            protected abstract void ProcessResponse(TResponse response);

        /*==============================*\
        |*   Private Member Variables   *|
        \*==============================*/

            /*====================*\
            |*   Runtime memory   *|
            \*====================*/

            [HideInInspector]
            [SerializeField] private bool submit        = false;
            [SerializeField] private TRequest m_request = default;

        /*==============================*\
        |*   Private Member Functions   *|
        \*==============================*/
            
            /*==============*\
            |*   Callback   *|
            \*==============*/

            void ServiceResponseCallback(TResponse response)
            { 
                ProcessResponse(response);
                OnServiceResponseEvent.Invoke();
            }
    }
}