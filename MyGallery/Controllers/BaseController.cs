using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyGallery.Data;

namespace MyGallery.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IDatabaseRepository _repository;
        protected readonly IMapper _mapper;

        public BaseController(IDatabaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
