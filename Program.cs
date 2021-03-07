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
        PiBaBoPlo.Run(0);
        PiBaBoPlo.Run(1);
        PiBaBoPlo.Run(2);
        PiBaBoPlo.Run(3);
    }

    public static Tuple<int, int> GetEntry(int block)
    {
        return Tuple.Create(0,0);
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