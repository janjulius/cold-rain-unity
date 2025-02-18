﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.util
{
    public static class MathUtilities
    {
        public static float RoundToNearestHalf(float num)
        {
            float result = (float)Math.Round(num * 2, MidpointRounding.AwayFromZero) / 2;
            if((result % 1) == 0)
            {
                if (num > result)
                    result += .5f;
                else if (num < result)
                    result -= .5f;
                else
                    result -= .5f;
            }
            return result;
        }
        
        /// <summary>
        /// returns vector 2 with x an y rounded up (or down) to nearest .5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Vector2 RoundToNearestHalves(Vector2 input) => 
           new Vector2(RoundToNearestHalf(input.x), RoundToNearestHalf(input.y));

    }
}
