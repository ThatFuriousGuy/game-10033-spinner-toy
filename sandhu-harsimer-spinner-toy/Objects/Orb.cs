using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace sandhu_harsimer_spinner_toy.Objects
{
    public class Orb
    {
        float positionx = 0f;
        float positiony = 0f;
        float distance_from_spinner = 0f;
        float spinner_x = 0f;
        float spinner_y = 0f;
        float angle = 0f;
        float orb_radius = 20f;

        // once the orb is hit, the next orb spawns randomly around the spinner
        // the orb should be within the outer ring
        public void Setup(float centerx, float centery, float ring_distance)
        {
            spinner_x = centerx;
            spinner_y = centery;
            distance_from_spinner = ring_distance;
            reposition(0);
        }
        public void Update()
        {
            draw_self();
        }
        public void draw_self()
        {
            Draw.LineSize = 1;
            Draw.FillColor = Color.Yellow;
            Draw.Circle(positionx, positiony, orb_radius);
        }
        // Gets called once the user times the knob on top of the orb
        public void hit(float knob_angle)
        {
            reposition(knob_angle);
        }

        // Checks how well the knob lines up with the orb
        // 0 = miss, 1 = hit
        public bool check_hit(float knob_angle)
        {
            float diff = knob_angle - angle;
            diff = diff % (MathF.PI * 2);
            if (diff > MathF.PI)
            {
                diff -= MathF.PI * 2;
            }
            if (diff < -MathF.PI)
            {
                diff += MathF.PI * 2;
            }
            diff = MathF.Abs(diff);

            // How wide the orb is and if the knob is on it
            float tolerance = orb_radius / distance_from_spinner;

            if (diff > tolerance)
            {
                return false;
            }
            return true;
        }
        // Gets called to reposition itself somewhere again
        public void reposition(float knob_angle)
        {
            angle = knob_angle + MohawkGame2D.Random.Float(1f, MathF.PI * 2 - 1f);
            // Makes sure the angle is within here to keep it proper distance from spinner
            if (angle >= MathF.PI * 2)
            {
                angle -= MathF.PI * 2;
            }

            // Turn the angle into a position on the ring
            positionx = spinner_x + MathF.Cos(angle) * distance_from_spinner;
            positiony = spinner_y + MathF.Sin(angle) * distance_from_spinner;
        }
    }
}