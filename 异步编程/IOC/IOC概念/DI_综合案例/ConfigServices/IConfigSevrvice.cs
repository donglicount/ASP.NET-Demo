﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
    public interface IConfigSevrvice
    {
        public string GetValue(string name);
    }
}
