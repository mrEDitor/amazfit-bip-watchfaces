﻿using WatchFace.Elements.StatusElements;
using WatchFace.Utils;

namespace WatchFace.Elements
{
    public class Status
    {
        [RawParameter(Id = 1)]
        public Switch Bluetooth { get; set; }

        [RawParameter(Id = 2)]
        public Flag Alarm { get; set; }

        [RawParameter(Id = 3)]
        public Flag Lock { get; set; }

        [RawParameter(Id = 4)]
        public Flag DoNotDisturb { get; set; }
    }
}