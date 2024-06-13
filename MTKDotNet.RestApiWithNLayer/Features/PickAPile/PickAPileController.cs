using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace MTKDotNetCore.RestApiWithNLayer.Features.PickAPile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private async Task<PickAPileData> GetDataAsync()
        {
            try
            {
                string jsonStr = await System.IO.File.ReadAllTextAsync("PickAPile.json");
                var model = JsonConvert.DeserializeObject<PickAPileData>(jsonStr);
                return model;
            }
            catch (System.Exception ex)
            {
                // Log the exception
                return null;
            }
        }

        // api/PickAPile/questions
        [HttpGet("questions")]
        public async Task<IActionResult> Questions()
        {
            var model = await GetDataAsync();
            if (model == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
            return Ok(model.Questions);
        }

        [HttpGet("{questionNo}/{no}")]
        public async Task<IActionResult> Answer(int questionNo, int no)
        {
            var model = await GetDataAsync();
            if (model == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }

            var answer = model.Answers.FirstOrDefault(x => x.QuestionId == questionNo && x.AnswerId == no);
            if (answer == null)
            {
                return NotFound("Answer not found");
            }

            return Ok(answer);
        }
    }

    public class PickAPileData
    {
        public Question[] Questions { get; set; }
        public Answer[] Answers { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string QuestionDesp { get; set; }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerImageUrl { get; set; }
        public string AnswerName { get; set; }
        public string AnswerDesp { get; set; }
        public int QuestionId { get; set; }
    }
}
