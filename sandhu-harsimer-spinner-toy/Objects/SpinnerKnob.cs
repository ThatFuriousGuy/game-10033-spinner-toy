using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace sandhu_harsimer_spinner_toy.Objects
{
    public class SpinnerKnob
    {
        Vector2 origin_point = new Vector2();
        float distance_from_origin = 60f;
        float angle = 0f;
        float spin_speed = 1f;
        // 1 = going right, -1 going left. serves as a multiplier to affect direction
        int dir = 1;
        public void Setup(Vector2 origin)
        {
            origin_point = origin;
        }
        public void Update()
        {
            // This is where it will draw a rectangle shape that is angled away from the origin,
            // and rotates around the origin at a set speed, in the direction of dir

        }
        public void draw_self(Vector2 position, float width, float height, float _angle)
        {

        }
        public void update_position(Vector2 position, float _speed, int _dir)
        {

        }
    }
}
