using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Marios_Bros.Input
{
    class KeyboordInput : FlatRedBall.Input.InputDeviceBase
    {
        float HorizontalInput = 0; //that a public value i overworked it

        float VerticalInput = 0;

        public void HorinzontalInputa(float inputa) //the a is intentional
        {
            HorizontalInput = inputa;
        }
        public void VerticalInputb(float inputb)
        {
            VerticalInput = inputb;
        }
        protected override float GetHorizontalValue()
        {
            return HorizontalInput;
        }
        protected override float GetVerticalValue()
        {
            return VerticalInput;
        }
    }
}
