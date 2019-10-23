using CSAc4yClass.Class;
using GuidLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSSerializer
{
    public class Program
    {
        public const string PATH = "d:\\Server\\Visual_studio\\";

        static void SerializeAsXml2TextFile(Type aType, Object aObject, String aObjectName, String aPath)
        {
            XmlSerializer _xmlSerializer = new XmlSerializer(aType);
            TextWriter _textWriter = new StreamWriter(aPath + aObjectName + "@" + aType.Name + ".xml");
            _xmlSerializer.Serialize(_textWriter, aObject);
            _textWriter.Close();
        }
        static void Main(string[] args)
        {
            GUID _guid = new GUID();
            Student student = new Student();
            try
            {
                _guid = (GUID)typeof(Student).GetCustomAttributes(typeof(GUID), true).First();
            } catch (Exception _exception)
            {

            }
            PropertyInfo[] _propInf = typeof(Student).GetProperties();

            // 1. verzió:
            Ac4yClass _ac4yClass1 = new Ac4yClass(student.GetType().Name);
            _ac4yClass1.Ancestor = student.GetType().BaseType.Name;
            _ac4yClass1.GUID = _guid.getGuid();
            foreach(var _prop in _propInf)
            {
                _ac4yClass1.PropertyList.Add(new Ac4yProperty(_prop.Name, _prop.PropertyType.Name));
            }
            SerializeAsXml2TextFile(_ac4yClass1.GetType(), _ac4yClass1, _ac4yClass1.Name, PATH);
        }
    }
}
