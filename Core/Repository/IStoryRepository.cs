using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository
{
    public interface IStoryRepository
    {
        bool CreateStory(Story_Snapchat story_Snapchat);
        bool Updateisblock(Story_Snapchat story_Snapchat);
        bool DeleteStory(int id);
        List<Story_Snapchat > GetAllStory();
        List<Story_Snapchat> GetTop10();
        List<Story_Snapchat> Get24hour();
    }
}
