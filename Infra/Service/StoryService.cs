using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
   public class StoryService : IStoryService
    {
        private readonly IStoryRepository storyRepository;
        public StoryService(IStoryRepository _storyRepository)
        {
            storyRepository = _storyRepository;
        }

        public bool CreateStory(Story_Snapchat story_Snapchat)
        {
            return storyRepository.CreateStory(story_Snapchat);
        }

        public bool DeleteStory(int id)
        {
            return storyRepository.DeleteStory(id);
        }

        public List<Story_Snapchat> Get24hour()
        {
            return storyRepository.Get24hour();
        }

        public List<Story_Snapchat> GetAllStory()
        {
            return storyRepository.GetAllStory();
        }

        public List<Story_Snapchat> GetTop10()
        {
            return storyRepository.GetTop10();
        }

        public bool Updateisblock(Story_Snapchat story_Snapchat)
        {
            return storyRepository.Updateisblock(story_Snapchat);
        }
    }
}
