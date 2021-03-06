﻿using System.Collections.Generic;
using System.Linq;
using System;

namespace OnCallculator
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<OnCallSession> Sessions { get; set; } = new List<OnCallSession>();

        public void AddOnCall(DateTime evStart, DateTime evEnd)
        {
            Sessions.Add(new OnCallSession(evStart.ToLocalTime(), evEnd.ToLocalTime()));
        }

        public double TotalHours()
        {
            return Sessions.Sum(x => x.TotalHours());
        }

        public OnCallCalculation CalculateOnCall()
        {
            var totalOnCall = new OnCallCalculation();
            foreach (var session in Sessions)
            {
                totalOnCall.Add(session.CalculateOnCall());
            }

            return totalOnCall;
        }
    }
}
