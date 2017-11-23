﻿using WatchFace.Elements.BasicElements;
using WatchFace.Utils;

namespace WatchFace.Elements
{
    public class AnalogDialFace
    {
        [RawParameter(Id = 1)]
        public ClockHand Hours { get; set; }

        [RawParameter(Id = 2)]
        public ClockHand Minutes { get; set; }

        [RawParameter(Id = 3)]
        public ClockHand Seconds { get; set; }
    }
}