﻿using dataAccess;
using dataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using service.Request.CustomerDto;

namespace api.Controllers;

public class CustomerController(DMIContext context) : ControllerBase
{
    [HttpGet]
    [Route("api/customer")]
    public ActionResult GetAllCustomers()
    {
        var result = context.Customers.ToList();
        return Ok(result);
    }
    
    [HttpPost]
    [Route("api/customer")]
    public ActionResult<Customer> CreateCustomer([FromBody]CreateCustomerDto customer)
    {
        var customerEntity = new Customer()
        {
            Name = customer.Name,
            Address = customer.Address,
            Phone = customer.Phone,
            Email = customer.Email
        };
        var result = context.Customers.Add(customerEntity);
        context.SaveChanges();
        return Ok(customerEntity);
    }
    
    [HttpPut]
    [Route("api/customer/{id}")]
    public ActionResult<Customer> UpdateCustomer(int id, [FromBody]EditCustomerDto customer)
    {
        var customerEntity = context.Customers.FirstOrDefault(x => x.Id == id);
        if (customerEntity == null)
        {
            return NotFound();
        }
        customerEntity.Name = customer.Name;
        customerEntity.Address = customer.Address;
        customerEntity.Phone = customer.Phone;
        customerEntity.Email = customer.Email;
        context.SaveChanges();
        return Ok(customerEntity);
    }
    
    [HttpDelete]
    [Route("api/customer/{id}")]
    public ActionResult DeleteCustomer(int id)
    {
        var customerEntity = context.Customers.FirstOrDefault(x => x.Id == id);
        if (customerEntity == null)
        {
            return NotFound();
        }
        context.Customers.Remove(customerEntity);
        context.SaveChanges();
        return Ok();
    }
}