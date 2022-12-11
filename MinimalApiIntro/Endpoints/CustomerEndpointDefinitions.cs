using MapsterMapper;
using MinimalApiIntro.Data;
using MinimalApiIntro.DTOs;
using MinimalApiIntro.Models;
using MinimalApiIntro.Repositories;

namespace MinimalApiIntro.Endpoints
{
    public static class CustomerEndpointDefinitions
    {


        public static void MapCustomerEndpoints(this WebApplication app)
        {
            app.MapDelete("/api/Customer/{Id}", (int Id) =>
            {
                return Results.Ok($"Customer Id : {Id} Deleted Successfully!");
            });

            app.MapGet("/api/Test", () =>
            {
                return Results.Ok("Test");
            });

            app.MapPost("/api/Customer", async (ICustomerRepository repo, IMapper mapper, CustomerDto customer) =>
            {
                //var customerNew = new Customer
                //{
                //    FirstName = customer.FirstName,
                //    LastName = customer.LastName,
                //};
                return Results.Ok(
                    await repo.Create(mapper.Map<Customer>(customer))
                    );
            });

        }

        //public static IResult GetCustomerTest(string id)
        //{
        //    return Results.Ok("Test");
        //}
    }
}
