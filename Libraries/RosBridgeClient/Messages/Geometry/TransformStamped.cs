﻿/*
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

/*=================*\
|*   Json Usings   *|
\*=================*/

using Newtonsoft.Json;

/*================*\
|*   ROS Usings   *|
\*================*/

using RosSharp.RosBridgeClient.Messages.Standard;

namespace RosSharp.RosBridgeClient.Messages.Geometry
{
    /*=============================*\
    |*   CLASS: TransformStamped   *|
    \*=============================*/

    public class TransformStamped : Message
    {
        [JsonIgnore]
        public const string RosMessageName  = "geometry_msgs/TransformStamped";
        public Header header                = new Header();
        public string child_frame_id        = "";
        public Transform transform          = new Transform();
    }
}
