using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace sandhu_harsimer_spinner_toy.Objects
{
    public class Spinner
    {
        Vector2 middle_position = new Vector2();

        SpinnerKnob knob = new SpinnerKnob();
        public void Setup()
        {
            middle_position.X = 200;
            middle_position.Y = 200;
            knob.Setup(middle_position);
        }
        public void Update()
        {
            draw_outer_ring(middle_position);
            draw_self(middle_position);
            knob.Update();
        }

        public void draw_self(Vector2 position, float size = 40.0f)
        {
            Draw.FillColor = Color.Yellow;
            Draw.Circle(position, size);
        }
        public void draw_outer_ring(Vector2 position, float size = 60.0f, float ring_width = 15.0f)
        {
            Draw.FillColor = Color.Gray;
            Draw.Circle(position, size);
            float new_size = size-ring_width;
            Draw.FillColor = Color.White;
            Draw.Circle(position, new_size);
        }
    }
}
