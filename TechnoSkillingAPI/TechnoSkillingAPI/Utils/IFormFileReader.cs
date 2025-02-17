namespace TechnoSkillingAPI.Utils
{
    public static class IFormFileReader
    {
        public static string ReadContent(IFormFile inpFile)
        {
            string FileContent = String.Empty;
            try
            {
                int ChunkSize = 1024;
                int BytesRead = 0;
                int Offset = 0;
                Stream fs = inpFile.OpenReadStream();
                MemoryStream ms = new MemoryStream();
                do
                {
                    byte[] arrBytes = new byte[ChunkSize];
                    BytesRead = fs.Read(arrBytes, 0, ChunkSize);
                    if (BytesRead != 0)
                    {
                        ms.Write(arrBytes);
                    }
                    Offset += BytesRead;
                }
                while (BytesRead != 0);
                FileContent = Convert.ToBase64String(ms.ToArray());
                fs.Close();
            }
            catch (Exception ex)
            {

            }
            return FileContent;
        }
    }
}
