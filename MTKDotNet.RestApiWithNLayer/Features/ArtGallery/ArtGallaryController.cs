using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MTKDotNet.RestApiWithNLayer.Features.ArtGallery
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtGalleryController : ControllerBase
    {
        private async Task<ArtGalleryModel> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("ArtGallery.json");
            var model = JsonConvert.DeserializeObject<ArtGalleryModel>(jsonStr);
            return model!;
        }
    }
}
