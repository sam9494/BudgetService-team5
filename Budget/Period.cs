﻿using System;

namespace Budget
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        private DateTime Start { get; set; }
        private DateTime End   { get; set; }

        public int OverlappingDays(Period another)
        {
            if (Start > End)
            {
                return 0;
            }
            if (End < another.Start || Start > another.End)
            {
                return 0;
            }

            var overlappingEnd = End < another.End
                ? End
                : another.End;
            var overlappingStart = Start > another.Start
                ? Start
                : another.Start;

            return (overlappingEnd - overlappingStart).Days + 1;
        }
    }
}