using System;

namespace WhatToDo
{
    public class Activity
    {
        public string Name { get; set; }
        public TimeSpan TimeUsage { get; set; }
        public string Type { get; set; }
        public bool Outdoor { get; set; }
    }
}
