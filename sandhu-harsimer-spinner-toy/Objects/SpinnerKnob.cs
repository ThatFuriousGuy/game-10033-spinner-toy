using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace sandhu_harsimer_spinner_toy.Objects
{
    public class SpinnerKnob
    {
        float origin_x = 0f;
        float origin_y = 0f;
        float start_distance = 40f;  // where the first dot sits (edge of the yellow circle)
        float angle = 0f;
        float spin_speed = 2f;
        // 1 = going right, -1 going left. serves as a multiplier to affect direction
        int dir = 1;
        float max_speed = 12f;
        // how many circles to make the knob
        int dot_count = 8;
        // the width of the knob line
        float dot_radius = 10f;
        // gap between each dot
        float dot_spacing = 8f;

        public void Setup(float originx, float originy, float _start_distance)
        {
            origin_x = originx;
            origin_y = originy;
            start_distance = _start_distance;
        }
        public void Update()
        {
            update_position(spin_speed, dir);
        }

        // Some dumb math to make each dot sit a little further out along the same angle from each other
        // spaced out equally
        public void draw_needle()
        {
            for (int i = 0; i < dot_count; i++)
            {
                float distance = start_distance + i * dot_spacing;
                // SCREW COS AND SIN IM DECENT AT MATH, DOESNT MEAN I HATE IT
                float x = origin_x + MathF.Cos(angle) * distance;
                float y = origin_y + MathF.Sin(angle) * distance;

                draw_self(x, y, dot_radius);
            }
        }

        public void draw_self(float x, float y, float radius)
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Red;
            Draw.Circle(x, y, radius);
        }

        public void update_position(float _speed, int _dir)
        {
            angle += _speed * _dir * Time.DeltaTime;

            // OMG I HATE MATH I HATE PI THIS TOOK TOO LONG TO FIGURE OUT
            if (angle >= MathF.PI * 2)
            {
                angle -= MathF.PI * 2;
            }
            if (angle < 0)
            {
                angle += MathF.PI * 2;
            }
        }

        public void flip_direction()
        {
            dir *= -1;
        }

        public void change_speed(float amount)
        {
            spin_speed += amount;

            if (spin_speed > max_speed)
            {
                spin_speed = max_speed;
            }
            if (spin_speed < 2f)
            {
                spin_speed = 2f;
            }
        }

        public float get_angle()
        {
            return angle;
        }
    }
}