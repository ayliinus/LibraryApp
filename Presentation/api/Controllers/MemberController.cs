using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberBusinessSerive _memberBusiness;

        public MemberController(IMemberBusinessSerive memberBusiness)
        {
            _memberBusiness = memberBusiness;
        }
        [HttpPost("AddMember")]
        public IActionResult AddMember([FromBody] AddMemberVM model)
        {
            try
            {
                _memberBusiness.CreateBorrower(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
