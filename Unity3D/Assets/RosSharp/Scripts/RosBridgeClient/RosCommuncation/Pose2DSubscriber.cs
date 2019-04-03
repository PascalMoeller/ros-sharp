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

using UnityEngine.Events;

/*==================*\
|*   Local Usings   *|
\*==================*/

using RosPose2D = RosSharp.RosBridgeClient.Messages.Geometry.Pose2D;

namespace RosSharp.RosBridgeClient
{
    /*=============================*\
    |*   CLASS: Pose2DSubscriber   *|
    \*=============================*/

    public class Pose2DSubscriber : Subscriber<RosPose2D>
    {
        /*================================*\
        |*   Protected Member Functions   *|
        \*================================*/

            /*===============*\
            |*   Overrides   *|
            \*===============*/

            protected override void ReceiveMessage(RosPose2D message)
            {
                CustomRosConverter.Pose2DToPose2D(pose2D, message);
                OnMessageReceive.Invoke();
            }

        /*==============================*\
        |*   Private Member Variables   *|
        \*==============================*/

            /*====================*\
            |*   Runtime memory   *|
            \*====================*/

            public Pose2D pose2D;
            public UnityEvent OnMessageReceive;
    }
}