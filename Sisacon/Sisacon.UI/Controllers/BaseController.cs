using System.IO;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    public class BaseController : ApiController
    {
        public byte[] ConvertHttpContextToByte(Stream stream, int length)
        {
            byte[] fileData = null;

            using (var binary = new BinaryReader(stream))
            {
                fileData = binary.ReadBytes(length);
            }

            return fileData;
        }
    }
}
