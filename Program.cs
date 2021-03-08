using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

public enum CommandType {deflate, inflate}
class Program
{
    static CommandType command;   
    static int blockSize;
    static string infile = "notes.txt";
    static string outfile = "notes_out.comp";

    static void Main(string[] args)
    {
        blockSize = int.Parse(args[0]);
        // steps 1, 2
        string hexString = ByteArrayToHexString(FileToByteArray(infile));
        IEnumerable<string> blocks = SplitToBlocks(hexString, blockSize);
        StringBuilder codeString = new StringBuilder();
        foreach(var block in blocks)
        {
            (int, int) entry = GetEntry(block).ToValueTuple();
            System.Console.WriteLine(entry);
            codeString.Append(entry.Item1.ToString() + entry.Item2.ToString());
        }
        System.Console.WriteLine(codeString.ToString());
    }

    public static IEnumerable<string> SplitToBlocks(string str, int blockSize)
    {
        return Enumerable.Range(0, str.Length / blockSize)
            .Select(i => str.Substring(i * blockSize, blockSize));
    }
    public static byte[] FileToByteArray(string fileName)
    {
        return File.ReadAllBytes(fileName);
    }
    public static string ByteArrayToHexString(byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
        {
            hex.AppendFormat("{0:X2}", b);
        }        
        return hex.ToString();
    }

    public static Tuple<int, int> GetEntry(string block)
    {        
        int index = 0;
        int entryIndex = -1;
        do
        {
            PiBaBoPlo.Run(index);
            index++;
            System.Console.WriteLine("Block is: " + block);
            entryIndex = PiBaBoPlo.HexPid.ToString().IndexOf(block); 
            //TODO: нужно изменить расчет entryIndex (сейчас он считает относительно последнего hex)
        }while(entryIndex == -1);
        System.Console.WriteLine("Number of runs: " + index);

        return Tuple.Create(entryIndex, block.Length);
    }

    public static void Compress()
    {
        
    }

    public static void Decompress()
    {

    }
 

}