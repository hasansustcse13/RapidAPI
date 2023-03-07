using AUTH.API.DTOs;
using AUTH.Biz.BizEntities;
using AUTH.Biz.BOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AUTH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthBizContext _bizContext;
        private readonly IMapper _mapper;

        public UsersController(IAuthBizContext bizContext, IMapper mapper)
        {
            _bizContext = bizContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var bos = await _bizContext.Users.GetAllUsersAsync();
            var dtos = _mapper.Map<UserDTO[]>(bos);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(UserDTO userDTO)
        {
            var userBO = _mapper.Map<UserBO>(userDTO);
            var userId = await _bizContext.Users.AddUserAsync(userBO);
            return Ok(userId);
        }
    }
}
