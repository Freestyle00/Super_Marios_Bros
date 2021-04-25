using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Marios_Bros.Input
{
    class KeyboordInput : FlatRedBall.Input.InputDeviceBase
    {
        protected override float GetHorizontalValue()
        {
            // Horizontal value is a value between 
            // -1 (left) and +1 (right)
            // By returning 1, the input device will
            // tell the Enemy to always walk to the right
            return 1;
        }
    }
}
