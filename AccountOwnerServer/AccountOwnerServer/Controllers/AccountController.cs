using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AccountController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccountsAsync()
        {
            try
            {
                var accounts = await _repository.Account.GetAllAccountsAsync();
                _logger.LogInfo($"Returned all owners from database.");
                // Mapowanie poniżej 
                var accountsResult = _mapper.Map<IEnumerable<AccountDto>>(accounts);
                return Ok(accountsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // Get AccountById
        [HttpGet("{id}", Name = "AccountById")]
        public async Task<IActionResult> GetAccountByIdAsync(Guid id)
        {
            try
            {
                var account = await _repository.Account.GetAccountByIdAsync(id);

                if (account == null)
                {
                    _logger.LogError($"Account with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned account with id: {id}");

                    var accountResult = _mapper.Map<AccountDto>(account);
                    return Ok(accountResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAccountById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // Create account
        // {M: POST} || localhost:5000/account/
        [HttpPost(Name = "CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody]AccountForCreationDto account)
        {
            try
            {
                if (account == null)
                {
                    _logger.LogError("Account object sent from client is null.");
                    return BadRequest("Account object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Account object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var accountEntity = _mapper.Map<Account>(account);

                _repository.Account.CreateAccount(accountEntity);
                await _repository.SaveAsync();

                var createdAccount = _mapper.Map<AccountDto>(accountEntity);

                return CreatedAtRoute("AccountById", new { id = createdAccount.Id }, createdAccount); // Zrób metode w kontrolerze zwracajaca Account By ID
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, [FromBody]AccountForUpdateDto account)
        {
            try
            {
                if (account == null)
                {
                    _logger.LogError("Account object sent from client is null.");
                    return BadRequest("Account object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid account object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var accountEntity = await _repository.Account.GetAccountByIdAsync(id);
                if (accountEntity == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(account, accountEntity);

                _repository.Account.UpdateAccount(accountEntity);
                await _repository.SaveAsync();

                return NoContent();
                // return CreatedAtRoute("AccountById", new { id }, accountEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAccount action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        // Kasowanie Konta
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            try
            {
                var account = await _repository.Account.GetAccountByIdAsync(id);
                if (account == null)
                {
                    _logger.LogError($"Account with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Account.DeleteAccount(account);
                await _repository.SaveAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside DeleteAccount action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}