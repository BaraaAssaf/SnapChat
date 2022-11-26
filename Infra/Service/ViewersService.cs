using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class ViewersService : IViewersService
    {
        private readonly IViewersRepository viewersRepository;
        public ViewersService(IViewersRepository _viewersRepository)
        {
            viewersRepository =_viewersRepository;
        }
        public List<CountViewersDTO> CountViewers(InputViewersDTO inputViewersDTO)
        {
            return viewersRepository.CountViewers(inputViewersDTO);
        }

        public bool CreateViewers(Viewers_Snapchat viewers_Snapchat)
        {
            return viewersRepository.CreateViewers(viewers_Snapchat);
        }

        public List<Viewers_Snapchat> getallViewers(int id)
        {
            return viewersRepository.getallViewers(id);
        }

        public List<CountTop10> getcounttop10()
        {

            return viewersRepository.getcounttop10();

        }
    }
}
