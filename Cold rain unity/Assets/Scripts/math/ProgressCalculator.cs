﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.math
{
    public class ProgressCalculator
    {
        private static int minlevel = 1;
        private static int maxlevel = 50;
        private static double increase = 300.0;
        private static double difference = 1.5;
        private static double divider = 4;
        private static double div = 8.0f;

        /// <summary>
        /// Returns a dictionary of the curve
        /// </summary>
        /// <returns>Dictionary int level, experience double</returns>
        public static Dictionary<int, double> Curve()
        {
            Dictionary<int, double> lvlExpValues = new Dictionary<int, double>(); //lvl:exp

            double points = 0;
            double output = 0;

            for (int lvl = minlevel; lvl <= maxlevel+1; lvl++)
            {
                points += Math.Floor(lvl + increase * Math.Pow(difference, lvl / div));
                output = (int)Math.Floor(points / divider);
                if (lvl >= minlevel)

                    output = Math.Floor(points / divider);
                lvlExpValues.Add(lvl, output);
            }
            lvlExpValues[1] = 0;

            return lvlExpValues;
        }

        public static int GetExperienceByLevel(int level)
        {
            return (int)Math.Floor(Curve()[level]);
        }

        /// <summary>
        /// Returns the minumum experience for the given level
        /// </summary>
        /// <param name="level">Level</param>
        /// <returns></returns>
        //public static int getExperienceByLevel(int level)
        //{
        //    double points = 0;
        //    double output = 0;
        //
        //    for (int lvl = minlevel; lvl <= level; lvl++)
        //    {
        //        points += Math.Floor(lvl + increase
        //                * Math.Pow(difference, lvl / div));
        //        if (lvl >= level)
        //        {
        //            return (int)Math.Floor(output);
        //        }
        //        output = (int)Math.Floor(points / divider);
        //    }
        //    return 0;
        //}

        /// <summary>
        /// Returns the level of the given experience
        /// </summary>
        /// <param name="experience">Experience</param>
        /// <returns>int Level</returns>
        public static int GetLevelByExperience(double experience)
        {
            double points = 0;
            double output = 0;

            for (int lvl = minlevel; lvl <= maxlevel; lvl++)
            {
                points += Math.Floor(lvl + increase * Math.Pow(difference, lvl / div));
                output = (int)Math.Floor(points / divider);
                if (lvl >= minlevel)
                {
                    output = Math.Floor(points / divider);
                }
                if (experience <= output)
                {
                    return lvl - 1;
                }
            }
            return 0;
        }
    }
}
