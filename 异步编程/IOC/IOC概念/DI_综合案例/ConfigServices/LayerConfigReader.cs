using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
    internal class LayerConfigReader:IConfigReader
    {
        private readonly IEnumerable<IConfigSevrvice> services;

        public LayerConfigReader(IEnumerable<IConfigSevrvice> services)
        {
            this.services = services;
        }
        public string GetValue(string name)
        {
            string value = null;
            foreach (var service in services)
            {
                string newValue = service.GetValue(name);
                if (newValue != null)
                {
                    value = newValue;
                }
            }

            return value;
        }
    }
}
