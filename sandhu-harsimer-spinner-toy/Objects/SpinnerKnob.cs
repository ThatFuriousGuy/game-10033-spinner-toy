using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace sandhu_harsimer_spinner_toy.Objects
{
    public class SpinnerKnob
    {
        // how many faded copies trail behind the knob
        int trail_count = 5;
        float origin_x = 0f;
        float origin_y = 0f;
        // where the first dot sits (edge of the yellow circle)
        float start_distance = 40f;
        float angle = 0f;
        public float spin_speed = 2f;
        // 1 = going right, -1 going left. serves as a multiplier to affect direction
        int dir = 1;
        float max_speed = 50f;
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
        public void draw_needle()
        {
            // Drawing the trail first so the actual knob can draw on top of it
            draw_trail();
            draw_needle_at(angle, dot_radius, Color.Red);
        }

        void draw_trail()
        {
            // The gaps between each "trail" spreads out more the faster the knob gets
            float trail_gap = spin_speed * 0.025f;

            for (int i = trail_count; i > 0; i--)
            {
                // the "back" of the knob depends on the dir, so I have to account for it changing
                float ghost_angle = angle - dir * trail_gap * i;

                // As it goes on, they get smaller and smaller phade to give a feeling of a "trail"
                int alpha = 150 - i * 25;
                float ghost_radius = dot_radius * (1f - i * 0.1f);

                draw_needle_at(ghost_angle, ghost_radius, new Color(200, 0, 0, alpha));
            }
        }
        // Some dumb math to make each dot sit a little further out along the same angle from each other
        // spaced out equally
        void draw_needle_at(float needle_angle, float radius, Color color)
        {
            for (int i = 0; i < dot_count; i++)
            {
                float distance = start_distance + i * dot_spacing;
                // I HATE MATH SCRE YOU COS AND SIN JUST BECAUSE IM DECENT AT IT DOESNT MEAN I LIKE IT
                float x = origin_x + MathF.Cos(needle_angle) * distance;
                float y = origin_y + MathF.Sin(needle_angle) * distance;

                draw_self(x, y, radius, color);
            }
        }

        public void draw_self(float x, float y, float radius, Color color)
        {
            Draw.LineSize = 0;
            Draw.FillColor = color;
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
        // Not really complicated, literally "turn around"
        public void flip_direction()
        {
            dir *= -1;
        }
        // Gets faster for each successful hit. resets back to default if missed
        // "force_set" is used to directly replace the speed instead of adding on top of the current speed
        public void change_speed(float amount, bool force_set = false)
        {
            if (force_set == false)
            {
                spin_speed += amount;
            }
            else if (force_set)
            {
                spin_speed = amount;
            }

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