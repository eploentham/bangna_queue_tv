﻿using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace bangna_queue_tv
{
    class IniFile
    {
        FileIniDataParser parser;
        IniData data;
        public IniFile(String filename)
        {
            parser = new FileIniDataParser();
            parser.Parser.Configuration.CommentString = "#";
            if (File.Exists(filename))
            {
                data = parser.ReadFile(filename);
            }
        }
        public String getIni(String section, String node)
        {
            string ret = data[section][node];
            return ret;
        }
        public void setIni(String section, String node, String value)
        {
            data[section][node] = value;
            parser.WriteFile(section, data);
        }
    }
}
