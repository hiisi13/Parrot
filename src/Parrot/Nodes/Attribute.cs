using Parrot.Infrastructure;

namespace Parrot.Nodes
{
    public class Attribute : AbstractNode
    {
        public string Key { get; internal set; }
        public Statement Value { get; internal set; }

        //public ValueType ValueType { get; internal set; }

        public Attribute(IHost host, string key, Statement value) : base(host)
        {
            Key = key;

            //var valueTypeProvider = host.DependencyResolver.Resolve<IValueTypeProvider>();
            //var result = valueTypeProvider.GetValue(value);

            //ValueType = result.Type;
            //Value = result.Value;
            Value = value;
        }
        
        public override bool IsTerminal
        {
            get { return false; }
        }

        //public override string ToString()
        //{

        //    if (ValueType == ValueType.Property)
        //    {
        //        return string.Format("{0}=\"{1}\"", Key, Value);
        //    }

        //    return string.Format("{0}={1}", Key, Value);
        //}
    }
}