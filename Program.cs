// using System;
using System.IO;
using System.Xml;

namespace MYFIRSTAPP
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string ROOT_PATH = System.IO.Directory.GetCurrentDirectory();
			string INPUT_PATH = $"{ROOT_PATH}\\input";
			string OUTPUT_PATH = $"{ROOT_PATH}\\output";
			// Console.WriteLine($"ROOT_PATH: {ROOT_PATH} \nINPUT_PATH: {INPUT_PATH} \nOUTPUT_PATH: {OUTPUT_PATH}");

			try {
				// Crea un objeto xml
				XmlDocument doc = new XmlDocument();
				
				// Carga el xml de la carpeta input en el objeto
				doc.Load($"{INPUT_PATH}\\Axis_Ax00_StarWheel.XML");
				
				// root = Nodo raiz
				XmlNode root = doc.DocumentElement;

				// Carga todos los nodos Variable dentro de Apartment con atributo ShortName = zenOn(R) process variable list
				XmlNodeList nodeList = root.SelectNodes("//Apartment[@ShortName='zenOn(R) process variables list']/Variable");

				var variableCount = nodeList.Count;
				Console.WriteLine($"{variableCount} variables encontradas.\n\n");

				int i = 1;
				// Lista cada una de las variables dentro de nodeList
				foreach(XmlElement v in nodeList){
					// Si el atributo de la variable isComple = TRUE no listarla
					if (v.GetAttribute("IsComplex") == "TRUE") continue;

					// Seleccionar atributos
					string typeId = v.GetAttribute("TypeID");
					string shortName = v.GetAttribute("ShortName");
					// Seleccionar nodos hijos
					string tagName = v.SelectSingleNode("Tagname").InnerText.Trim();
					string netAddr = v.SelectSingleNode("NetAddr").InnerText.Trim();
					string dataBlock = v.SelectSingleNode("DataBlock").InnerText.Trim();
					string offset = v.SelectSingleNode("Offset").InnerText.Trim();
					string bitAddr = v.SelectSingleNode("BitAddr").InnerText.Trim();
					string alignment = v.SelectSingleNode("Alignment").InnerText.Trim();
					string symbAddr = v.SelectSingleNode("SymbAddr").InnerText.Trim();

					Console.WriteLine($"Variable nro: {i}\nTypeID: {typeId}\nTagname: {tagName}\nNetAddr: {netAddr} DataBlock: {dataBlock} Offset: {offset} BitAddr: {bitAddr} Alignment: {alignment} SymbAddr: {symbAddr}\n\n");
					i++;
				}
			}
			catch {

			}
		}
	}
}