using APS.Entity;
using APS.ScriptsSQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.ProgramEvents
{
    public class StartProgram
    {
        private readonly object _lockProcess = new object();
        private readonly string Name;
        List<string> lines = new List<string>();
        string line;
        int count = 0;

        public StartProgram(string name)
        {
            Name = name;
        }

        public void Start()
        {
            while (count < 1)
            {
                lock (_lockProcess)
                {
                    if (Name != "Unknown")
                    {
                        Query query = new Query(Name);
                        foreach (AgrotoxicosEntity agrotoxico in query.GetAllByName())
                        {
                            line = $"Nome: { agrotoxico.Nome }, \nGrupo: { agrotoxico.Grupo }, \nClassificacao: {agrotoxico.Classificacao}, \nNivel: { agrotoxico.Nivel }\n";
                            lines.Add(line);
                        }
                        count += 1;
                        WriteTextAsync();
                    }
                }
            }
        }

        public void WriteTextAsync()
        {
            string[] toSave = lines.ToArray();
            string path = Directory.GetCurrentDirectory() + @"\DataToShow";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if(!string.IsNullOrEmpty(Name))
                File.WriteAllLines(path + @"\ShowTo" + Name + ".txt", toSave);
        }
    }
}
