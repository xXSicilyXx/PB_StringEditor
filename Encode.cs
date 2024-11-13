using System;
using System.Collections.Generic;
using System.IO;

namespace StringEditor
{
  public class Encode
  {
    private byte[] raw;
    private string filePath;
    public List<byte[]> bytes = new List<byte[]>();
    public Encode(string filePath)
    {
      this.filePath = filePath;
      using (FileStream input = new FileStream(filePath, FileMode.Open))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
          this.raw = binaryReader.ReadBytes(Convert.ToInt32(input.Length));
      }
    }
    public void ReadBytes()
    {
      int count = 2048;
      using (FileStream input = new FileStream(this.filePath, FileMode.Open))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
        {
          for (int index = 0; index < this.raw.Length; index += count)
          {
            int num1 = index;
            int num2 = index + count;
            int length = 2048;
            if (num2 > this.raw.Length) length = this.raw.Length - num1;
            this.bytes.Add(new byte[length]);
            this.bytes[index == 0 ? 0 : index / 2048] = binaryReader.ReadBytes(count);
          }
        }
      }
    }
    public void Decrypt()
    {
      for (int index = 0; index < this.bytes.Count; ++index)
        this.Shift(this.bytes[index], 3);
    }
    public void Save()
    {
      using (FileStream output = new FileStream(this.filePath, FileMode.Open))
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
        {
          for (int index = 0; index < this.bytes.Count; ++index)
            binaryWriter.Write(this.bytes[index]);
          binaryWriter.Flush();
        }
      }
    }

    private void Shift(byte[] buffer, int bits)
    {
      int length = buffer.Length;
      byte num1 = buffer[0];
      for (int index = 0; index < length; ++index)
      {
        byte num2 = index < length - 1 ? buffer[index + 1] : num1;
        buffer[index] = (byte) ((int) num2 >> 8 - bits | (int) buffer[index] << bits);
      }
    }
  }
}
