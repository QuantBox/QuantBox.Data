using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SevenZip;
using System.Windows.Forms;
using QuantBox.Data.Serializer.V2;

namespace SelfDecode
{
    class Program
    {
        private const string TargetDirectory = "SelfDecodeData";
        private static string RootDiretory;
        private static string[] TargetFileExtents = { "7z", "pd0" };
        static void Main(string[] args)
        {
            //RootDiretory = @"C:\Users\fouvy\Desktop\tmpData";
            RootDiretory = System.Environment.CurrentDirectory;
            ReadDirectorys(RootDiretory);
        }
        /// <summary>
        /// 读取文件夹极其子文件夹下面全部数据文件
        /// </summary>
        private static void ReadDirectorys(string pathChosen)
        {
            Console.WriteLine("Directory: {0}", pathChosen);
            string[] files = Directory.GetFiles(pathChosen);
            foreach(var file in files)
            {
                string filename = Path.GetFileName(file);
                string[] fe = filename.Split('.');
                if(fe.Length == 1)
                {
                    Console.WriteLine("File: OK, {0}", file);
                    ReadFromFile2Csv(file);
                }
                else if(TargetFileExtents.Contains(fe[1]))
                {
                    Console.WriteLine("File: OK, {0}", file);
                    ReadFromFile2Csv(file);
                }
                else
                {
                    Console.WriteLine("File: Failed, {0}", file);
                }
            }
            string[] dirs = Directory.GetDirectories(pathChosen);
            foreach(var dir in dirs)
            {
                ReadDirectorys(dir);
            }
        }

        private static void ReadFromFile2Csv(string pathChosen)
        {
            List<PbTickView> listTickView = ReadFromFile(pathChosen);
            string targetDir = Path.Combine(RootDiretory, TargetDirectory);
            if(!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            if(listTickView != null)
            {
                string newfilename = Path.GetFileNameWithoutExtension(pathChosen) + ".csv";
                string targetFile = Path.Combine(targetDir, newfilename);
                SaveCSV(listTickView, targetFile);
            }
        }
        private static string[] CSVHeaderLine = {"TradingDay","ActionDay","Time","LastPrice","Volume","OpenInterest","Turnover","AveragePrice"};
        private static string[] CSVHeaderLineEx = {"AskPrice","AskSize","BidPrice","BidSize"};
        private static void SaveCSV(List<PbTickView> listTickView, string fullPathFile)
        {
            FileStream fs = new FileStream(fullPathFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";
            // 头行第一部分
            for(int i = 0; i < CSVHeaderLine.Length; ++i)
            {
                data += CSVHeaderLine[i] + ",";
            }
            // 第二部分根据档位自动计算
            //if(listTickView.Count > 0)
            //{
            //    int nDp = listTickView[0].DepthList.Count;
            //}
            for (int i = 0; i < CSVHeaderLineEx.Length; ++i)
            {
                data += CSVHeaderLineEx[i];
                if(i != CSVHeaderLineEx.Length-1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);
            // 写数据
            foreach(var tickView in listTickView)
            {
                data = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                    tickView.TradingDay, 
                    tickView.ActionDay, 
                    getTime(tickView),
                    tickView.LastPrice,
                    tickView.Volume,
                    tickView.OpenInterest,
                    tickView.Turnover,
                    tickView.AveragePrice,
                    tickView.DepthList[1].Price,
                    tickView.DepthList[1].Size,
                    tickView.DepthList[0].Price,
                    tickView.DepthList[0].Size
                    );
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }
        private static string getTime(PbTickView pbTickView)
        {
            return String.Format("{0}:{1}:{2}.{3}", 
                (pbTickView.Time_HHmm/100).ToString("D2"),
                (pbTickView.Time_HHmm%100).ToString("D2"),
                (pbTickView.Time_____ssf__ / 10).ToString("D2"),
                ((pbTickView.Time_____ssf__ % 10) * 100 + pbTickView.Time________ff).ToString("D3")
                );
        }
        private static List<PbTickView> ReadFromFile(string pathChosen)
        {
            Tuple<Stream, string, double> tuple = ReadToStream(pathChosen);

            IEnumerable<PbTick> listTickData;
            List<PbTickView> listTickView;

            if (tuple == null)
            {
                return null;
            }

            Stream stream = tuple.Item1;
            try
            {
                QuantBox.Data.Serializer.PbTickSerializer pts = new QuantBox.Data.Serializer.PbTickSerializer();
                listTickData = pts.Read(stream);

                PbTickCodec Codec = new PbTickCodec();

                listTickView = Codec.Data2View(listTickData, true);

                return listTickView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        private static Tuple<Stream, string, double> ReadToStream(string pathChosen)
        {
            int cnt = 0;
            SevenZipExtractor extractor;
            try
            {
                extractor = new SevenZipExtractor(pathChosen);
                cnt = extractor.ArchiveFileData.Count;
            }
            catch (SevenZipException ex)
            {
                MessageBox.Show(ex.ToString());
                return DirectReadToStream(pathChosen);
            }
            catch (ArgumentException ex)
            {
                return DirectReadToStream(pathChosen);
            }
            catch (Exception ex)
            {
                return DirectReadToStream(pathChosen);
            }

            List<string> listFileNames = new List<string>();

            for (int i = 0; i < cnt; i++)
            {
                listFileNames.Add(extractor.ArchiveFileNames[i]);
            }

            string fileName = "default";
            MemoryStream stream = new MemoryStream();

            try
            {
                extractor.ExtractFile(fileName, stream);
                stream.Position = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            double fileLength = stream.Length;

            Tuple<Stream, string, double> tuple = new Tuple<Stream, string, double>(stream, fileName, fileLength);
            return tuple;
        }

        private static Tuple<Stream, string, double> DirectReadToStream(string pathChosen)
        {
            FileStream stream = File.Open(pathChosen, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            FileInfo fi = new FileInfo(pathChosen);
            int index = pathChosen.LastIndexOf(@"\");
            string fileName = pathChosen.Substring(index + 1, pathChosen.Length - index - 1);
            double fileLength = (double)fi.Length;

            Tuple<Stream, string, double> tuple = new Tuple<Stream, string, double>(stream, fileName, fileLength);
            return tuple;
        }


    }
}
