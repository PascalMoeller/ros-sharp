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

/*===================*\
|*   System Usings   *|
\*===================*/

using System;

/*================*\
|*   ROS Usings   *|
\*================*/

using Geometry = RosSharp.RosBridgeClient.Messages.Geometry;

namespace RosSharp.RosBridgeClient
{
    /*============================*\
    |*   CLASS: Pose2DPublisher   *|
    \*============================*/

    public class Pose2DPublisher : Publisher<Geometry.Pose2D>
    {
        /*=====================*\
        |*   Unity Functions   *|
        \*=====================*/

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            Pose2DToPose2D(message, data);
            Publish(message);
        }

        /*=============================*\
        |*   Public Member Variables   *|
        \*=============================*/

            /*====================*\
            |*   Runtime memory   *|
            \*====================*/

            public Pose2D data;
        
        /*==============================*\
        |*   Private Member Variables   *|
        \*==============================*/

            /*====================*\
            |*   Runtime memory   *|
            \*====================*/

            private Geometry.Pose2D message;

        /*==============================*\
        |*   Private Member Functions   *|
        \*==============================*/

            /*=================*\
            |*   Auxiliaries   *|
            \*=================*/

            private void InitializeMessage() { message = new Geometry.Pose2D(); }

            /*=================*\
            |*   Conversions   *|
            \*=================*/

            private void Pose2DToPose2D(Geometry.Pose2D dataOut, Pose2D dataIn)
            {
                // Set fields
                // ----------
                dataOut.x       =  dataIn.z;
                dataOut.y       = -dataIn.x;
                dataOut.theta   =  dataIn.theta;
            }
    }
}

/*===================*\
|*   CLASS: Pose2D   *|
\*===================*/

[Serializable]
public class Pose2D 
{
    public float z;
    public float x;
    public float theta;
}
