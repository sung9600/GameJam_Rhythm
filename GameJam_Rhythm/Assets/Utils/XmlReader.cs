using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class XmlReader : MonoBehaviour
{
    public static ArrayList ReadByTag(string filename, string mainTag,string subTag=null)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load($"./Assets/Resources/Xml/{filename}");
        if (xml == null)
        {
            Debug.LogError("Null XML");
            return null;
        }
        XmlNode root = xml.SelectSingleNode(mainTag);
        //Debug.Log($"mainTAG:{root.Name}");
        if (subTag != null)
        {
            ArrayList result = new ArrayList();
            XmlNodeList target = root.SelectSingleNode(subTag).ChildNodes;

            foreach(XmlNode node in target)
            {
                result.Add(node.InnerText);
            }
            result.Add(0);
            return result;
        }
        return null;
        //ArrayList로  return
    }
}
