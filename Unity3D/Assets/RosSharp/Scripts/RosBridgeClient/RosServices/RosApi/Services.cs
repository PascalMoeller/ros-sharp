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

/*================*\
|*   ROS Usings   *|
\*================*/

using RosSharp.RosBridgeClient.Services.RosApi;

namespace RosSharp.RosBridgeClient.Services
{
    /*=====================*\
    |*   CLASS: Services   *|
    \*=====================*/
    
    public class Services : ServiceCall<ServicesRequest, ServicesResponse>
    {
        /*=====================*\
        |*   Unity Functions   *|
        \*=====================*/

        void Start() { service = "/rosapi/services"; }

        /*================================*\
        |*   Protected Member Functions   *|
        \*================================*/

            /*===============*\
            |*   Overrides   *|
            \*===============*/
            
            protected override void DeclareRequest(ref ServicesRequest request) {}
            protected override void ProcessResponse(ServicesResponse response)  { services = response.services; }
            
        /*=============================*\
        |*   Public Member Variables   *|
        \*=============================*/

            /*====================*\
            |*   Runtime memory   *|
            \*====================*/

            [HideInInspector]
            public string[] services;
    }
}