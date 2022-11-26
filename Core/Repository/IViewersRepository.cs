using Core.Data;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Repository
{
    public interface IViewersRepository
    {
        bool CreateViewers(Viewers_Snapchat viewers_Snapchat);
        List<CountViewersDTO> CountViewers(InputViewersDTO inputViewersDTO);

       public  List<CountTop10> getcounttop10();
        List<Viewers_Snapchat> getallViewers(int id);
        
    }
}
