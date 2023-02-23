using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TUAApi.DTO;
using TUAApi.Services.Product;

namespace TUAApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : CustomControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        //[HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _productService.GetProducts();               
                return OkResult(result);

            }
            catch (Exception ex)
            {

                return ServerErrorResult(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _productService.GetProductById(id);
                return OkResult(result);

            }
            catch (Exception ex)
            {

                return ServerErrorResult(ex.Message);

            }
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetAllPrductTypes()
        {
            try
            {
                var result = await _productService.GetProductTypes();
                return OkResult(result);

            }
            catch (Exception ex)
            {

                return ServerErrorResult(ex.Message);

            }
        }

        ///// <summary>
        ///// To create a new proposal
        ///// </summary>
        ///// <param name="dto">Proposal Request</param>
        ///// <returns>ID of newly created proposal</returns>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] ContractRequestDto dto)
        //{
        //    var response = new ResponsePayloadDTO<int>();
        //    try
        //    {
        //        var result = await _proposalService.CreateNewContract(dto);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (ArgumentException ex)
        //    {
        //        response.Results = -1;
        //        response.StatusCode = StatusCodes.Status400BadRequest;
        //        response.Message = "Duplicate";
        //        return StatusCode(400, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = -1;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// To create a new proposal
        ///// </summary>
        ///// <param name="dto">Proposal Request</param>
        ///// <returns>ID of newly created proposal</returns>
        //[HttpPost("version")]
        //public async Task<IActionResult> CreateNewVersion([FromBody] ContractRequestDto dto)
        //{
        //    var response = new ResponsePayloadDTO<int>();
        //    try
        //    {
        //        var result = await _proposalService.CreateNewContractVersion(dto);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (ArgumentException ex)
        //    {
        //        response.Results = -1;
        //        response.StatusCode = StatusCodes.Status400BadRequest;
        //        response.Message = "Duplicate";
        //        return StatusCode(400, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = 0;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// To Update the Proposal
        ///// </summary>
        ///// <param name="dto">Proposal Request</param>
        ///// <returns>A boolean to represent the status of updation</returns>
        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] ContractRequestDto dto)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.UpdateContract(dto);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);


        //    }
        //    catch (ArgumentException ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status400BadRequest;
        //        response.Message = "Duplicate";
        //        return StatusCode(400, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// To delete a proposal
        ///// </summary>
        ///// <param name="id">ID of the proposal you want to delete</param>
        ///// <returns>A boolean representing the deletion status</returns>
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.DeleteContractById(id);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// To get the proposal types
        ///// </summary>
        ///// <returns>An action result of type proposal types</returns>

        //[HttpGet("types")]
        //public async Task<IActionResult> ProposalTypes()
        //{
        //    var response = new ResponsePayloadDTO<List<ContractTypeDto>>();
        //    try
        //    {
        //        var result = await _proposalService.GetAllContractTypes();
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// To get the proposal categories
        ///// </summary>
        ///// <returns>An action result of type proposal categories</returns>

        //[HttpGet("categories")]
        //public async Task<IActionResult> ProposalCategories()
        //{
        //    var response = new ResponsePayloadDTO<List<ContractCategoryDto>>();
        //    try
        //    {
        //        var result = await _proposalService.GetAllContractCategories();
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// To create a copy of a proposal
        ///// </summary>
        ///// <param name="proposalId">ID of the proposal you want to copy</param>
        ///// <returns>ID of the newly created proposal</returns>
        //[HttpPost("copy")]
        //public async Task<IActionResult> CopyProposal([FromQuery] int proposalId, [FromQuery] string proposalName)
        //{
        //    var response = new ResponsePayloadDTO<int>();
        //    try
        //    {
        //        var userId = (User?.FindFirstValue("id")) ?? string.Empty;
        //        var result = await _proposalService.CopyContract(proposalId, proposalName, userId);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);


        //    }
        //    catch (ArgumentException ex)
        //    {
        //        response.Results = -1;
        //        response.StatusCode = StatusCodes.Status400BadRequest;
        //        response.Message = "Duplicate";
        //        return StatusCode(400, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = 0;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// Get All the statuses of a proposal
        ///// </summary>
        ///// <returns>Statuses of a proposal
        ///// </returns>
        //[HttpGet("status")]
        //public async Task<IActionResult> ProposalStatus()
        //{
        //    var response = new ResponsePayloadDTO<List<ContractStatusDto>>();
        //    try
        //    {
        //        var result = await _proposalService.GetAllContractStatuses();
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// Get all the stages of a proposal
        ///// </summary>
        ///// <returns>Stages of a proposal</returns>
        //[HttpGet("stages")]
        //public async Task<IActionResult> ProposalStages()
        //{
        //    var response = new ResponsePayloadDTO<List<ContractStageDto>>();
        //    try
        //    {
        //        var result = await _proposalService.GetAllContractStages();
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// To set the specific version to current version.
        ///// </summary>
        /////<param name="id">Id of the Proposal you want to set is as a current versions</param>
        ///// <returns>
        ///// An Action Result of type bool.
        ///// </returns>
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCurrent(int id)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.UpdateCurrentState(id);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);

        //    }
        //}

        ///// <summary>
        ///// Get the agreement for a specific proposal version.
        ///// </summary>
        ///// <param name="contractVersionID"></param>
        ///// <returns></returns>
        //[HttpGet("agreement/{id}")]
        //public async Task<IActionResult> GetAgreementByContractId(int id)
        //{
        //    var response = new ResponsePayloadDTO<ContractAgreementDto>();
        //    try
        //    {
        //        var result = await _contractAgreementService.GetAgreementByContractId(id);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);

        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// Update the agreement for a specific proposal version.
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <param name="agreement"></param>
        ///// <returns></returns>
        //[HttpPut("agreement")]
        //public async Task<IActionResult> UpdateContractAgreement(ContractAgreementDto agreement)
        //{
        //    var response = new ResponsePayloadDTO<ContractAgreementDto>();
        //    try
        //    {
        //        var result = await _contractAgreementService.UpdateContractAgreement(agreement);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// Add new contract document.
        ///// </summary>
        ///// <param name="contractAgreementDto"></param>
        ///// <returns></returns>
        //[HttpPost("document")]
        //public async Task<IActionResult> UploadContractDocument(ContractDocumentDto contractAgreementDto)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.UploadContractDocument(contractAgreementDto);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// Get all contract documents
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("{ID}/document")]
        //public async Task<IActionResult> GetContractDocumentsByID(int ID)
        //{
        //    var response = new ResponsePayloadDTO<List<ContractDocumentDto>>();
        //    try
        //    {
        //        var result = await _proposalService.GetAllContractDocumentsByID(ID);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// Delete a specific contract document.
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //[HttpDelete("contract-document/{ID}")]
        //public async Task<IActionResult> DeleteContractDocument(int ID)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.DeleteContractDocument(ID);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// To get SOW of a contract by ID
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //[HttpGet("contract-sow/{ID}")]
        //public async Task<IActionResult> GetContractSOW(int ID)
        //{
        //    var response = new ResponsePayloadDTO<string>();
        //    try
        //    {
        //        var result = await _proposalService.GetContractSOW(ID);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// To update SOW of a contract by ID.
        ///// </summary>
        ///// <param name="contractSOWDto"></param>
        ///// <returns></returns>
        //[HttpPut("contract-sow")]
        //public async Task<IActionResult> UpdateContractSOW(ContractSOWDto contractSOWDto)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.UpdateContractSOW(contractSOWDto);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// To get terms of a contract by ID.
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //[HttpGet("contract-terms/{ID}")]
        //public async Task<IActionResult> GetContractTerms(int ID)
        //{
        //    var response = new ResponsePayloadDTO<string>();
        //    try
        //    {
        //        var result = await _proposalService.GetContractTerms(ID);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// To update terms of a contract by ID.
        ///// </summary>
        ///// <param name="contractTermsDto"></param>
        ///// <returns></returns>
        //[HttpPut("contract-terms")]
        //public async Task<IActionResult> UpdateContractTerms(ContractTermsDto contractTermsDto)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.UpdateContractTerms(contractTermsDto);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        //[HttpPut("contract-stage")]
        //public async Task<IActionResult> UpdateContractStage(ContractStageUpdateDetailDto contractStageUpdateDetails)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.UpdateContractStage(contractStageUpdateDetails);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        //[HttpDelete("contract/{ID}")]
        //public async Task<IActionResult> DeleteContract(int ID)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.DeleteContract(ID);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// It gets all the clients and users associated to deals and contracts.
        ///// </summary>
        ///// <param name="associationType"></param>
        ///// <returns></returns>
        //[HttpGet("associated-clients")]
        //public async Task<ActionResult> GetAssociatedClients()
        //{
        //    var response = new ResponsePayloadDTO<AssociatedClientsDto>();
        //    try
        //    {
        //        var result = await _proposalService.GetAssociatedClients();
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = null;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        ///// <summary>
        ///// It updates the clients associated to Contracts
        ///// </summary>
        ///// <param name="clientsModificationDto"></param>
        ///// <returns></returns>
        //[HttpPut("associated-clients")]
        //public async Task<IActionResult> UpdateAssociatedClients(AssociatedEntitiesUpdateDto clientsModificationDto)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.UpdateAssociatedClients(clientsModificationDto);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }
        //}

        //[HttpPut("unarchive-by-id/{ID}")]
        //public async Task<IActionResult> UnarchiveContractVersionByContractID(int ID)
        //{
        //    var response = new ResponsePayloadDTO<bool>();
        //    try
        //    {
        //        var result = await _proposalService.UnarchiveVersionByContractID(ID);
        //        response.Results = result;
        //        response.StatusCode = StatusCodes.Status200OK;
        //        response.Message = "Success";
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Results = false;
        //        response.StatusCode = StatusCodes.Status500InternalServerError;
        //        response.Message = "Something went wrong";
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(500, response);
        //    }

        //}
    }
}
