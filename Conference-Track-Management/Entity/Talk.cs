using System;
using System.Collections.Generic;
using System.Text;

namespace Conference_Track_Management.Entity
{
    public class Talk
    {
        private int _duration;
        public string Name { get; set; }

        public int Duration
        {
            get => IsLightning ? 5 : _duration;
            set => _duration = value;
        }

        public bool IsLightning { get; set; }
    }
}
