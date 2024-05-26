using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetTrainingBatch4.RestApiWithNLayer.Features.MyanmarProverbs;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbsController : ControllerBase
{
    private async Task<Rootobject> GetDataFromApi()
    {
        //HttpClient client = new HttpClient();
        //var response = await client.GetAsync("https://raw.githubusercontent.com/sannlynnhtun-coding/Myanmar-Proverbs/main/MyanmarProverbs.json");
        //if (!response.IsSuccessStatusCode) return null;

        //string jsonStr = await response.Content.ReadAsStringAsync();
        //var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
        //return model!;

        var jsonStr = await System.IO.File.ReadAllTextAsync("Quotlets.json");
        var model = JsonConvert.DeserializeObject<Rootobject>(jsonStr);
        return model!;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var model = await GetDataFromApi();
        return Ok(model.Property1);
    }

    [HttpGet("{titleName}")]
    public async Task<IActionResult> Get(string titleName)
    {
        var model = await GetDataFromApi();
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
        if (item is null) return NotFound();

        var titleId = item.TitleId;
        var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);

        List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
        {
            ProverbId = x.ProverbId,
            ProverbName = x.ProverbName,
            TitleId = x.TitleId
        }).ToList();

        return Ok(lst);
    }

    [HttpGet("{titleId}/{proverbId}")]
    public async Task<IActionResult> Get(int Id, int UserId)
    {
        var model = await GetDataFromApi();
        var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == Id && x.UserId == UserId);

        return Ok(item);
    }
}



public class Rootobject
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public string Id { get; set; }
    public int UserId { get; set; }
    public string Quotes { get; set; }
    public string ImageUrl { get; set; }
}

public class Rootobject
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public Link[] Links { get; set; }
}

public class Link
{
    public string Name { get; set; }
    public string Link { get; set; }
}
