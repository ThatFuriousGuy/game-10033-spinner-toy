using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;

namespace sandhu_harsimer_spinner_toy.Objects
{
    public class Spinner
    {
        Vector2 middle_position = new Vector2();
        float center_size = 110f;
        float ring_outer = 180f;
        float ring_width = 40f;
        Color main_color = Color.Yellow;
        int hurt_timer = 0;
        Color[] hurt_color_ramp = [Color.Yellow, new(255, 201, 0), new(255, 99, 1), new(255, 62, 35), new(255, 29, 6), Color.Red];

        SpinnerKnob knob = new SpinnerKnob();

        public void Setup()
        {
            middle_position.X = 400;
            middle_position.Y = 300;
            knob.Setup(middle_position.X, middle_position.Y, center_size*1.2f);
        }

        public void Update()
        {
            knob.Update();
            draw_outer_ring(middle_position);
            draw_self(middle_position);
            handle_hurt_color();
        }
        public float get_knob_speed()
        {
            return knob.spin_speed;
        }
        public void handle_hurt_color()
        {
            if (hurt_timer > -1)
            {
                main_color = hurt_color_ramp[hurt_timer/2];
                hurt_timer -= 1;
            }
        }

        public void draw_self(Vector2 position)
        {
            Draw.LineSize = 1;
            Draw.FillColor = main_color;
            Draw.Circle(position, center_size);
        }

        public void draw_outer_ring(Vector2 position)
        {
            Draw.LineSize = 1;
            Draw.FillColor = Color.Gray;
            Draw.Circle(position, ring_outer);
            Draw.FillColor = Color.White;
            Draw.Circle(position, ring_outer - ring_width);
        }

        public void draw_knob()
        {
            knob.draw_needle();
        }

        // Each hit reverses the spin and speeds it up a little bit
        public void on_hit()
        {
            knob.flip_direction();
            knob.change_speed(0.15f);
        }
        public void change_knob_speed(float speed, bool force_set)
        {
            knob.change_speed(speed, force_set);
        }

        public float get_angle()
        {
            return knob.get_angle();
        }
        public Vector2 get_center()
        {
            return middle_position;
        }
        public float get_ring_middle()
        {
            return ring_outer - ring_width / 2;
        }
        public void hit_missed()
        {
            hurt_timer = 10;
        }
    }
}