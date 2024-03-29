/**********************************
 Wave concatenation class

 CopyRights Ehab Essa 2006
***********************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
namespace bangna_queue_tv.object1
{
    class WaveIO
    {
        public int length;
        public short  channels;
        public int samplerate;
        public int DataLength;
        public short BitsPerSample;

        private  void WaveHeaderIN(string spath)
        {
            FileStream fs = new FileStream(spath, FileMode.Open, FileAccess.Read);
         
            BinaryReader br = new BinaryReader(fs);
            length = (int)fs.Length - 8;
            fs.Position = 22;
            channels = br.ReadInt16();
            fs.Position = 24;
            samplerate = br.ReadInt32();
            fs.Position = 34;

            BitsPerSample = br.ReadInt16();
            DataLength = (int)fs.Length - 44;
            br.Close ();
            fs.Close();

        }
  
        private  void WaveHeaderOUT(string sPath)
        {
            FileStream fs = new FileStream(sPath, FileMode.Create, FileAccess.Write );

            BinaryWriter bw = new BinaryWriter(fs);
            fs.Position = 0;
            bw.Write(new char[4] { 'R', 'I', 'F', 'F' });
       
            bw.Write(length);
          
            bw.Write(new char[8] {'W','A','V','E','f','m','t',' '});
          
            bw.Write((int)16);
  
            bw.Write((short)1);
            bw.Write(channels);
        
            bw.Write(samplerate );
       
            bw.Write((int)(samplerate * ((BitsPerSample * channels) / 8)));
        
            bw.Write((short )((BitsPerSample * channels) / 8));
       
            bw.Write(BitsPerSample);
      
            bw.Write(new char[4] {'d','a','t','a'});
            bw.Write(DataLength);
            bw.Close();
            fs.Close();
        }
        private MemoryStream WaveHeaderOUTStream()
        {
            //FileStream fs = new FileStream(sPath, FileMode.Create, FileAccess.Write);
            MemoryStream fs = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(fs);
            fs.Position = 0;
            bw.Write(new char[4] { 'R', 'I', 'F', 'F' });

            bw.Write(length);

            bw.Write(new char[8] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });

            bw.Write((int)16);

            bw.Write((short)1);
            bw.Write(channels);

            bw.Write(samplerate);

            bw.Write((int)(samplerate * ((BitsPerSample * channels) / 8)));

            bw.Write((short)((BitsPerSample * channels) / 8));

            bw.Write(BitsPerSample);

            bw.Write(new char[4] { 'd', 'a', 't', 'a' });
            bw.Write(DataLength);
            bw.Close();
            
            return fs;
        }
        public void Merge(string[] files, string outfile)
        {
            WaveIO wa_IN = new WaveIO();
            WaveIO wa_out = new WaveIO();

            wa_out.DataLength = 0;
            wa_out.length = 0;


            //Gather header data
            foreach (string path in files)
            {
                wa_IN.WaveHeaderIN(@path);
                wa_out.DataLength += wa_IN.DataLength;
                wa_out.length += wa_IN.length;

            }

            //Recontruct new header
            wa_out.BitsPerSample = wa_IN.BitsPerSample;
            wa_out.channels = wa_IN.channels;
            wa_out.samplerate = wa_IN.samplerate;
            wa_out.WaveHeaderOUT(@outfile);

            foreach (string path in files)
            {
                FileStream fs = new FileStream(@path, FileMode.Open, FileAccess.Read);
                byte[] arrfile = new byte[fs.Length - 44];
                fs.Position = 44;
                fs.Read(arrfile, 0, arrfile.Length);
                fs.Close();

                FileStream fo = new FileStream(@outfile, FileMode.Append, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fo);
                bw.Write(arrfile);
                bw.Close();
                fo.Close();
            }
        }
        public void Merge(List<String> files, string outfile)
        {
            WaveIO wa_IN = new WaveIO();
            WaveIO wa_out = new WaveIO();

            wa_out.DataLength = 0;
            wa_out.length = 0;


            //Gather header data
            foreach (string path in files)
            {
                wa_IN.WaveHeaderIN(@path);
                wa_out.DataLength += wa_IN.DataLength;
                wa_out.length += wa_IN.length;

            }

            //Recontruct new header
            wa_out.BitsPerSample = wa_IN.BitsPerSample;
            wa_out.channels = wa_IN.channels;
            wa_out.samplerate = wa_IN.samplerate;
            wa_out.WaveHeaderOUT(@outfile);

            foreach (string path in files)
            {
                FileStream fs = new FileStream(@path, FileMode.Open, FileAccess.Read);
                byte[] arrfile = new byte[fs.Length - 44];
                fs.Position = 44;
                fs.Read(arrfile, 0, arrfile.Length);
                fs.Close();

                FileStream fo = new FileStream(@outfile, FileMode.Append, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fo);
                bw.Write(arrfile);
                bw.Close();
                fo.Close();
            }
        }
        public MemoryStream MergetoStream(List<String> files)
        {
            WaveIO wa_IN = new WaveIO();
            WaveIO wa_out = new WaveIO();

            wa_out.DataLength = 0;
            wa_out.length = 0;


            //Gather header data
            foreach (string path in files)
            {
                wa_IN.WaveHeaderIN(@path);
                wa_out.DataLength += wa_IN.DataLength;
                wa_out.length += wa_IN.length;

            }

            //Recontruct new header
            wa_out.BitsPerSample = wa_IN.BitsPerSample;
            wa_out.channels = wa_IN.channels;
            wa_out.samplerate = wa_IN.samplerate;
            MemoryStream fsout = wa_out.WaveHeaderOUTStream();

            foreach (string path in files)
            {
                FileStream fs = new FileStream(@path, FileMode.Open, FileAccess.Read);
                byte[] arrfile = new byte[fs.Length - 44];
                fs.Position = 44;
                fs.Read(arrfile, 0, arrfile.Length);
                fs.Close();

                //FileStream fo = new FileStream(@outfile, FileMode.Append, FileAccess.Write);
                //BinaryWriter bw = new BinaryWriter(fsout);
                //bw.Write(arrfile);
                //bw.Close();
                //fo.Close();
                BinaryWriter bw = new BinaryWriter(fsout);
                bw.Write(arrfile);
                bw.Close();
            }
            fsout.Position = 0;
            return fsout;
        }

    }
}
