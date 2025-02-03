using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test1.Services;
using Test1.Models;



namespace Test1.Controllers
{
    public class ProviderController :  ControllerBase
    {
        private readonly IProviderSevice _providerService;

        public ProviderController(IProviderSevice serv)
        {
        _providerService = serv;
        }
[HttpGet]
[Route("getProvider/")]
        public async Task<ActionResult<List<Provider>>> GetProvider()
        {
            try
            {
            var provider = await _providerService.GetProvider();
            return Ok(provider);
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }

[HttpPost]
[Route("addProvider/")]
        public ActionResult<Provider> AddProvider(Provider provider)
        {
            try
            {
            _providerService.AddProvider(provider);
            return Ok($"id = {provider.id}");
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }
    

[HttpDelete]
[Route("deleteProvider/")]
        public ActionResult<Provider> DeleteProvider(int id)
        {
            try
            {
            _providerService.DeleteProvider(id);
            return Ok(id);
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }

[HttpPut]
[Route("setProvider/")]
        public ActionResult<Provider> SetProvider(Provider provider)
        {
            try
            {
            _providerService.SetProvider(provider);
            return Ok(provider);
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            }
        }
    }
}