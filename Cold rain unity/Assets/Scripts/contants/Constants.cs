﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.contants
{
    /// <summary>
    /// Constants values
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Size of the tiles in unity measurements
        /// </summary>
        public static float TILE_SIZE = 1f;

        /// <summary>
        /// The default size of the inventory
        /// </summary>
        public static int INVENTORY_SIZE = 50;

        /// <summary>
        /// The amount of skills
        /// </summary>
        public static int SKILLS_AMOUNT = 7;

        public static bool DEVELOPER_MODE = true;

        public static string COMMAND_PREFIX = "/";
    }
}
