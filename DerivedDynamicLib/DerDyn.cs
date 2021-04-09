using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq;
using System.Text;

namespace DerivedDynamicLib
{
    public class DerDyn : DynamicObject
    {
        public string TagName { get; }

        private Dictionary<string, object> _attributes = new();
        
        public DerDyn(string tagName) 
        {
            TagName = tagName;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _attributes[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_attributes.TryGetValue(binder.Name, out object val))
            {
                result = val;
                return true;
            }
            result = null;
            return false;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _attributes.Keys.ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"<{TagName} ");
            foreach (KeyValuePair<string, object> kvp in _attributes)
            {
                sb.Append($"{kvp.Key}='{kvp.Value}' ");
            }
            sb.Append("/>");
            return sb.ToString();
        }
    }
}
