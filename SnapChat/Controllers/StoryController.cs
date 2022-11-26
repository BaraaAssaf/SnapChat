using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnapChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : Controller
    {
        private readonly IStoryService storyService;
        public StoryController(IStoryService storyService)
        {
            this.storyService = storyService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<Story_Snapchat>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateStory([FromBody] Story_Snapchat story_Snapchat)
        {
            return storyService.CreateStory(story_Snapchat);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<Story_Snapchat>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Updateisblock([FromBody] Story_Snapchat story_Snapchat)
        {
            return storyService.Updateisblock(story_Snapchat);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Story_Snapchat), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteStory(int id)
        {
            return storyService.DeleteStory(id);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Story_Snapchat>), StatusCodes.Status200OK)]
        
        public List<Story_Snapchat> GetAllStory()
        {
            return storyService.GetAllStory();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Story_Snapchat>), StatusCodes.Status200OK)]
        [Route("gettop10")]
        public List<Story_Snapchat> GetTop10()
        {
            return storyService.GetTop10();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Story_Snapchat>), StatusCodes.Status200OK)]
        [Route("get24hour")]
        public List<Story_Snapchat> Get24hour()
        {
            return storyService.Get24hour();
        }


        [HttpPost]
        [Route("uploadStory")]
        public Story_Snapchat uploadStory()
        {
            try
            {
                var file = Request.Form.Files[0];
                var filename = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullpath = Path.Combine("C:\\Users\\BARAA\\Desktop\\snapchat\\snapchat\\snapchat\\src\\assets\\img", filename);
                using (var stream = new FileStream(fullpath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Story_Snapchat item = new Story_Snapchat();
                item.Path = filename;
                return item;
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

    }
}
