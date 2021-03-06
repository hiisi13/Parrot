﻿namespace Parrot.Tests
{
    using System.Collections.Generic;
    using System.Dynamic;
    using NUnit.Framework;
    using Parrot.Infrastructure;
    using Parrot.Renderers.Infrastructure;

    [TestFixture]
    public class ExpandoObjectModelValueProviderTests
    {
        [Test]
        public void ExpandoObjectStringLiteral()
        {
            var valueType = ValueType.StringLiteral;
            dynamic property = "this is a string literal";
            var documentHost = new Dictionary<string, object>();

            IValueTypeProvider valueTypeProvider = new ValueTypeProvider();
            IModelValueProvider modelValueProvider = new ObjectModelValueProvider(valueTypeProvider);
            object result;
            modelValueProvider.GetValue(documentHost, null, valueType, property, out result);
            Assert.IsInstanceOf<string>(result);
            Assert.AreEqual(property, result as string);
        }

        [Test]
        public void Local()
        {
            var valueType = ValueType.Local;
            object property = "this";
            object model = new { Name = "Ben" };
            var documentHost = new Dictionary<string, object>();

            IValueTypeProvider valueTypeProvider = new ValueTypeProvider();
            IModelValueProvider modelValueProvider = new ObjectModelValueProvider(valueTypeProvider);
            object result;
            modelValueProvider.GetValue(documentHost, model, valueType, property, out result);

            Assert.AreEqual(model, result);
        }

        [Test]
        public void Keyword()
        {
            var valueType = ValueType.Keyword;
            object property = false;
            var documentHost = new Dictionary<string, object>();

            IValueTypeProvider valueTypeProvider = new ValueTypeProvider();
            IModelValueProvider modelValueProvider = new ObjectModelValueProvider(valueTypeProvider);
            object result;
            modelValueProvider.GetValue(documentHost, null, valueType, property, out result);

            Assert.AreEqual(property, result);
        }

        [Test]
        public void Property()
        {
            var valueType = ValueType.Property;
            object property = "Name";
            dynamic model = new ExpandoObject();
            model.Name = new ExpandoObject();
            model.Name = "Ben";
            var documentHost = new Dictionary<string, object>();

            IValueTypeProvider valueTypeProvider = new ValueTypeProvider();
            IModelValueProvider modelValueProvider = new ObjectModelValueProvider(valueTypeProvider);
            object result;
            modelValueProvider.GetValue(documentHost, model, valueType, property, out result);

            Assert.AreEqual("Ben", result);
        }

        [Test]
        public void NestedProperty()
        {
            var valueType = ValueType.Property;
            object property = "Name.FirstName";
            dynamic model = new ExpandoObject();
            model.Name = new ExpandoObject();
            model.Name.FirstName = "Ben";
            model.Name.LastName = "Dornis";
            var documentHost = new Dictionary<string, object>();

            IValueTypeProvider valueTypeProvider = new ValueTypeProvider();
            IModelValueProvider modelValueProvider = new ObjectModelValueProvider(valueTypeProvider);
            object result;
            modelValueProvider.GetValue(documentHost, model, valueType, property, out result);

            Assert.AreEqual("Ben", result);
        }
    }
}