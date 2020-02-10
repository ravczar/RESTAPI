using Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AccountOwnerServer.Controllers
{
    // localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public ValuesController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var domesticAccounts = _repoWrapper.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var owners = _repoWrapper.Owner.FindAll();

            string x = owners.ToString();

            return new string[] { domesticAccounts.ToString(), x };
        }
    }



}
