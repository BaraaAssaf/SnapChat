using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IViewersService
    {
        bool CreateViewers(Viewers_Snapchat viewers_Snapchat);
        List<CountViewersDTO> CountViewers(InputViewersDTO inputViewersDTO);
        List<Viewers_Snapchat> getallViewers(int id);
        public List<CountTop10> getcounttop10();


    }
}