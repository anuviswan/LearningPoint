﻿using AutoMapper;
using CqrsAndMediatR.Api.Models.Customer;
using CqrsAndMediatR.Domain.Entities;
using CqrsAndMediatR.Service.Command;
using CqrsAndMediatR.Service.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsAndMediatR.Api.Controllers;

[ApiController]
[Route("Customer")]
public class CustomerController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public CustomerController(IMediator mediator, IMapper mapper)
    {
        (_mediator, _mapper) = (mediator, mapper);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("GetAll")]
    public async Task<ActionResult<List<GetAllCustomersResponseDto>>> GetAll()
    {
        try
        {
            var response = await _mediator.Send(new GetAllCustomersQuery());
            return _mapper.Map<List<GetAllCustomersResponseDto>>(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("CreateCustomer")]
    public async Task<ActionResult<CreateCustomerResponseDto>> Create(CreateCustomerRequestDto createCustomerModel)
    {
        try
        {
            var customer = _mapper.Map<Customer>(createCustomerModel);
            var response = await _mediator.Send(new CreateCustomerCommand
            {
                Customer = customer
            });

            return _mapper.Map<CreateCustomerResponseDto>(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("DeleteCustomer")]
    public async Task<ActionResult<DeleteCustomerResponseDto>> Delete(DeleteCustomerRequestDto deleteCustomerRequest)
    {
        try
        {
            var customer = _mapper.Map<Customer>(deleteCustomerRequest);
            var response = await _mediator.Send(new DeleteCustomerCommand
            {
                Customer = customer
            });

            return _mapper.Map<DeleteCustomerResponseDto>(response);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("FindCustomer")]
    public async Task<ActionResult<FindCustomerResponseDto>> Find([FromQuery(Name ="id")]long customerId)
    {
        try
        {
            var response = await _mediator.Send(new FindCustomerQuery
            {
                CustomerId = customerId
            });

            return _mapper.Map<FindCustomerResponseDto>(response);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

}
