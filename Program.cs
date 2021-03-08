using System;
using System.IO;
using System.IO.Compression;

 public enum CommandType {deflate, inflate}
class Program
{
    static CommandType command;   
    static int blocksize;
    static string infile = "notes.txt";
    static string outfile = "notes_out.comp";

    static void Main(string[] args)
    {
        // foreach(var bt in FileToByteArray(infile))
        // {
        //     Console.Write(bt + " ");
        // }
        // (int, int) entry = GetEntry(int.Parse(args[0])).ToValueTuple();
        // System.Console.WriteLine($"Blockstring entry is: {entry.Item1}, entry length is: {entry.Item2}");
        PiBaBoPlo.Run(int.Parse(args[0])); // arg is position int num
    }

    public static Tuple<int, int> GetEntry(int block)
    {
        string blockString = block.ToString();
        
        int index = 0;
        int entryIndex = -1;
        do
        {
            PiBaBoPlo.Run(index);
            index++;
            entryIndex = PiBaBoPlo.Pid.ToString().IndexOf(blockString); 
        }while(entryIndex == -1);
        System.Console.WriteLine("Number of runs: " + index);

        return Tuple.Create(entryIndex, blockString.Length);
    }

    public static void Compress()
    {
        
    }

    public static void Decompress()
    {

    }


    public static byte[] FileToByteArray(string fileName)
    {
        byte[] buff = null;
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fs);
        long numBytes = new FileInfo(fileName).Length;
        buff = br.ReadBytes((int) numBytes);
        return File.ReadAllBytes(fileName);
    }
 

}